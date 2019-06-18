using Linkdev.Intern.EQuiz.Mappers;
using Linkdev.Intern.EQuiz.Repo.UnitOfWork;
using Linkdev.Intern.EQuiz.Service.Interfaces;
using Linkdev.Intern.EQuiz.Service.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Question GetQuestionByID(int id)
        {
            var question = UnitOfWork.QuestionRepository.GetByID(id);

            return DTOMapper.Mapper.Map<Data.Question, Question>(question);
        }

        public bool ChangeCorrectAnswers(int questionId, ICollection<Answer> answers)
        {
            if (answers != null)
            {
                var dtoAnswers = DTOMapper.Mapper.Map<ICollection<Answer>, ICollection<Data.Answer>>(answers);

                var result = UnitOfWork.QuestionRepository.ChangeCorrectAnswers(questionId, dtoAnswers);
                UnitOfWork.SaveChanges();

                return (bool)result;
            }
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
                else
                    return false;
            }
            else
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

        //public bool IsQuestionRemovable(int id)
        //{
        //    if(UnitOfWork.QuestionRepository.IsQuestionUsed(id) == false)
        //}

        public bool Remove(int id)
        {
            var ques = GetQuestionByID(id);
            if (ques != null)
            {
                var dtoQuestion = DTOMapper.Mapper.Map<Question, Data.Question>(ques);
                var result = UnitOfWork.QuestionRepository.Remove(dtoQuestion);
                UnitOfWork.SaveChanges();

                return (bool)result;
            }

            return false;
        }
    }
}