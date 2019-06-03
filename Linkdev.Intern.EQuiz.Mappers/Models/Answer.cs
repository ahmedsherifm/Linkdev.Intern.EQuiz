namespace Linkdev.Intern.EQuiz.Mappers
{
    public class Answer
    {
        public int ID { get; set; }

        public int QuestionID { get; set; }

        public string Text { get; set; }

        public bool IsCorrect { get; set; }

        public bool IsDeleted { get; set; }
    }
}
