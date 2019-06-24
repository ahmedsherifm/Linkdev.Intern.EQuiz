namespace Linkdev.Intern.EQuiz.Shared
{
    using System;
    using System.Collections.Generic;

    public class Topic
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        
        public DateTime CreationDate { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
