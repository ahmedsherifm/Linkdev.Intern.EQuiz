﻿using Linkdev.Intern.EQuiz.Shared;
using Linkdev.Intern.EQuiz.Data.Repository.UnitOfWork;
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
            UnitOfWork = new UnitOfWork(new Data.EntityFrameWork.EQuizContext());
        }

        public bool? Add(Question question)
        {
            if (question != null)
            {
                var dtoQuestion = SMapper.Map(question);
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
            var dtoQuestions = SMapper.Map(questions.ToList());

            return dtoQuestions;
        }

        public Question GetQuestionById(int id)
        {
            var question = UnitOfWork.QuestionRepository.GetByID(id);
            var dtoQuestion = SMapper.Map(question);
            return dtoQuestion;
        }

        //public IEnumerable<Question> FindQuestions(Expression<Func<Question, bool>> predicate)
        //{
        //    var repoPredicate = DTOMapper.Mapper.Map<Expression<Func<Question, bool>>, Expression<Func<Data.Domain.Question, bool>>>(predicate);
        //    var questions = UnitOfWork.QuestionRepository.Find(repoPredicate);
        //    var dtoQuestions = DTOMapper.Mapper.Map<IEnumerable<Data.Domain.Question>,IEnumerable<Question>>(questions);

        //    return dtoQuestions;
        //}

        public IEnumerable<Question> GetQuestionsByCreationDate(int pageIndex, int pageSize = 10)
        {
            var questions = UnitOfWork.QuestionRepository.GetQuestionsByCreationDate(pageIndex, pageSize);
            var dtoQuestions = SMapper.Map(questions.ToList());

            return dtoQuestions;
        }

        public IEnumerable<Question> GetQuestionsByName(bool ascending, int pageIndex, int pageSize = 10)
        {
            var questions = UnitOfWork.QuestionRepository.GetQuestionsByName(ascending, pageIndex, pageSize);
            var dtoQuestions = SMapper.Map(questions.ToList());

            return dtoQuestions;
        }

        public IEnumerable<Question> FilterQuestionsByText(string text,int pageIndex, int pageSize = 10)
        {
            var questions = UnitOfWork.QuestionRepository.FilterQuestionsByText(text, pageIndex, pageSize);
            var dtoQuestions = SMapper.Map(questions.ToList());

            return dtoQuestions;
        }

        public IEnumerable<Question> GetQuestionsByTopic(Topic topic,int pageIndex, int pageSize = 10)
        {
            var modelTopic = SMapper.Map(topic);
            var questions = UnitOfWork.QuestionRepository.GetQuestionsByTopic(modelTopic, pageIndex, pageSize);
            var dtoQuestions = SMapper.Map(questions.ToList());

            return dtoQuestions;
        }

        public IEnumerable<Question> GetQuestionsByTopicName(string topicName, int pageIndex, int pageSize = 10)
        {
            var questions = UnitOfWork.QuestionRepository.GetQuestionsByTopicName(topicName, pageIndex, pageSize);
            var dtoQuestions = SMapper.Map(questions.ToList());

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
            var dtoAnswers = SMapper.Map(answers.ToList());

            return dtoAnswers;
        }

        public IEnumerable<Answer> GetCorrectQuestionAnswers(int id)
        {
            var answers = UnitOfWork.AnswerRepository.GetCorrectAnswersByQuestion(id);
            var dtoAnswers = SMapper.Map(answers.ToList());

            return dtoAnswers;
        }


   
        

        public IEnumerable<Quiz> GetQuestionQuizez(int id)
        {
            var quizez = UnitOfWork.QuizRepository.GetQuizesByQuestion(id);
            var dtoQuizez = SMapper.Map(quizez.ToList());

            return dtoQuizez;
        }

        public Topic GetQuestionTopic(int id)
        {
            var topic = UnitOfWork.TopicRepository.GetTopicByQuestion(id);
            var dtoTopic = SMapper.Map(topic);

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
                    var dtoAnswers = SMapper.Map(answers);

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

            if (empsTemps.Any(et => et.Status != Data.Domain.EmployeeTemplateStatus.Assigned
                                     && et.Status != Data.Domain.EmployeeTemplateStatus.Missed
                                     && et.Status != Data.Domain.EmployeeTemplateStatus.InProgress))
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
                    var dtoQuestion = SMapper.Map(question);
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
                    var dtoQuestion = SMapper.Map(ques);
                    var result = UnitOfWork.QuestionRepository.Remove(dtoQuestion);
                    UnitOfWork.SaveChanges();

                    return (bool)result;
                }
            }

            return false;
        }




    }
}
