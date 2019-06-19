using Linkdev.Intern.EQuiz.Repo.UnitOfWork;
using Linkdev.Intern.EQuiz.Service.Interfaces;
using Linkdev.Intern.EQuiz.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Service.Services
{
    public class QuizService: IQuizService
    {
        private readonly IUnitOfWork UnitOfWork;

        public QuizService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public QuizService()
        {
            UnitOfWork = new UnitOfWork(new Data.EQuizContext());
        }

        public bool? CreateQuiz (Quiz quiz,IEnumerable<Question> questions)
        {           
            if (quiz != null && questions != null)
            {
                foreach (var item in questions)
                {
                    var QuestionQuiz = new Questions_Quizes() { Quiz = quiz, Question = item };
                    var dtoQuestionQuiz = DTOMapper.Mapper.Map<Questions_Quizes, Data.Questions_Quizes>(QuestionQuiz);
                    UnitOfWork.QuestionQuizRepository.Add(dtoQuestionQuiz);
                }

                UnitOfWork.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}