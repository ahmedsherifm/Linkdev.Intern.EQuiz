namespace Linkdev.Intern.EQuiz.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Questions_Templates
    {
        public int ID { get; set; }

        public int QuestionID { get; set; }

        public int TemplateID { get; set; }

        public virtual Question Question { get; set; }

        public virtual Template Template { get; set; }
    }
}
