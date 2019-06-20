using Linkdev.Intern.EQuiz.Mappers;
using Linkdev.Intern.EQuiz.Repo.UnitOfWork;
using Linkdev.Intern.EQuiz.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Service.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly IUnitOfWork UnitOfWork;

        public TemplateService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public TemplateService()
        {
            UnitOfWork = new UnitOfWork(new Data.EQuizContext());
        }

        private Template CreateTemplate(Quiz quiz, Employee employee)
        {
            var dtoQuiz = DTOMapper.Mapper.Map<Quiz, Data.Quiz>(quiz);
            var dtoEmployee = DTOMapper.Mapper.Map<Employee, Data.Employee>(employee);
            var dtoTemplate = new Data.Template()
            {
                Quiz = dtoQuiz,
                CreationDate = DateTime.Now,
                Employee = dtoEmployee
            };
            UnitOfWork.TemplateRepository.Add(dtoTemplate);
            UnitOfWork.SaveChanges();
            var template = DTOMapper.Mapper.Map<Data.Template, Template>(dtoTemplate);

            return template;
        }

        /// why there is list of employeestemplates between both entities, why there is many between employeees and templates
        /// 

        private void AssignEmployeeToTemplate(Template template,Employee employee)
        {
            var dtoTemplate = DTOMapper.Mapper.Map<Template, Data.Template>(template);
            dtoTemplate.Employees_Templates.Add(new Data.Employees_Templates()
            {
                Employee = DTOMapper.Mapper.Map<Employee, Data.Employee>(employee),
                Template = dtoTemplate,
                TrialNo = 0,
                Score = 0,
                Status = Data.EmployeeTemplateStatus.Assigned
            });
        }
        
        public bool? CreateEmptyTemplateToAssignedEmployee (Quiz quiz,Employee employee)
        {
            if (quiz != null && employee != null)
            {
                var template = CreateTemplate(quiz, employee);
                AssignEmployeeToTemplate(template, employee);
                UnitOfWork.SaveChanges();

                return true;
            }
            else
                return false;
        }

        private bool? AddQuestionsToQuestionsTemplates(Template template, Quiz quiz)
        {
            if (template != null && quiz != null)
            {
                ICollection<Questions_Templates> questions_Templates = new List<Questions_Templates>();
                var dtoTemplate = DTOMapper.Mapper.Map<Template, Data.Template>(template);
                var random = new Random();
                var dtoQuiz = DTOMapper.Mapper.Map<Quiz, Data.Quiz>(quiz);
                var questionsList = UnitOfWork.QuestionQuizRepository.GetQuizQuestions(dtoQuiz).ToList();
                var questionsNumber = quiz.QuestionsNumber;

                while (questions_Templates.Count != questionsNumber)
                {
                    int index = random.Next(questionsList.Count);
                    var question = questionsList[index];
                    if (!questions_Templates.Any(q => q.QuestionID == question.ID))
                    {
                        questions_Templates.Add(new Questions_Templates()
                        {
                            QuestionID = question.ID,
                            TemplateID = dtoTemplate.ID,
                        });
                    }
                }

                var dtoQuestions_Templates = DTOMapper.Mapper.Map<ICollection<Questions_Templates>, ICollection<Data.Questions_Templates>>(questions_Templates);
                dtoTemplate.Questions_Templates = dtoQuestions_Templates;

                return true;
            }
            else
                return false;
        }

        private bool? ChangeEmployeeTemplateStatus(EmployeeTemplateStatus newStatus,int templateID,int employeeID)
        {
            var dtoStatus = DTOMapper.Mapper.Map<EmployeeTemplateStatus, Data.EmployeeTemplateStatus>(newStatus);
            return UnitOfWork.EmployeeTemplateRepository.ChangeEmployeeTemplateStatus(dtoStatus, templateID, employeeID);

        }

        public EmployeeTemplateStatus CheckEmployeeTemplateStatus(int templateID, int employeeID)
        {
            var status = UnitOfWork.EmployeeTemplateRepository.CheckTemplateStatusForEmployee(templateID, employeeID);
            
            return DTOMapper.Mapper.Map<Data.EmployeeTemplateStatus, EmployeeTemplateStatus>(status);

        }

        public bool? EmployeeTakeTemplate(int employeeID,int quizID,int templateID)
        {
            var dtoEmployee = UnitOfWork.EmployeeRepository.GetByID(employeeID);
            var dtoQuiz = UnitOfWork.QuizRepository.GetByID(quizID);
            var dtoTemplate = UnitOfWork.TemplateRepository.GetByID(templateID);

            if (dtoEmployee != null && dtoQuiz != null && dtoTemplate != null)
            {
                var employee = DTOMapper.Mapper.Map<Data.Employee, Employee>(dtoEmployee);
                var quiz = DTOMapper.Mapper.Map<Data.Quiz, Quiz>(dtoQuiz);
                var template = DTOMapper.Mapper.Map<Data.Template, Template>(dtoTemplate);

                var dtoStatus = UnitOfWork.EmployeeTemplateRepository.CheckTemplateStatusForEmployee(templateID, employeeID);
                var status = DTOMapper.Mapper.Map<Data.EmployeeTemplateStatus, EmployeeTemplateStatus>(dtoStatus);

                if (status == EmployeeTemplateStatus.Assigned)
                {
                    ChangeEmployeeTemplateStatus(EmployeeTemplateStatus.InProgress, employeeID, templateID);
                    AddQuestionsToQuestionsTemplates(template, quiz);
                    UnitOfWork.SaveChanges();

                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}