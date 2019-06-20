﻿using Linkdev.Intern.EQuiz.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkdev.Intern.EQuiz.Service.Interfaces
{
    public interface ITemplateService
    {
        bool? CreateEmptyTemplateToAssignedEmployee(Quiz quiz, Employee employee);
        bool? EmployeeTakeTemplate(int employeeID, int quizID, int templateID);
    }
}
