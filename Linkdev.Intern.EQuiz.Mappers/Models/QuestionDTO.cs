namespace Linkdev.Intern.EQuiz.Shared
{
    using System;
    using System.Collections.Generic;

    public class QuestionDTO
    {
        public int ID { get; set; }

        public int TopicID { get; set; }

        public string Text { get; set; }

        public DateTime CreationDate { get; set; }

        public string Hint { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }

        public bool IsUsed { get; set; }

        public virtual ICollection<AnswerDTO> Answers { get; set; }

        public virtual ICollection<Employees_Questions_TemplatesDTO> Employees_Questions_Templates { get; set; }

        public virtual ICollection<Questions_QuizesDTO> Questions_Quizes { get; set; }

        public virtual ICollection<Questions_TemplatesDTO> Questions_Templates { get; set; }

        public virtual TopicDTO Topic { get; set; }
    }
}
