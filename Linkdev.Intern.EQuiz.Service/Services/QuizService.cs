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

        private bool? CreateQuiz(Quiz quiz)
        {
            if (quiz != null)
            {
                var dtoQuiz = DTOMapper.Mapper.Map<Quiz, Data.Quiz>(quiz);
                UnitOfWork.QuizRepository.Add(dtoQuiz);
                UnitOfWork.SaveChanges();
                return true;
            }
            else
                return false;
        }

        private bool? CreateQuizQuestion(Quiz quiz, IEnumerable<Question> questions)
        {
            if (quiz != null && questions != null)
            {
                var dtoQuiz = DTOMapper.Mapper.Map<Quiz, Data.Quiz>(quiz);
                ICollection<Questions_Quizes> Questions_Quizes = new List<Questions_Quizes>();

                foreach (var item in questions)
                {
                    var QuestionQuiz = new Questions_Quizes() { QuizID = quiz.ID, QuestionID = item.ID };
                    Questions_Quizes.Add(QuestionQuiz);
                }

                var dtoQuestionQuizList = DTOMapper.Mapper.Map<ICollection<Questions_Quizes>, ICollection<Data.Questions_Quizes>>(Questions_Quizes);
                dtoQuiz.Questions_Quizes = dtoQuestionQuizList;
                UnitOfWork.SaveChanges();

                return true;
            }
            else
                return false;
        }

        ///// multiple quiz creation ?!!!
        public bool? CreateQuizWithQuestions(Quiz quiz, IEnumerable<Question> questions)
        {
            if (quiz != null && questions != null)
            {
                CreateQuiz(quiz);
                CreateQuizQuestion(quiz, questions); 
                return true;
            }
            else
                return false;
        }

    }
}