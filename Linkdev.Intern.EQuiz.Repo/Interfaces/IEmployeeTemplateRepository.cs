﻿using Linkdev.Intern.EQuiz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkdev.Intern.EQuiz.Repo.Interfaces
{
    public interface IEmployeeTemplateRepository : IRepository<Employees_Templates>
    {
        IEnumerable<Employees_Templates> GetEmployeesTemplatesByQuestionId(int qid);

        bool? AssignEmployeesToQuiz(int id, ICollection<Employee> employees);

        bool? ReleaseQuizFromEmployees(int id, ICollection<Employee> employees);

        bool? AssignEmployeesToReTakeQuiz(int id, ICollection<Employee> employees);
    }
}
