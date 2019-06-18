using Linkdev.Intern.EQuiz.Data;
using Linkdev.Intern.EQuiz.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Repo.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public EQuizContext EQuizContext
        {
            get
            {
                return Context as EQuizContext;
            }
        }

        public QuestionRepository(EQuizContext context) : base(context)
        {
        }

        public bool? IsQuestionActive(int id)
        {
            var ques = GetByID(id);
            return ques.IsActive;
        }

        public bool? IsQuestionUsed(int id)
        {
            var ques = GetByID(id);
            return ques.IsUsed;
        }

        public override bool? Remove(Question entity)
        {
            if (entity != null)
            {
                if (IsQuestionUsed(entity.ID) == false && IsQuestionActive(entity.ID) == false)
                {
                    var ques = GetByID(entity.ID);

                    ques.IsDeleted = true;

                    ques.Answers.Select(a => { a.IsDeleted = true; return a; }).ToList();
                    return true;
                }
            }

            return false;
        }

        public bool? EditQuestion(Question question)
        {
            if (question != null)
            {
                var ques = GetByID(question.ID);

                ques = question;

                return true;
            }

            return false;
        }

        public bool? ChangeCorrectAnswers(int questionId, ICollection<Answer> answers)
        {
            if (answers != null)
            {
                var ques = GetByID(questionId);

                ques.Answers = answers;

                return true;
            }

            return false;
        }

        public IEnumerable<Question> GetQuestionsByCreationDate(int pageIndex, int pageSize = 10)
        {
            return EQuizContext.Questions
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .OrderByDescending(q => q.CreationDate)
                    .AsEnumerable();
        }
    }
}
