using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Linkdev.Intern.EQuiz.Data.Repository.UnitOfWork;
using Linkdev.Intern.EQuiz.Service.Interfaces;
using Linkdev.Intern.EQuiz.Service.Services;

namespace Linkdev.Intern.EQuiz.Service.BusinessUnity
{
    public static class BusinessUnity
    {
        public static IQuestionService QuestionService { get ; set ; }
        public static IQuizService QuizService { get ; set ; }
        public static ITemplateService TemplateService { get ; set ; }
        public static ITopicService TopicService { get ; set ; }

        public static bool? Initaited { get; set; } = false;
        static BusinessUnity()
        {
            Initaited = Initialize();
        }

        private static bool? Initialize()
        {
            try
            {
                var unitOfWork = new UnitOfWork(new Data.EntityFrameWork.EQuizContext());
                QuestionService = new QuestionService(unitOfWork);
                QuizService = new QuizService(unitOfWork);
                TemplateService = new TemplateService(unitOfWork);
                TopicService = new TopicService(unitOfWork);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}