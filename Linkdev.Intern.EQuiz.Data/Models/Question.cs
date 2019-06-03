namespace Linkdev.Intern.EQuiz.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {
            Answers = new HashSet<Answer>();
            Employees_Questions_Templates = new HashSet<Employees_Questions_Templates>();
            Questions_Templates = new HashSet<Questions_Templates>();
        }

        public int ID { get; set; }

        public int TopicID { get; set; }

        [Required]
        [StringLength(500)]
        public string Text { get; set; }

        public DateTime CreationDate { get; set; }

        [StringLength(150)]
        public string Hint { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }

        public bool IsUsed { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employees_Questions_Templates> Employees_Questions_Templates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Questions_Templates> Questions_Templates { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
