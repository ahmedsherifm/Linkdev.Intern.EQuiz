using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Mappers.Criteria
{
    public enum OrderType
    {
        Name, CreationDate, IsDeleted
    }

    public class TopicCriteria : BaseCriteria
    {
        public int? ID { get; set; }

        public string Name { get; set; }

        public DateTime? CreationDate { get; set; }

        public bool? IsDeleted { get; set; }

        public OrderType? OrderType { get; set; }
    }
}