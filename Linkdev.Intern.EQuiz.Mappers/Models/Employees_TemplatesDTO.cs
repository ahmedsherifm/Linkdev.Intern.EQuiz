using System;

namespace Linkdev.Intern.EQuiz.Shared
{
    public enum EmployeeTemplateStatusDTO
    {
        Assigned, Missed, Successed, Failed, Submitted, InProgress, Released
    }

    public class Employees_TemplatesDTO
    {
        public int ID { get; set; }

        public int TemplateID { get; set; }

        public int EmployeeID { get; set; }

        public int TrialNo { get; set; }

        public int Score { get; set; }

        public EmployeeTemplateStatusDTO Status { get; set; }

        public int? TimeTaken { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public virtual EmployeeDTO Employee { get; set; }

        public virtual TemplateDTO Template { get; set; }

    }
}
