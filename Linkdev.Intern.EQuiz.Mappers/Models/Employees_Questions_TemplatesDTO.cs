namespace Linkdev.Intern.EQuiz.Shared
{
    public class Employees_Questions_TemplatesDTO
    {
        public int ID { get; set; }

        public int TemplateID { get; set; }

        public int QuestionID { get; set; }

        public int EmployeeID { get; set; }

        public int AnswerID { get; set; }

        public virtual AnswerDTO Answer { get; set; }

        public virtual EmployeeDTO Employee { get; set; }

        public virtual QuestionDTO Question { get; set; }

        public virtual TemplateDTO Template { get; set; }
    }
}
