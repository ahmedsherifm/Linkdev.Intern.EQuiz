namespace Linkdev.Intern.EQuiz.Data.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    public partial class Answer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Answer()
        {
            Employees_Questions_Templates = new HashSet<Employees_Questions_Templates>();
        }

        public int ID { get; set; }

        public int QuestionID { get; set; }

        [Required]
        [StringLength(500)]
        public string Text { get; set; }

        public bool IsCorrect { get; set; }

        public bool IsDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employees_Questions_Templates> Employees_Questions_Templates { get; set; }

        public virtual Question Question { get; set; }
    }
}
