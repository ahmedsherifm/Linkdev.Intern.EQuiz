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

        public static Data.Domain.Employee Map(Employee from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new Data.Domain.Employee
                {
                    ID = from.ID,
                    Name = from.Name,
                    DepartmentName = from.DepartmentName,
                    Templates = Map(from.Templates),
                    Employees_Templates = Map(from.Employees_Templates),
                    Employees_Questions_Templates = Map(from.Employees_Questions_Templates)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Employee Map(Data.Domain.Employee from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new Employee
                {
                    ID = from.ID,
                    Name = from.Name,
                    DepartmentName = from.DepartmentName,
                    Templates = Map(from.Templates),
                    Employees_Templates = Map(from.Employees_Templates),
                    Employees_Questions_Templates = Map(from.Employees_Questions_Templates)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region EmployeeQuestionTemplate

        public static Data.Domain.Employees_Questions_Templates Map(Employees_Questions_Templates from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new Data.Domain.Employees_Questions_Templates
                {
                    ID = from.ID,
                    QuestionID = from.QuestionID,
                    EmployeeID = from.EmployeeID,
                    AnswerID = from.AnswerID,
                    TemplateID = from.TemplateID,
                    Question = Map(from.Question),
                    Employee = Map(from.Employee),
                    Answer = Map(from.Answer),
                    Template = Map(from.Template)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Employees_Questions_Templates Map(Data.Domain.Employees_Questions_Templates from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new Employees_Questions_Templates
                {
                    ID = from.ID,
                    QuestionID = from.QuestionID,
                    EmployeeID = from.EmployeeID,
                    AnswerID = from.AnswerID,
                    TemplateID = from.TemplateID,
                    Question = Map(from.Question),
                    Employee = Map(from.Employee),
                    Answer = Map(from.Answer),
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

        #region EmployeeTemplate

        public static Data.Domain.Employees_Templates Map(Employees_Templates from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new Data.Domain.Employees_Templates
                {
                    ID = from.ID,
                    EmployeeID = from.EmployeeID,
                    TemplateID = from.TemplateID,
                    Score = from.Score,
                    TimeTaken = from.TimeTaken,
                    TrialNo = from.TrialNo,
                    Employee = Map(from.Employee),
                    Template = Map(from.Template),
                    Status = Map(from.Status)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Employees_Templates Map(Data.Domain.Employees_Templates from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new Employees_Templates
                {
                    ID = from.ID,
                    EmployeeID = from.EmployeeID,
                    TemplateID = from.TemplateID,
                    Score = from.Score,
                    TimeTaken = from.TimeTaken,
                    TrialNo = from.TrialNo,
                    Employee = Map(from.Employee),
                    Template = Map(from.Template),
                    Status = Map(from.Status)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region Question

        public static Data.Domain.Question Map(Question from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new Data.Domain.Question
                {
                    ID = from.ID,
                    CreationDate = from.CreationDate,
                    Hint = from.Hint,
                    IsActive = from.IsActive,
                    IsDeleted = from.IsDeleted,
                    IsUsed = from.IsUsed,
                    Text = from.Text,
                    TopicID = from.TopicID,
                    Topic = Map(from.Topic),
                    Answers = Map(from.Answers),
                    Employees_Questions_Templates = Map(from.Employees_Questions_Templates),
                    Questions_Quizes = Map(from.Questions_Quizes),
                    Questions_Templates = Map(from.Questions_Templates)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Question Map(Data.Domain.Question from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new Question
                {
                    ID = from.ID,
                    CreationDate = from.CreationDate,
                    Hint = from.Hint,
                    IsActive = from.IsActive,
                    IsDeleted = from.IsDeleted,
                    IsUsed = from.IsUsed,
                    Text = from.Text,
                    TopicID = from.TopicID,
                    Topic = Map(from.Topic),
                    Answers = Map(from.Answers),
                    Employees_Questions_Templates = Map(from.Employees_Questions_Templates),
                    Questions_Quizes = Map(from.Questions_Quizes),
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

        #region QuestionQuizes

        #endregion

        #region QuestionTemplate

        #endregion

        #region Quiz

        #endregion

        #region Template

        #endregion

        #region Answer

        #endregion


        // mapping lists
        #region TopicsList

        public static ICollection<Data.Domain.Topic> Map(ICollection<Topic> from)
        {
            try
            {
                if (from == null && from.Count == 0)
                    return null;

                var to = new List<Data.Domain.Topic>();

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

        public static ICollection<Topic> Map(ICollection<Data.Domain.Topic> from)
        {
            try
            {
                if (from == null && from.Count == 0)
                    return null;

                var to = new List<Topic>();

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

        #region EmployeesList

        public static ICollection<Data.Domain.Employee> Map(ICollection<Employee> from)
        {
            try
            {
                if (from == null && from.Count == 0)
                    return null;

                var to = new List<Data.Domain.Employee>();

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

        public static ICollection<Employee> Map(ICollection<Data.Domain.Employee> from)
        {
            try
            {
                if (from == null && from.Count == 0)
                    return null;

                var to = new List<Employee>();

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

        #region EmployeesQuestionsTemplatesList

        public static ICollection<Data.Domain.Employees_Questions_Templates> Map(ICollection<Employees_Questions_Templates> from)
        {
            try
            {
                if (from == null && from.Count == 0)
                    return null;

                var to = new List<Data.Domain.Employees_Questions_Templates>();

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

        public static ICollection<Employees_Questions_Templates> Map(ICollection<Data.Domain.Employees_Questions_Templates> from)
        {
            try
            {
                if (from == null && from.Count == 0)
                    return null;

                var to = new List<Employees_Questions_Templates>();

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

        #region EmployeesTemplatesList

        public static ICollection<Data.Domain.Employees_Templates> Map(ICollection<Employees_Templates> from)
        {
            try
            {
                if (from == null && from.Count == 0)
                    return null;

                var to = new List<Data.Domain.Employees_Templates>();

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

        public static ICollection<Employees_Templates> Map(ICollection<Data.Domain.Employees_Templates> from)
        {
            try
            {
                if (from == null && from.Count == 0)
                    return null;

                var to = new List<Employees_Templates>();

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

        #region QuestionsList

        public static ICollection<Data.Domain.Question> Map(ICollection<Question> from)
        {
            try
            {
                if (from == null && from.Count == 0)
                    return null;

                var to = new List<Data.Domain.Question>();

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

        public static ICollection<Question> Map(ICollection<Data.Domain.Question> from)
        {
            try
            {
                if (from == null && from.Count == 0)
                    return null;

                var to = new List<Question>();

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