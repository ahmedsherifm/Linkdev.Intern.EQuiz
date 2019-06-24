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

        #region EmployeeTemplateStatus

        public static Data.Domain.EmployeeTemplateStatus Map(EmployeeTemplateStatus from)
        {
            Data.Domain.EmployeeTemplateStatus to = new Data.Domain.EmployeeTemplateStatus();

            switch (from)
            {
                case EmployeeTemplateStatus.Assigned:
                    to = Data.Domain.EmployeeTemplateStatus.Assigned;
                    break;
                case EmployeeTemplateStatus.Failed:
                    to = Data.Domain.EmployeeTemplateStatus.Failed;
                    break;
                case EmployeeTemplateStatus.InProgress:
                    to = Data.Domain.EmployeeTemplateStatus.InProgress;
                    break;
                case EmployeeTemplateStatus.Missed:
                    to = Data.Domain.EmployeeTemplateStatus.Missed;
                    break;
                case EmployeeTemplateStatus.Released:
                    to = Data.Domain.EmployeeTemplateStatus.Released;
                    break;
                case EmployeeTemplateStatus.Submitted:
                    to = Data.Domain.EmployeeTemplateStatus.Submitted;
                    break;
                case EmployeeTemplateStatus.Successed:
                    to = Data.Domain.EmployeeTemplateStatus.Successed;
                    break;
            }

            return to;
        }

        public static EmployeeTemplateStatus Map(Data.Domain.EmployeeTemplateStatus from)
        {
            EmployeeTemplateStatus to = new EmployeeTemplateStatus();

            switch (from)
            {
                case Data.Domain.EmployeeTemplateStatus.Assigned:
                    to = EmployeeTemplateStatus.Assigned;
                    break;
                case Data.Domain.EmployeeTemplateStatus.Failed:
                    to = EmployeeTemplateStatus.Failed;
                    break;
                case Data.Domain.EmployeeTemplateStatus.InProgress:
                    to = EmployeeTemplateStatus.InProgress;
                    break;
                case Data.Domain.EmployeeTemplateStatus.Missed:
                    to = EmployeeTemplateStatus.Missed;
                    break;
                case Data.Domain.EmployeeTemplateStatus.Released:
                    to = EmployeeTemplateStatus.Released;
                    break;
                case Data.Domain.EmployeeTemplateStatus.Submitted:
                    to = EmployeeTemplateStatus.Submitted;
                    break;
                case Data.Domain.EmployeeTemplateStatus.Successed:
                    to = EmployeeTemplateStatus.Successed;
                    break;
            }

            return to;
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