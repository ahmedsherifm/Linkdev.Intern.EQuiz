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

        public IEnumerable<Quiz> GetQuestionQuizez(int id)
        {
            var quizez = UnitOfWork.QuizRepository.GetQuizesByQuestion(id);
            var dtoQuizez = DTOMapper.Mapper.Map<IEnumerable<Data.Quiz>, IEnumerable<Quiz>>(quizez);

            return dtoQuizez;
        }

        public Topic GetQuestionTopic(int id)
        {
            var topic = UnitOfWork.TopicRepository.GetTopicByQuestion(id);
            var dtoTopic = DTOMapper.Mapper.Map<Data.Topic, Topic>(topic);

            return dtoTopic;
        }







    }
}