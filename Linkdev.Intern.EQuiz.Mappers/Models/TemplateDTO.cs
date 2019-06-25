namespace Linkdev.Intern.EQuiz.Shared
{
    using System;
    using System.Collections.Generic;

    public class TemplateDTO
    {
        public int ID { get; set; }

        public int QuizID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual EmployeeDTO Employee { get; set; }

        public virtual ICollection<Employees_Questions_TemplatesDTO> Employees_Questions_Templates { get; set; }

        public virtual ICollection<Employees_TemplatesDTO> Employees_Templates { get; set; }

        public virtual ICollection<Questions_TemplatesDTO> Questions_Templates { get; set; }

        public virtual QuizDTO Quiz { get; set; }
    }
}
