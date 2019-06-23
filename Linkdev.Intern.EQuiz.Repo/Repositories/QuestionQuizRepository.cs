using Linkdev.Intern.EQuiz.Data;
using Linkdev.Intern.EQuiz.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Repo.Repositories
{
    public class QuestionQuizRepository: Repository<Questions_Quizes>, IQuestionQuizRepository
    {
        public EQuizContext EQuizContext
        {
            get
            {
                return Context as EQuizContext;
            }
        }

        public QuestionQuizRepository(EQuizContext context) : base(context)
        {
        }


        public  bool?  Add(IEnumerable<Question> questions,Quize quiz)
        {
            if (questions != null && quiz != null)
            {
                foreach (var item in questions)
                {
                    Add(new Questions_Quizes()
                    {
                        QuestionID = item.ID,
                        QuizID = quiz.ID,
                        Question = item,
                        Quiz = quiz
                    });
                }
                return true;
            }
            else
                return false;
        }

        /// I need Include ?!!!
        public IEnumerable<Question> GetQuizQuestions(Quize quiz)
        {          
                return EQuizContext.Questions_Quizes
                        .Where(qq => qq.QuizID == quiz.ID)
                        .Select(qq => qq.Question)
                        .AsEnumerable();
        }

        public IEnumerable<Question> GetQuizQuestionsByQuizID(int quizID)
        {
            return EQuizContext.Questions_Quizes
                    .Where(qq => qq.QuizID == quizID)
                    .Select(qq => qq.Question)
                    .AsEnumerable();
        }
    }
}