using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Linkdev.Intern.EQuiz.Data;

namespace Linkdev.Intern.EQuiz.Shared
{
    public static class SMapper
    {
        #region Topic

        public static Data.Domain.Topic Map(Topic from)
        {
            try
            { 
                if (from == null)
                    return null;

                var to = new Data.Domain.Topic
                {
                    ID = from.ID,
                    CreationDate = from.CreationDate,
                    IsDeleted = from.IsDeleted,
                    Name = from.Name,
                    Questions = Map(from.Questions)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Topic Map(Data.Domain.Topic from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new Topic
                {
                    ID = from.ID,
                    CreationDate = from.CreationDate,
                    IsDeleted = from.IsDeleted,
                    Name = from.Name,
                    Questions = Map(from.Questions)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region Employee

        #endregion

        #region EmployeeQuestionTemplate

        #endregion

        #region EmployeeTemplate

        #endregion

        #region Question

        #endregion

        #region QuestionQuizes
        public static Questions_Quizes Map(Data.Domain.Questions_Quizes from)
        {
            try
            {
                if (from != null)
                    return null;

                var to = new Questions_Quizes
                {
                    ID = from.ID,
                    QuestionID = from.QuestionID,
                    QuizID = from.QuizID,
                    Question = Map(from.Question),
                    Quiz = Map(from.Quiz)
                };

                return to;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public static Data.Domain.Questions_Quizes Map(Questions_Quizes from)
        {
            try
            {
                if (from != null)
                    return null;

                var to = new Data.Domain.Questions_Quizes
                {
                    ID = from.ID,
                    QuestionID = from.QuestionID,
                    QuizID = from.QuizID,
                    Question = Map(from.Question),
                    Quiz = Map(from.Quiz)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }


        #endregion

        #region QuestionTemplate

        public static Questions_Templates Map(Data.Domain.Questions_Templates from)
        {
            try
            {
                if (from != null)
                    return null;

                var to = new Questions_Templates
                {
                    ID = from.ID,
                    QuestionID = from.QuestionID,
                    TemplateID = from.TemplateID,
                    Question = Map(from.Question),
                    Template = Map(from.Template)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Data.Domain.Questions_Templates Map(Questions_Templates from)
        {
            try
            {
                if (from != null)
                    return null;

                var to = new Data.Domain.Questions_Templates
                {
                    ID = from.ID,
                    QuestionID = from.QuestionID,
                    TemplateID = from.TemplateID,
                    Question = Map(from.Question),
                    Template = Map(from.Template)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Quiz

        public static Quiz Map(Data.Domain.Quize from)
        {
            try
            {
                if (from != null)
                    return null;

                var to = new Quiz
                {
                    ID = from.ID,
                    ActivationDate = from.ActivationDate,
                    CreationDate = from.CreationDate,
                    Description = from.Description,
                    ExpirationDate = from.ExpirationDate,
                    IsActive = from.IsActive,
                    IsDeleted = from.IsDeleted,
                    Name = from.Name,
                    NumberOfTrials = from.NumberOfTrials,
                    PassingScore = from.PassingScore,
                    Quarter = from.Quarter,
                    QuestionsNumber = from.QuestionsNumber,
                    Timeout = from.Timeout,
                    Year = from.Year,
                    Questions_Quizes = Map(from.Questions_Quizes),
                    Templates = Map(from.Templates)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Data.Domain.Quize Map(Quiz from)
        {
            try
            {
                if (from != null)
                    return null;

                var to = new Data.Domain.Quize
                {
                    ID = from.ID,
                    ActivationDate = from.ActivationDate,
                    CreationDate = from.CreationDate,
                    Description = from.Description,
                    ExpirationDate = from.ExpirationDate,
                    IsActive = from.IsActive,
                    IsDeleted = from.IsDeleted,
                    Name = from.Name,
                    NumberOfTrials = from.NumberOfTrials,
                    PassingScore = from.PassingScore,
                    Quarter = from.Quarter,
                    QuestionsNumber = from.QuestionsNumber,
                    Timeout = from.Timeout,
                    Year = from.Year,
                    Questions_Quizes = Map(from.Questions_Quizes),
                    Templates = Map(from.Templates)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region Template

        public static Template Map(Data.Domain.Template from)
        {
            try
            {
                if (from != null)
                    return null;

                var to = new Template
                {
                     ID = from.ID,
                     CreationDate = from.CreationDate,
                     EmployeeID = from.EmployeeID,
                     QuizID = from.QuizID,
                     Employee = Map(from.Employee),
                     Quiz = Map(from.Quiz),
                     Employees_Questions_Templates = Map(from.Employees_Questions_Templates),
                     Employees_Templates = Map(from.Employees_Templates),
                     Questions_Templates = Map(from.Questions_Templates)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Data.Domain.Template Map(Template from)
        {
            try
            {
                if (from != null)
                    return null;

                var to = new Data.Domain.Template
                {
                    ID = from.ID,
                    CreationDate = from.CreationDate,
                    EmployeeID = from.EmployeeID,
                    QuizID = from.QuizID,
                    Employee = Map(from.Employee),
                    Quiz = Map(from.Quiz),
                    Employees_Questions_Templates = Map(from.Employees_Questions_Templates),
                    Employees_Templates = Map(from.Employees_Templates),
                    Questions_Templates = Map(from.Questions_Templates)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Answer

        public static Answer Map(Data.Domain.Answer from)
        {
            try
            {
                if (from != null)
                    return null;

                var to = new Answer
                {
                    ID = from.ID,
                    IsCorrect = from.IsCorrect,
                    IsDeleted = from.IsDeleted,
                    Text = from.Text,
                    QuestionID = from.QuestionID,
                    Question = Map(from.Question),
                    Employees_Questions_Templates = Map(from.Employees_Questions_Templates),
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Data.Domain.Answer Map(Answer from)
        {
            try
            {
                if (from != null)
                    return null;

                var to = new Data.Domain.Answer
                {
                    ID = from.ID,
                    IsCorrect = from.IsCorrect,
                    IsDeleted = from.IsDeleted,
                    Text = from.Text,
                    QuestionID = from.QuestionID,
                    Question = Map(from.Question),
                    Employees_Questions_Templates = Map(from.Employees_Questions_Templates),
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region QuestionQuizes-List
        public static ICollection<Questions_Quizes> Map(ICollection<Data.Domain.Questions_Quizes> from)
        {
            try
            {
                if (from != null && from.Count > 0)
                    return null;

                var to = new List<Questions_Quizes>();

                foreach (var item in from)
                {
                    to.Add(Map(item));
                }               

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static ICollection<Data.Domain.Questions_Quizes> Map(ICollection<Questions_Quizes> from)
        {
            try
            {
                if (from != null && from.Count > 0)
                    return null;

                var to = new List<Data.Domain.Questions_Quizes>();

                foreach (var item in from)
                {
                    to.Add(Map(item));
                }

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region QuestionTemplates- List

        public static ICollection<Questions_Templates> Map(ICollection<Data.Domain.Questions_Templates> from)
        {
            try
            {
                if (from != null && from.Count > 0)
                    return null;

                var to = new List<Questions_Templates>();

                foreach (var item in from)
                {
                    to.Add(Map(item));
                }

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static ICollection<Data.Domain.Questions_Templates> Map(ICollection<Questions_Templates> from)
        {
            try
            {
                if (from != null && from.Count > 0)
                    return null;

                var to = new List<Data.Domain.Questions_Templates>();

                foreach (var item in from)
                {
                    to.Add(Map(item));
                }

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Quiz-List
        public static ICollection<Quiz> Map(ICollection<Data.Domain.Quize> from)
        {
            try
            {
                if (from != null && from.Count > 0)
                    return null;

                var to = new List<Quiz>();

                foreach (var item in from)
                {
                    to.Add(Map(item));
                }

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static ICollection<Data.Domain.Quize> Map(ICollection<Quiz> from)
        {
            try
            {
                if (from != null && from.Count > 0)
                    return null;

                var to = new List<Data.Domain.Quize>();

                foreach (var item in from)
                {
                    to.Add(Map(item));
                }

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Template-List
        public static ICollection<Template> Map(ICollection<Data.Domain.Template> from)
        {
            try
            {
                if (from != null && from.Count > 0)
                    return null;

                var to = new List<Template>();

                foreach (var item in from)
                {
                    to.Add(Map(item));
                }

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static ICollection<Data.Domain.Template> Map(ICollection<Template> from)
        {
            try
            {
                if (from != null && from.Count > 0)
                    return null;

                var to = new List<Data.Domain.Template>();

                foreach (var item in from)
                {
                    to.Add(Map(item));
                }

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Answer-List

        public static ICollection<Answer> Map(ICollection<Data.Domain.Answer> from)
        {
            try
            {
                if (from != null && from.Count > 0)
                    return null;

                var to = new List<Answer>();

                foreach (var item in from)
                {
                    to.Add(Map(item));
                }

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static ICollection<Data.Domain.Answer> Map(ICollection<Answer> from)
        {
            try
            {
                if (from != null && from.Count > 0)
                    return null;

                var to = new List<Data.Domain.Answer>();

                foreach (var item in from)
                {
                    to.Add(Map(item));
                }

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}