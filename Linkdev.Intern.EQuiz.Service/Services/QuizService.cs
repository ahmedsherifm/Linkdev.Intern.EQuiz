using Linkdev.Intern.EQuiz.Shared;
using Linkdev.Intern.EQuiz.Data.Repository.UnitOfWork;
using Linkdev.Intern.EQuiz.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Service.Services
{
    public class QuizService : IQuizService
    {
        private readonly IUnitOfWork UnitOfWork;

        public QuizService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public QuizService()
        {
            UnitOfWork = new UnitOfWork(new Data.EntityFrameWork.EQuizContext());
        }

        public IEnumerable<Quiz> GetQuizesByQuestionID(int qid)
        {
            var dtoQuizes = UnitOfWork.QuizRepository.GetQuizesByQuestion(qid);
            return SMapper.Map(dtoQuizes.ToList());
        }

        public IEnumerable<Answer> GetQuizAnswers(int id)
        {
            var dtoAnswers = UnitOfWork.QuizRepository.GetQuizAnswers(id);
            return SMapper.Map(dtoAnswers.ToList());
        }

        public bool ExtendExpirationDate(int id, DateTime expirationDate)
        {
            var result = UnitOfWork.QuizRepository.ExtendExpirationDate(id, expirationDate);
            UnitOfWork.SaveChanges();

            return (bool)result;
        }

        public bool DeactivateQuiz(int id)
        {
            var result = UnitOfWork.QuizRepository.DeactivateQuiz(id);
            UnitOfWork.SaveChanges();

            return (bool)result;
        }

        public bool DeactivateQuizesList(ICollection<int> quizesIds)
        {
            if (quizesIds != null)
            {
                var result = UnitOfWork.QuizRepository.DeactivateQuizesList(quizesIds);
                UnitOfWork.SaveChanges();

                return (bool)result;
            }

            return false;
        }

        public bool ActivateQuiz(int id)
        {
            var result = UnitOfWork.QuizRepository.ActivateQuiz(id);
            UnitOfWork.SaveChanges();

            return (bool)result;
        }

        public bool UpdateNumberOfTrials(int id, int numberOfTrials)
        {
            var result = UnitOfWork.QuizRepository.UpdateNumberOfTrials(id, numberOfTrials);
            UnitOfWork.SaveChanges();

            return (bool)result;
        }

        public bool UpdatePassingScore(int id, int passingScore)
        {
            var result = UnitOfWork.QuizRepository.UpdatePassingScore(id, passingScore);
            UnitOfWork.SaveChanges();

            return (bool)result;
        }

        public bool ChangeQuizName(int id, string name)
        {
            var result = UnitOfWork.QuizRepository.ChangeQuizName(id, name);
            UnitOfWork.SaveChanges();

            return (bool)result;
        }

        public bool IsQuizActive(int id)
        {
            return (bool)UnitOfWork.QuizRepository.IsQuizActive(id);
        }

        public bool RemoveSelectedDeactivatedQuizesList(ICollection<int> quizesIds)
        {
            var result = UnitOfWork.QuizRepository.RemoveSelectedDeactivatedQuizesList(quizesIds);
            UnitOfWork.SaveChanges();

            return (bool)result;
        }

        public Quiz GetQuizByID(int id)
        {
            var dtoQuiz = UnitOfWork.QuizRepository.GetByID(id);
            return SMapper.Map(dtoQuiz);
        }

        public bool? CreateQuiz(Quiz quiz)
        {
            if (quiz != null)
            {
                var dtoQuiz = SMapper.Map(quiz);
                UnitOfWork.QuizRepository.Add(dtoQuiz);
                UnitOfWork.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool? AddQuestionsToQuiz(int quizId, IEnumerable<int> questionsIds)
        {
            var dtoQuiz = UnitOfWork.QuizRepository.GetByID(quizId);
            if (questionsIds != null && dtoQuiz != null)
            {
                //var dtoQuiz = DTOMapper.Mapper.Map<Quiz, Data.Domain.Quiz>(quiz);
                ICollection<Questions_Quizes> Questions_Quizes = new List<Questions_Quizes>();

                foreach (var item in questionsIds)
                {
                    var question = UnitOfWork.QuestionRepository.GetByID(item);
                    if (question != null)
                    {
                        question.IsUsed = true;
                        var QuestionQuiz = new Questions_Quizes() { QuizID = quizId, QuestionID = item };
                        Questions_Quizes.Add(QuestionQuiz);
                    }
                }

                var dtoQuestionQuizList = SMapper.Map(Questions_Quizes);
                dtoQuiz.Questions_Quizes = dtoQuestionQuizList;
                UnitOfWork.SaveChanges();

                return true;
            }
            else
                return false;
        }

        public ICollection<bool> ReleaseQuizFromEmployees(int quizId, ICollection<int> employeesIds)
        {
            if (employeesIds != null)
            {
                ICollection<bool> empResults = new List<bool>();

                foreach (var empId in employeesIds)
                {
                    var result = ReleaseQuizFromEmployee(quizId, empId);
                    empResults.Add(result);
                }

                return empResults;
            }

            return null;
        }

        public bool ReleaseQuizFromEmployee(int quizId, int employeeId)
        {
            var templates = UnitOfWork.TemplateRepository.GetTemplatesByEmployeeAndQuizIds(quizId, employeeId);

            if (templates != null)
            {
                templates.Select(t => t.Employees_Templates
                    .Select(et => et.Status = Data.Domain.EmployeeTemplateStatus.Released));

                UnitOfWork.SaveChanges();

                return true;
            }

            return false;
        }

        /////// multiple quiz creation ?!!!
        //public bool? CreateQuizWithQuestions(Quiz quiz, IEnumerable<int> questionsIds)
        //{
        //    if (quiz != null && questionsIds != null)
        //    {
        //        CreateQuiz(quiz);
        //        CreateQuizQuestion(quiz, questionsIds);
        //        return true;
        //    }
        //    else
        //        return false;
        //}

    }
}