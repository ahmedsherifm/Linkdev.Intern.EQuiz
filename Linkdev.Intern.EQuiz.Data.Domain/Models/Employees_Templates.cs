namespace Linkdev.Intern.EQuiz.Data.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;
    public enum EmployeeTemplateStatus
    {
        Assigned, Missed, Successed, Failed, Submitted, InProgress, Released
    }
    public partial class Employees_Templates
    {
        public int ID { get; set; }

        public int TemplateID { get; set; }

        public int EmployeeID { get; set; }

        public int TrialNo { get; set; }

        public int Score { get; set; }

        public EmployeeTemplateStatus Status { get; set; }

        public int? TimeTaken { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Template Template { get; set; }
    }
}
