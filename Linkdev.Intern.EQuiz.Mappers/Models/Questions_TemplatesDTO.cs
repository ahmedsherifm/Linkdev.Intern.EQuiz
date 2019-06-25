namespace Linkdev.Intern.EQuiz.Shared
{
    public class Questions_TemplatesDTO
    {
        public int ID { get; set; }

        public int QuestionID { get; set; }

        public int TemplateID { get; set; }

        public virtual QuestionDTO Question { get; set; }

        public virtual TemplateDTO Template { get; set; }
    }
}
