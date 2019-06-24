using System.Collections.Generic;

namespace Linkdev.Intern.EQuiz.Shared
{
    public class Answer
    {
        public int ID { get; set; }

        public int QuestionID { get; set; }

        public string Text { get; set; }

        public bool IsCorrect { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Employees_Questions_Templates> Employees_Questions_Templates { get; set; }

        public virtual Question Question { get; set; }
    }
}
