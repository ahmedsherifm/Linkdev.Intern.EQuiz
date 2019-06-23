﻿using Linkdev.Intern.EQuiz.Mappers;
using Linkdev.Intern.EQuiz.Repo.UnitOfWork;
using Linkdev.Intern.EQuiz.Service.Interfaces;
using Linkdev.Intern.EQuiz.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Linkdev.Intern.EQuiz.Service.Services
{
    public class QuizService: IQuizService
    {
        private readonly IUnitOfWork UnitOfWork;

        public QuizService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public QuizService()
        {
            UnitOfWork = new UnitOfWork(new Data.EQuizContext());
        }

        public IEnumerable<Quiz> GetQuizesByQuestionID(int qid)
        {
            var dtoQuizes = UnitOfWork.QuizRepository.GetQuizesByQuestion(qid);
            return DTOMapper.Mapper.Map<IEnumerable<Data.Quiz>, IEnumerable<Quiz>>(dtoQuizes);
        }

        public IEnumerable<Answer> GetQuizAnswers(int id)
        {
            var dtoAnswers = UnitOfWork.QuizRepository.GetQuizAnswers(id);
            return DTOMapper.Mapper.Map<IEnumerable<Data.Answer>, IEnumerable<Answer>>(dtoAnswers);
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
            if(quizesIds != null)
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
            return DTOMapper.Mapper.Map<Data.Quiz, Quiz>(dtoQuiz);
        }

        private bool? CreateQuiz(Quiz quiz)
        {
            if (quiz != null)
            {
                var dtoQuiz = DTOMapper.Mapper.Map<Quiz, Data.Quiz>(quiz);
                UnitOfWork.QuizRepository.Add(dtoQuiz);
                UnitOfWork.SaveChanges();
                return true;
            }
            else
                return false;
        }

        private bool? CreateQuizQuestion(Quiz quiz, IEnumerable<Question> questions)
        {
            if (quiz != null && questions != null)
            {
                var dtoQuiz = DTOMapper.Mapper.Map<Quiz, Data.Quiz>(quiz);
                ICollection<Questions_Quizes> Questions_Quizes = new List<Questions_Quizes>();

                foreach (var item in questions)
                {
                    var QuestionQuiz = new Questions_Quizes() { QuizID = quiz.ID, QuestionID = item.ID };
                    Questions_Quizes.Add(QuestionQuiz);
                }

                var dtoQuestionQuizList = DTOMapper.Mapper.Map<ICollection<Questions_Quizes>, ICollection<Data.Questions_Quizes>>(Questions_Quizes);
                dtoQuiz.Questions_Quizes = dtoQuestionQuizList;
                UnitOfWork.SaveChanges();

                return true;
            }
            else
                return false;
        }

        ///// multiple quiz creation ?!!!
        public bool? CreateQuizWithQuestions(Quiz quiz, IEnumerable<Question> questions)
        {
            if (quiz != null && questions != null)
            {
                CreateQuiz(quiz);
                CreateQuizQuestion(quiz, questions); 
                return true;
            }
            else
                return false;
        }

    }
}