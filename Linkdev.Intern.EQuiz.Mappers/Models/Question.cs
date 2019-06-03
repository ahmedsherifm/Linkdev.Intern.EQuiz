namespace Linkdev.Intern.EQuiz.Mappers
{
    using System;

    public class Question
    {
        public int ID { get; set; }

        public int TopicID { get; set; }

        public string Text { get; set; }

        public DateTime CreationDate { get; set; }

        public string Hint { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }

        public bool IsUsed { get; set; }
    }
}
