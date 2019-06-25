using System.Collections.Generic;

namespace Linkdev.Intern.EQuiz.Shared
{
    public class AnswerDTO
    {
        public int ID { get; set; }

        public int QuestionID { get; set; }

        public string Text { get; set; }

        public bool IsCorrect { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Employees_Questions_TemplatesDTO> Employees_Questions_Templates { get; set; }

        public virtual QuestionDTO Question { get; set; }
    }
}
