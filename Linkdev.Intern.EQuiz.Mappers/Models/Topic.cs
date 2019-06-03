namespace Linkdev.Intern.EQuiz.Mappers
{
    using System;
    public class Topic
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        
        public DateTime CreationDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
