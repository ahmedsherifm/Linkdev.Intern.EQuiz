namespace Linkdev.Intern.EQuiz.Shared
{
    using System;
    using System.Collections.Generic;

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

        public virtual ICollection<Answer> Answers { get; set; }

        public virtual ICollection<Employees_Questions_Templates> Employees_Questions_Templates { get; set; }

        public virtual ICollection<Questions_Quizes> Questions_Quizes { get; set; }

        public virtual ICollection<Questions_Templates> Questions_Templates { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
