namespace Linkdev.Intern.EQuiz.Mappers
{
    using System;

    public class Quiz
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public int PassingScore { get; set; }

        public DateTime ActivationDate { get; set; }


        public int? NumberOfTrials { get; set; }

        public int Year { get; set; }

        public int Quarter { get; set; }

        public int? Timeout { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public int QuestionsNumber { get; set; }

    }
}
