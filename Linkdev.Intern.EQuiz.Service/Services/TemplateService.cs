﻿using Linkdev.Intern.EQuiz.Shared;
using Linkdev.Intern.EQuiz.Data.Repository.UnitOfWork;
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
            UnitOfWork = new UnitOfWork(new Data.EntityFrameWork.EQuizContext());
        }

        private TemplateDTO CreateTemplate(int quizId, int employeeId)
        {
            var dtoQuiz = UnitOfWork.QuizRepository.GetByID(quizId);
            var dtoEmployee = UnitOfWork.EmployeeRepository.GetByID(employeeId);

            if (dtoQuiz != null && dtoEmployee != null)
            {
                var dtoTemplate = new Data.Domain.Template()
                {
                    Quiz = dtoQuiz,
                    CreationDate = DateTime.Now,
                    Employee = dtoEmployee
                };
                UnitOfWork.TemplateRepository.Add(dtoTemplate);
                UnitOfWork.SaveChanges();
                var template = SMapper.Map(dtoTemplate);

                return template;
            }

            return null;
        }

        private void AssignEmployeeToTemplate(int templateId)
        {
            var dtoTemplate = UnitOfWork.TemplateRepository.GetByID(templateId);
            dtoTemplate.Employees_Templates.Add(new Data.Domain.Employees_Templates()
            {
                EmployeeID = dtoTemplate.EmployeeID,
                TemplateID = dtoTemplate.ID,
                TrialNo = 0,
                Score = 0,
                Status = Data.Domain.EmployeeTemplateStatus.Assigned
            });

            //dtoTemplate.Employees_Templates = DTOMapper.Mapper.Map<ICollection<Employees_Templates>, ICollection<Data.Domain.Employees_Templates>>(employees_Templates);
        }


        public bool? CreateEmptyTemplateToAssignedEmployee(int quizId, int employeeId)
        {
            var template = CreateTemplate(quizId, employeeId);
            if (template != null)
            {
                var trialsNo = UnitOfWork.QuizRepository.GetTrialsNoForEmployee(quizId, employeeId);
                var quiz = UnitOfWork.QuizRepository.GetByID(quizId);

                if (trialsNo < quiz.NumberOfTrials)
                {

                    AssignEmployeeToTemplate(template.ID);
                    UnitOfWork.SaveChanges();
                }
                return true;
            }
            else
                return false;
        }


        //private ICollection<Template> CreateTemplateList(int quizId, ICollection<int> employeeIds)
        //{
        //    var dtoQuiz = UnitOfWork.QuizRepository.GetByID(quizId);
        //    if (dtoQuiz != null && employeeIds.Count > 0)
        //    {
        //        var employeesList = employeeIds.ToList();
        //        ICollection<Template> templates = new List<Template>();

        //        for (int i = 0; i < employeeIds.Count; i++)
        //        {
        //            var dtoEmployee = UnitOfWork.EmployeeRepository.GetByID(employeesList[i]);

        //            if (dtoEmployee != null)
        //            {
        //                var dtoTemplate = new Data.Domain.Template()
        //                {
        //                    Quiz = dtoQuiz,
        //                    CreationDate = DateTime.Now,
        //                    Employee = dtoEmployee
        //                };

        //                UnitOfWork.TemplateRepository.Add(dtoTemplate);
        //                var template = DTOMapper.Mapper.Map<Data.Domain.Template, Template>(dtoTemplate);
        //                templates.Add(template);
        //            }
        //            else
        //                return null;
        //        }

        //        UnitOfWork.SaveChanges();
        //        return templates;
        //    }
        //    else
        //        return null;
        //}

        //private void AssignEmployeesToTemplatesList(ICollection<Template> templates)
        //{
        //    var templatesList = templates.ToList();
        //    for (int i = 0; i < templates.Count; i++)
        //    {
        //        var dtoTemplate = UnitOfWork.TemplateRepository.GetByID(templatesList[i].ID);
        //        dtoTemplate.Employees_Templates.Add(new Data.Domain.Employees_Templates()
        //        {
        //            EmployeeID = dtoTemplate.EmployeeID,
        //            TemplateID = dtoTemplate.ID,
        //            TrialNo = 0,
        //            Score = 0,
        //            Status = Data.Domain.EmployeeTemplateStatus.Assigned
        //        });
        //    }
        //}

        public ICollection<bool> CreateEmptyTemplatesToAssignedEmployees(int quizId, ICollection<int> employeeIds)
        {
            if(employeeIds != null)
            {
                var empResults = new List<bool>();
                foreach (var item in employeeIds)
                {
                    var result = (bool)CreateEmptyTemplateToAssignedEmployee(quizId, item);
                    empResults.Add(result);
                }           
                return empResults;
            }
            return null;
        }

        private bool? AddQuestionsToQuestionsTemplates(int templateId, int quizId)
        {
            var dtoTemplate = UnitOfWork.TemplateRepository.GetByID(templateId);
            var dtoQuiz = UnitOfWork.QuizRepository.GetByID(quizId);
            if (dtoTemplate != null && dtoQuiz != null)
            {
                ICollection<Questions_TemplatesDTO> questions_Templates = new List<Questions_TemplatesDTO>();
                var random = new Random();
                var questionsList = UnitOfWork.QuestionQuizRepository.GetQuizQuestions(dtoQuiz).ToList();
                var questionsNumber = dtoQuiz.QuestionsNumber;

                while (questions_Templates.Count != questionsNumber)
                {
                    int index = random.Next(questionsList.Count);
                    var question = questionsList[index];
                    if (!questions_Templates.Any(q => q.QuestionID == question.ID))
                    {
                        question.IsActive = true;
                        questions_Templates.Add(new Questions_TemplatesDTO()
                        {
                            QuestionID = question.ID,
                            TemplateID = dtoTemplate.ID,
                        });
                    }
                }

                var dtoQuestions_Templates = SMapper.Map(questions_Templates);
                dtoTemplate.Questions_Templates = dtoQuestions_Templates;

                return true;
            }
            else
                return false;
        }

        private bool? ChangeEmployeeTemplateStatus(EmployeeTemplateStatusDTO newStatus, int templateID, int employeeID)
        {
            var dtoStatus = SMapper.Map(newStatus);
            return UnitOfWork.EmployeeTemplateRepository.ChangeEmployeeTemplateStatus(dtoStatus, templateID, employeeID);
        }

        public EmployeeTemplateStatusDTO CheckEmployeeTemplateStatus(int templateID, int employeeID)
        {
            var status = UnitOfWork.EmployeeTemplateRepository.CheckTemplateStatusForEmployee(templateID, employeeID);

            return SMapper.Map(status);
        }

        public bool? EmployeeTakeTemplate(int employeeID, int quizID, int templateID)
        {
            var dtoEmployee = UnitOfWork.EmployeeRepository.GetByID(employeeID);
            var dtoQuiz = UnitOfWork.QuizRepository.GetByID(quizID);
            var dtoTemplate = UnitOfWork.TemplateRepository.GetByID(templateID);

            if (dtoEmployee != null && dtoQuiz != null && dtoTemplate != null)
            {
                var dtoStatus = UnitOfWork.EmployeeTemplateRepository.CheckTemplateStatusForEmployee(templateID, employeeID);
                var status = SMapper.Map(dtoStatus);

                if (status == EmployeeTemplateStatusDTO.Assigned)
                {
                    ChangeEmployeeTemplateStatus(EmployeeTemplateStatusDTO.InProgress, employeeID, templateID);
                    AddQuestionsToQuestionsTemplates(templateID, quizID);
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