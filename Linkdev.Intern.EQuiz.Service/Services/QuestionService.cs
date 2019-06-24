using Linkdev.Intern.EQuiz.Mappers;
using Linkdev.Intern.EQuiz.Repo.UnitOfWork;
using Linkdev.Intern.EQuiz.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Linkdev.Intern.EQuiz.Service.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork UnitOfWork;

        public QuestionService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public QuestionService()
        {
            UnitOfWork = new UnitOfWork(new Data.EQuizContext());
        }

        public bool? Add(Question question)
        {
            if (question != null)
            {
                var dtoQuestion = DTOMapper.Mapper.Map<Question, Data.Question>(question);
                var result = UnitOfWork.QuestionRepository.Add(dtoQuestion);
                UnitOfWork.SaveChanges();

                return result;
            }
            else
                return false;
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            var questions = UnitOfWork.QuestionRepository.GetAll();
            var dtoQuestions = DTOMapper.Mapper.Map<IEnumerable<Data.Question>,IEnumerable<Question>>(questions);

            return dtoQuestions;
        }

        public Question GetQuestionById(int id)
        {
            var question = UnitOfWork.QuestionRepository.GetByID(id);
            var dtoQuestion = DTOMapper.Mapper.Map<Data.Question, Question>(question);
            return dtoQuestion;
        }

        public IEnumerable<Question> FindQuestions(Expression<Func<Question, bool>> predicate)
        {
            var repoPredicate = DTOMapper.Mapper.Map<Expression<Func<Question, bool>>, Expression<Func<Data.Question, bool>>>(predicate);
            var questions = UnitOfWork.QuestionRepository.Find(repoPredicate);
            var dtoQuestions = DTOMapper.Mapper.Map<IEnumerable<Data.Question>,IEnumerable<Question>>(questions);

            return dtoQuestions;
        }

        public IEnumerable<Question> GetQuestionsByCreationDate(int pageIndex, int pageSize = 10)
        {
            var questions = UnitOfWork.QuestionRepository.GetQuestionsByCreationDate(pageIndex, pageSize);
            var dtoQuestions = DTOMapper.Mapper.Map<IEnumerable<Data.Question>, IEnumerable<Question>>(questions);

            return dtoQuestions;
        }

        public IEnumerable<Question> GetQuestionsByName(bool ascending, int pageIndex, int pageSize = 10)
        {
            var questions = UnitOfWork.QuestionRepository.GetQuestionsByName(ascending, pageIndex, pageSize);
            var dtoQuestions = DTOMapper.Mapper.Map<IEnumerable<Data.Question>, IEnumerable<Question>>(questions);

            return dtoQuestions;
        }

        public IEnumerable<Question> FilterQuestionsByText(string text,int pageIndex, int pageSize = 10)
        {
            var questions = UnitOfWork.QuestionRepository.FilterQuestionsByText(text, pageIndex, pageSize);
            var dtoQuestions = DTOMapper.Mapper.Map<IEnumerable<Data.Question>, IEnumerable<Question>>(questions);

            return dtoQuestions;
        }

        public IEnumerable<Question> GetQuestionsByTopic(Topic topic,int pageIndex, int pageSize = 10)
        {
            var modelTopic = DTOMapper.Mapper.Map<Topic, Data.Topic>(topic);
            var questions = UnitOfWork.QuestionRepository.GetQuestionsByTopic(modelTopic, pageIndex, pageSize);
            var dtoQuestions = DTOMapper.Mapper.Map<IEnumerable<Data.Question>, IEnumerable<Question>>(questions);

            return dtoQuestions;
        }

        public IEnumerable<Question> GetQuestionsByTopicName(string topicName, int pageIndex, int pageSize = 10)
        {
            var questions = UnitOfWork.QuestionRepository.GetQuestionsByTopicName(topicName, pageIndex, pageSize);
            var dtoQuestions = DTOMapper.Mapper.Map<IEnumerable<Data.Question>, IEnumerable<Question>>(questions);

            return dtoQuestions;
        }

        public string GetQuestionHint(int id)
        {
            var hint = UnitOfWork.QuestionRepository.GetQuestionHint(id);

            return hint;
        }

        public IEnumerable<Answer> GetQuestionAnswers(int id)
        {
            var answers = UnitOfWork.AnswerRepository.GetAnswersByQuestion(id);
            var dtoAnswers = DTOMapper.Mapper.Map<IEnumerable<Data.Answer>,IEnumerable<Answer>>(answers);

            return dtoAnswers;
        }

        public IEnumerable<Answer> GetCorrectQuestionAnswers(int id)
        {
            var answers = UnitOfWork.AnswerRepository.GetCorrectAnswersByQuestion(id);
            var dtoAnswers = DTOMapper.Mapper.Map<IEnumerable<Data.Answer>,IEnumerable<Answer>>(answers);

            return dtoAnswers;
        }


   
        

        public IEnumerable<Quiz> GetQuestionQuizez(int id)
        {
            var quizez = UnitOfWork.QuizRepository.GetQuizesByQuestion(id);
            var dtoQuizez = DTOMapper.Mapper.Map<IEnumerable<Data.Quize>, IEnumerable<Quiz>>(quizez);

            return dtoQuizez;
        }

        public Topic GetQuestionTopic(int id)
        {
            var topic = UnitOfWork.TopicRepository.GetTopicByQuestion(id);
            var dtoTopic = DTOMapper.Mapper.Map<Data.Topic, Topic>(topic);

            return dtoTopic;
        }


        public bool ChangeCorrectAnswers(int questionId, ICollection<Answer> answers)
        {
            if (answers != null)
            {
                /// if question assigned to active or deactive quiz
                /// where one or more user solved it
                /// we should return that question status as used
                /// but if no one solved it
                /// the action should apply

                /// check if e-quiz is not submitted

                if (!IsQuestionUsed(questionId) || !IsQuestionUsedInSubmittedQuiz(questionId))
                {
                    var dtoAnswers = DTOMapper.Mapper.Map<ICollection<Answer>, ICollection<Data.Answer>>(answers);

                    var result = UnitOfWork.QuestionRepository.ChangeCorrectAnswers(questionId, dtoAnswers);
                    UnitOfWork.SaveChanges();

                    return (bool)result;
                }
            }

            return false;
        }

        private bool IsQuestionUsedInSubmittedQuiz(int questionId)
        {
            var empsTemps = UnitOfWork.EmployeeTemplateRepository.GetEmployeesTemplatesByQuestionId(questionId);

            if (empsTemps.Any(et => et.Status != Data.EmployeeTemplateStatus.Assigned
                                     && et.Status != Data.EmployeeTemplateStatus.Missed
                                     && et.Status != Data.EmployeeTemplateStatus.InProgress))
                return true;
            else
                return false;
        }

        public bool EditQuestion(Question question)
        {
            if (question != null)
            {
                if (IsQuestionUsed(question.ID) == false)
                {
                    var dtoQuestion = DTOMapper.Mapper.Map<Question, Data.Question>(question);
                    var result = UnitOfWork.QuestionRepository.EditQuestion(dtoQuestion);
                    UnitOfWork.SaveChanges();

                    return (bool)result;
                }
            }

            return false;
        }

        public bool IsQuestionActive(int id)
        {
            return (bool)UnitOfWork.QuestionRepository.IsQuestionActive(id);
        }

        public bool IsQuestionUsed(int id)
        {
            return (bool)UnitOfWork.QuestionRepository.IsQuestionUsed(id);
        }

        public bool Remove(int id)
        {
            var ques = GetQuestionById(id);
            if (ques != null)
            {
                /// if question assigned to active or deactive quiz
                /// where one or more user solved it
                /// we should return that question status as used
                /// but if no one solved it
                /// the action should apply

                /// needs to check if e-quiz is not submitted

                if (!IsQuestionUsed(id) || !IsQuestionUsedInSubmittedQuiz(id))
                {
                    var dtoQuestion = DTOMapper.Mapper.Map<Question, Data.Question>(ques);
                    var result = UnitOfWork.QuestionRepository.Remove(dtoQuestion);
                    UnitOfWork.SaveChanges();

                    return (bool)result;
                }
            }

            return false;
        }




    }
}
