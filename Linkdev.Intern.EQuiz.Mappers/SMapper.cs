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

        public static Data.Domain.Topic Map(TopicDTO from)
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

        public static TopicDTO Map(Data.Domain.Topic from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new TopicDTO
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

        public static Data.Domain.Employee Map(EmployeeDTO from)
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

        public static EmployeeDTO Map(Data.Domain.Employee from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new EmployeeDTO
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

        public static Data.Domain.Employees_Questions_Templates Map(Employees_Questions_TemplatesDTO from)
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
                    //Question = Map(from.Question),
                    //Employee = Map(from.Employee),
                    //Answer = Map(from.Answer),
                    //Template = Map(from.Template)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Employees_Questions_TemplatesDTO Map(Data.Domain.Employees_Questions_Templates from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new Employees_Questions_TemplatesDTO
                {
                    ID = from.ID,
                    QuestionID = from.QuestionID,
                    EmployeeID = from.EmployeeID,
                    AnswerID = from.AnswerID,
                    TemplateID = from.TemplateID,
                    //Question = Map(from.Question),
                    //Employee = Map(from.Employee),
                    //Answer = Map(from.Answer),
                    //Template = Map(from.Template)
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

        public static Data.Domain.Employees_Templates Map(Employees_TemplatesDTO from)
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
                    //Employee = Map(from.Employee),
                    //Template = Map(from.Template),
                    Status = Map(from.Status)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Employees_TemplatesDTO Map(Data.Domain.Employees_Templates from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new Employees_TemplatesDTO
                {
                    ID = from.ID,
                    EmployeeID = from.EmployeeID,
                    TemplateID = from.TemplateID,
                    Score = from.Score,
                    TimeTaken = from.TimeTaken,
                    TrialNo = from.TrialNo,
                    //Employee = Map(from.Employee),
                    //Template = Map(from.Template),
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

        public static Data.Domain.EmployeeTemplateStatus Map(EmployeeTemplateStatusDTO from)
        {
            Data.Domain.EmployeeTemplateStatus to = new Data.Domain.EmployeeTemplateStatus();

            switch (from)
            {
                case EmployeeTemplateStatusDTO.Assigned:
                    to = Data.Domain.EmployeeTemplateStatus.Assigned;
                    break;
                case EmployeeTemplateStatusDTO.Failed:
                    to = Data.Domain.EmployeeTemplateStatus.Failed;
                    break;
                case EmployeeTemplateStatusDTO.InProgress:
                    to = Data.Domain.EmployeeTemplateStatus.InProgress;
                    break;
                case EmployeeTemplateStatusDTO.Missed:
                    to = Data.Domain.EmployeeTemplateStatus.Missed;
                    break;
                case EmployeeTemplateStatusDTO.Released:
                    to = Data.Domain.EmployeeTemplateStatus.Released;
                    break;
                case EmployeeTemplateStatusDTO.Submitted:
                    to = Data.Domain.EmployeeTemplateStatus.Submitted;
                    break;
                case EmployeeTemplateStatusDTO.Successed:
                    to = Data.Domain.EmployeeTemplateStatus.Successed;
                    break;
            }

            return to;
        }

        public static EmployeeTemplateStatusDTO Map(Data.Domain.EmployeeTemplateStatus from)
        {
            EmployeeTemplateStatusDTO to = new EmployeeTemplateStatusDTO();

            switch (from)
            {
                case Data.Domain.EmployeeTemplateStatus.Assigned:
                    to = EmployeeTemplateStatusDTO.Assigned;
                    break;
                case Data.Domain.EmployeeTemplateStatus.Failed:
                    to = EmployeeTemplateStatusDTO.Failed;
                    break;
                case Data.Domain.EmployeeTemplateStatus.InProgress:
                    to = EmployeeTemplateStatusDTO.InProgress;
                    break;
                case Data.Domain.EmployeeTemplateStatus.Missed:
                    to = EmployeeTemplateStatusDTO.Missed;
                    break;
                case Data.Domain.EmployeeTemplateStatus.Released:
                    to = EmployeeTemplateStatusDTO.Released;
                    break;
                case Data.Domain.EmployeeTemplateStatus.Submitted:
                    to = EmployeeTemplateStatusDTO.Submitted;
                    break;
                case Data.Domain.EmployeeTemplateStatus.Successed:
                    to = EmployeeTemplateStatusDTO.Successed;
                    break;
            }

            return to;
        }

        #endregion

        #region Question

        public static Data.Domain.Question Map(QuestionDTO from)
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
                    //Topic = Map(from.Topic),
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

        public static QuestionDTO Map(Data.Domain.Question from)
        {
            try
            {
                if (from == null)
                    return null;

                var to = new QuestionDTO
                {
                    ID = from.ID,
                    CreationDate = from.CreationDate,
                    Hint = from.Hint,
                    IsActive = from.IsActive,
                    IsDeleted = from.IsDeleted,
                    IsUsed = from.IsUsed,
                    Text = from.Text,
                    TopicID = from.TopicID,
                    //Topic = Map(from.Topic),
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
        public static Questions_QuizesDTO Map(Data.Domain.Questions_Quizes from)
        {
            try
            {
                if (from != null)
                    return null;

                var to = new Questions_QuizesDTO
                {
                    ID = from.ID,
                    QuestionID = from.QuestionID,
                    QuizID = from.QuizID,
                    //Question = Map(from.Question),
                    //Quiz = Map(from.Quiz)
                };

                return to;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public static Data.Domain.Questions_Quizes Map(Questions_QuizesDTO from)
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
                    //Question = Map(from.Question),
                    //Quiz = Map(from.Quiz)
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

        public static Questions_TemplatesDTO Map(Data.Domain.Questions_Templates from)
        {
            try
            {
                if (from != null)
                    return null;

                var to = new Questions_TemplatesDTO
                {
                    ID = from.ID,
                    QuestionID = from.QuestionID,
                    TemplateID = from.TemplateID,
                    //Question = Map(from.Question),
                    //Template = Map(from.Template)
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Data.Domain.Questions_Templates Map(Questions_TemplatesDTO from)
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
                    //Question = Map(from.Question),
                    //Template = Map(from.Template)
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

        public static QuizDTO Map(Data.Domain.Quize from)
        {
            try
            {
                if (from != null)
                    return null;

                var to = new QuizDTO
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

        public static Data.Domain.Quize Map(QuizDTO from)
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

        public static TemplateDTO Map(Data.Domain.Template from)
        {
            try
            {
                if (from != null)
                    return null;

                var to = new TemplateDTO
                {
                     ID = from.ID,
                     CreationDate = from.CreationDate,
                     EmployeeID = from.EmployeeID,
                     QuizID = from.QuizID,
                     //Employee = Map(from.Employee),
                     //Quiz = Map(from.Quiz),
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

        public static Data.Domain.Template Map(TemplateDTO from)
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
                    //Employee = Map(from.Employee),
                    //Quiz = Map(from.Quiz),
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

        public static AnswerDTO Map(Data.Domain.Answer from)
        {
            try
            {
                if (from != null)
                    return null;

                var to = new AnswerDTO
                {
                    ID = from.ID,
                    IsCorrect = from.IsCorrect,
                    IsDeleted = from.IsDeleted,
                    Text = from.Text,
                    QuestionID = from.QuestionID,
                    //Question = Map(from.Question),
                    Employees_Questions_Templates = Map(from.Employees_Questions_Templates),
                };

                return to;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Data.Domain.Answer Map(AnswerDTO from)
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
                    //Question = Map(from.Question),
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
        public static ICollection<Questions_QuizesDTO> Map(ICollection<Data.Domain.Questions_Quizes> from)
        {
            try
            {
                if (from != null && from.Count > 0)
                    return null;

                var to = new List<Questions_QuizesDTO>();

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

        public static ICollection<Data.Domain.Questions_Quizes> Map(ICollection<Questions_QuizesDTO> from)
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

        public static ICollection<Questions_TemplatesDTO> Map(ICollection<Data.Domain.Questions_Templates> from)
        {
            try
            {
                if (from != null && from.Count > 0)
                    return null;

                var to = new List<Questions_TemplatesDTO>();

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

        public static ICollection<Data.Domain.Questions_Templates> Map(ICollection<Questions_TemplatesDTO> from)
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
        public static ICollection<QuizDTO> Map(ICollection<Data.Domain.Quize> from)
        {
            try
            {
                if (from != null && from.Count > 0)
                    return null;

                var to = new List<QuizDTO>();

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

        public static ICollection<Data.Domain.Quize> Map(ICollection<QuizDTO> from)
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
        public static ICollection<TemplateDTO> Map(ICollection<Data.Domain.Template> from)
        {
            try
            {
                if (from != null && from.Count > 0)
                    return null;

                var to = new List<TemplateDTO>();

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

        public static ICollection<Data.Domain.Template> Map(ICollection<TemplateDTO> from)
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

        public static ICollection<AnswerDTO> Map(ICollection<Data.Domain.Answer> from)
        {
            try
            {
                if (from != null && from.Count > 0)
                    return null;

                var to = new List<AnswerDTO>();

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

        public static ICollection<Data.Domain.Answer> Map(ICollection<AnswerDTO> from)
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

        public static ICollection<Data.Domain.Topic> Map(ICollection<TopicDTO> from)
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

        public static ICollection<TopicDTO> Map(ICollection<Data.Domain.Topic> from)
        {
            try
            {
                if (from == null && from.Count == 0)
                    return null;

                var to = new List<TopicDTO>();

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

        public static ICollection<Data.Domain.Employee> Map(ICollection<EmployeeDTO> from)
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

        public static ICollection<EmployeeDTO> Map(ICollection<Data.Domain.Employee> from)
        {
            try
            {
                if (from == null && from.Count == 0)
                    return null;

                var to = new List<EmployeeDTO>();

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

        public static ICollection<Data.Domain.Employees_Questions_Templates> Map(ICollection<Employees_Questions_TemplatesDTO> from)
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

        public static ICollection<Employees_Questions_TemplatesDTO> Map(ICollection<Data.Domain.Employees_Questions_Templates> from)
        {
            try
            {
                if (from == null && from.Count == 0)
                    return null;

                var to = new List<Employees_Questions_TemplatesDTO>();

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

        public static ICollection<Data.Domain.Employees_Templates> Map(ICollection<Employees_TemplatesDTO> from)
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

        public static ICollection<Employees_TemplatesDTO> Map(ICollection<Data.Domain.Employees_Templates> from)
        {
            try
            {
                if (from == null && from.Count == 0)
                    return null;

                var to = new List<Employees_TemplatesDTO>();

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

        public static ICollection<Data.Domain.Question> Map(ICollection<QuestionDTO> from)
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

        public static ICollection<QuestionDTO> Map(ICollection<Data.Domain.Question> from)
        {
            try
            {
                if (from == null && from.Count == 0)
                    return null;

                var to = new List<QuestionDTO>();

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