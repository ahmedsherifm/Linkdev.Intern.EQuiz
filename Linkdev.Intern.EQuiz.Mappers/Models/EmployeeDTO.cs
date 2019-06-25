using System.Collections.Generic;

namespace Linkdev.Intern.EQuiz.Shared
{
    public class EmployeeDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string DepartmentName { get; set; }

        public virtual ICollection<Employees_Questions_TemplatesDTO> Employees_Questions_Templates { get; set; }

        public virtual ICollection<TemplateDTO> Templates { get; set; }

        public virtual ICollection<Employees_TemplatesDTO> Employees_Templates { get; set; }
    }
}
