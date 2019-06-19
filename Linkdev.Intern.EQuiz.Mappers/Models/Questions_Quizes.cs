using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Mappers
{
    public class Questions_Quizes
    {
        public int ID { get; set; }

        public int QuestionID { get; set; }

        public int QuizID { get; set; }

        public virtual Question Question { get; set; }

        public virtual Quiz Quiz { get; set; }
    }
}