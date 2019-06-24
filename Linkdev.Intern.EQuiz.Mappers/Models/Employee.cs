using System.Collections.Generic;

namespace Linkdev.Intern.EQuiz.Shared
{
    public class Employee
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string DepartmentName { get; set; }

        public virtual ICollection<Employees_Questions_Templates> Employees_Questions_Templates { get; set; }

        public virtual ICollection<Template> Templates { get; set; }

        public virtual ICollection<Employees_Templates> Employees_Templates { get; set; }
    }
}
