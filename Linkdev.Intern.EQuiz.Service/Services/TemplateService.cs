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


        // needs more work and check on repeptive question
        public bool? CreateTemplate(Quiz quiz,int questionsNumber)
        {
            if(quiz != null)
            {
                IEnumerable<Question> tempQuestions;
                var random = new Random();
                var dtoQuiz = DTOMapper.Mapper.Map<Quiz, Data.Quiz>(quiz);
                

                for (int i = 0;i<questionsNumber;i++)
                {
                    int index = random.Next(questionsNumber);
                    UnitOfWork.QuestionTemplateRepository.Add(new Data.Questions_Templates()
                    {
                        Template = new Data.Template()
                        {
                            Quiz = dtoQuiz,
                            CreationDate = DateTime.Now
                        },
                        Question = UnitOfWork.QuestionQuizRepository.GetQuizQuestions(dtoQuiz).ToList()[index]
                    });
                }

                return true;            
                
            }

            else
                return false
        }
    }
}