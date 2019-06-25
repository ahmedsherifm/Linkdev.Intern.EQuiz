namespace Linkdev.Intern.EQuiz.Shared
{
    using System;
    using System.Collections.Generic;

    public class TopicDTO
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        
        public DateTime CreationDate { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<QuestionDTO> Questions { get; set; }
    }
}
