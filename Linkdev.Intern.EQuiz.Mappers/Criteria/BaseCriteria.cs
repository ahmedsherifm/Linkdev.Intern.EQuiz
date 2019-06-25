using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Mappers.Criteria
{
    public enum OrderDirection
    {
        Ascending, Desending
    }
    public class BaseCriteria
    {
        public int? PageIndex { get; set; }

        public int? PageSize { get; set; }

        public OrderDirection? OrderDirection { get; set; }
    }
}