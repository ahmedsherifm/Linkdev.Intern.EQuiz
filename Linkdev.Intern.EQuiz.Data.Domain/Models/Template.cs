namespace Linkdev.Intern.EQuiz.Data.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    public partial class Template
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Template()
        {
            Employees_Questions_Templates = new HashSet<Employees_Questions_Templates>();
            Employees_Templates = new HashSet<Employees_Templates>();
            Questions_Templates = new HashSet<Questions_Templates>();
        }

        public int ID { get; set; }

        public int QuizID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employees_Questions_Templates> Employees_Questions_Templates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employees_Templates> Employees_Templates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Questions_Templates> Questions_Templates { get; set; }

        public virtual Quize Quiz { get; set; }
    }
}
