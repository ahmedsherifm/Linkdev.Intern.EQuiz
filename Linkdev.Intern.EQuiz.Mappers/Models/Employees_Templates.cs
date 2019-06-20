using System;

namespace Linkdev.Intern.EQuiz.Mappers
{
    public enum EmployeeTemplateStatus
    {
        Assigned, Missed, Successed, Failed, Submitted, InProgress
    }

    public class Employees_Templates
    {
        public int ID { get; set; }

        public int TemplateID { get; set; }

        public int EmployeeID { get; set; }

        public int TrialNo { get; set; }

        public int Score { get; set; }

        public EmployeeTemplateStatus Status { get; set; }

        public int? TimeTaken { get; set; }

        public DateTime? ExpirationDate { get; set; }

    }
}
