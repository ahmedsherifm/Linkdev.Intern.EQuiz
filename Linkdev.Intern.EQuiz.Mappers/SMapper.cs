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

        #endregion

        #region QuestionTemplate

        #endregion

        #region Quiz

        #endregion

        #region Template

        #endregion

        #region Answer

        #endregion
    }
}