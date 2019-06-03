namespace Linkdev.Intern.EQuiz.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Quiz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quiz()
        {
            Templates = new HashSet<Template>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public int PassingScore { get; set; }

        public DateTime ActivationDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public int? NumberOfTrials { get; set; }

        public int Year { get; set; }

        public int Quarter { get; set; }

        public int? Timeout { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Template> Templates { get; set; }
    }
}
