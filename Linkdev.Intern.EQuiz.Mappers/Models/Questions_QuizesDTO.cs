using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Shared
{
    public class Questions_QuizesDTO
    {
        public int ID { get; set; }

        public int QuestionID { get; set; }

        public int QuizID { get; set; }

        public virtual QuestionDTO Question { get; set; }

        public virtual QuizDTO Quiz { get; set; }
    }
}