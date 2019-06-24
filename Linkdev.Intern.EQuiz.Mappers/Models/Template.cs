namespace Linkdev.Intern.EQuiz.Shared
{
    using System;
    using System.Collections.Generic;

    public class Template
    {
        public int ID { get; set; }

        public int QuizID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<Employees_Questions_Templates> Employees_Questions_Templates { get; set; }

        public virtual ICollection<Employees_Templates> Employees_Templates { get; set; }

        public virtual ICollection<Questions_Templates> Questions_Templates { get; set; }

        public virtual Quiz Quiz { get; set; }
    }
}
