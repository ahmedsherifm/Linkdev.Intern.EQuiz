namespace Linkdev.Intern.EQuiz.Data.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    public partial class Employees_Questions_Templates
    {
        public int ID { get; set; }

        public int TemplateID { get; set; }

        public int QuestionID { get; set; }

        public int EmployeeID { get; set; }

        public int AnswerID { get; set; }

        public virtual Answer Answer { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Question Question { get; set; }

        public virtual Template Template { get; set; }
    }
}
