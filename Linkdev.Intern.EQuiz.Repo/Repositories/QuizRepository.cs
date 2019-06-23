using Linkdev.Intern.EQuiz.Data;
using Linkdev.Intern.EQuiz.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Repo.Repositories
{
    public class QuizRepository : Repository<Quize>, IQuizRepository
    {
        public EQuizContext EQuizContext
        {
            get
            {
                return Context as EQuizContext;
            }
        }

        public QuizRepository(EQuizContext context) : base(context)
        {
        }

        public IEnumerable<Quize> GetQuizesByQuestion(int qid)
        {
            return EQuizContext.Questions_Quizes
                    .Where(q => q.Question.ID == qid)
                    .Include(q => q.Quiz)
                    .Select(q => q.Quiz)
                    .AsEnumerable();
        }

        public IEnumerable<Answer> GetQuizAnswers(int id)
        {
            return EQuizContext.Answers
                .Include(a=>a.Question)
                .Include(a=>a.Question.Questions_Quizes)
                .Where(a => a.Question.Questions_Quizes
                .Any(qq => qq.QuizID == id))
                .AsEnumerable();
        }

        public bool? ExtendExpirationDate(int id, DateTime expirationDate)
        {
            var quiz = GetByID(id);

            if (quiz != null)
            {
                var oldExpireDate = quiz.ExpirationDate;

                if (expirationDate > oldExpireDate)
                {
                    quiz.ExpirationDate = expirationDate;

                    return true;
                }
            }

            return false;
        }

        public bool? DeactivateQuiz(int id)
        {
            var quiz = GetByID(id);

            if(quiz != null)
            {
                quiz.IsActive = false;

                return true;
            }

            return false;
        }

        public bool? DeactivateQuizesList(ICollection<int> quizesIds)
        {
            if (quizesIds != null)
            {
                foreach (var id in quizesIds)
                {
                    var quiz = GetByID(id);

                    if (quiz != null)
                    {
                        quiz.IsActive = false;
                    }
                }

                return true;
            }

            return false;
        }

        public bool? ActivateQuiz(int id)
        {
            var quiz = GetByID(id);

            if (quiz != null)
            {
                quiz.IsActive = true;

                return true;
            }

            return false;
        }

        public bool? UpdateNumberOfTrials(int id, int numberOfTrials)
        {
            var quiz = GetByID(id);

            if (quiz != null)
            {
                if (numberOfTrials != quiz.NumberOfTrials)
                {
                    quiz.NumberOfTrials = numberOfTrials;

                    return true;
                }
            }

            return false;
        }

        public bool? UpdatePassingScore(int id, int passingScore)
        {
            var quiz = GetByID(id);

            if (quiz != null)
            {
                if (passingScore != quiz.PassingScore)
                {
                    quiz.PassingScore = passingScore;

                    return true;
                }
            }

            return false;
        }

        public bool? ChangeQuizName(int id, string name)
        {
            var quiz = GetByID(id);

            if (quiz != null)
            {
                if (name != quiz.Name)
                {
                    quiz.Name = name;

                    return true;
                }
            }

            return false;
        }

        public bool? IsQuizActive(int id)
        {
            var quiz = GetByID(id);

            if (quiz != null)
            {
                return quiz.IsActive;
            }

            return null;
        }

        public bool? RemoveSelectedDeactivatedQuizesList(ICollection<int> quizesIds)
        {
            if(quizesIds != null)
            {
                foreach (var id in quizesIds)
                {
                    var quiz = GetByID(id);

                    if (quiz != null)
                    {
                        if (IsQuizActive(id) == false)
                        {
                            quiz.IsDeleted = true;
                        }
                    }
                }

                return true;
            }

            return false;
        }

        public IEnumerable<Quize> GetQuizesByCreationDate(int pageIndex, int pageSize = 10)
        {
            return EQuizContext.Quizes
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .OrderByDescending(q => q.CreationDate)
                    .AsEnumerable();
        }

        public IEnumerable<Quize> GetQuizesByName(bool ascending, int pageIndex, int pageSize = 10)
        {
            if (ascending)
            {
                return EQuizContext.Quizes
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .OrderBy(q => q.Name);
            }
            else
            {
                return EQuizContext.Quizes
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .OrderByDescending(q => q.Name);
            }
        }

        public IEnumerable<Quize> FilterQuizesByName(string name, int pageIndex, int pageSize = 10)
        {
            return EQuizContext.Quizes
                    .Where(q => q.Name.ToLower()
                    .Contains(name.ToLower()))
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .AsEnumerable();
        }

        public IEnumerable<Quize> GetActiveQuizes(int pageIndex, int pageSize = 10)
        {
            return EQuizContext.Quizes
                    .Where(q => q.IsActive)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .AsEnumerable();
        }

        public IEnumerable<Quize> FilterQuizesByQuarter(int quarter, int pageIndex, int pageSize = 10)
        {
            return EQuizContext.Quizes
                    .Where(q => q.Quarter == quarter)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .AsEnumerable();
        }

        public IEnumerable<Quize> FilterQuizesByYear(int year, int pageIndex, int pageSize = 10)
        {
            return EQuizContext.Quizes
                    .Where(q => q.Year == year)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .AsEnumerable();
        }
    }
}