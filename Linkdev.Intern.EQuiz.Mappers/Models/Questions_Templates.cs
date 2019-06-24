namespace Linkdev.Intern.EQuiz.Shared
{
    public class Questions_Templates
    {
        public int ID { get; set; }

        public int QuestionID { get; set; }

        public int TemplateID { get; set; }

        public virtual Question Question { get; set; }

        public virtual Template Template { get; set; }
    }
}
