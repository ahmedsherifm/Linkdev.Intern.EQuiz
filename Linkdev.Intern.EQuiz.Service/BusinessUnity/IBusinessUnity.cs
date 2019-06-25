using Linkdev.Intern.EQuiz.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkdev.Intern.EQuiz.Service.BusinessUnity
{
    public interface IBusinessUnity
    {
        IQuestionService QuestionService { get; set; }
        IQuizService QuizService { get; set; }

        ITemplateService TemplateService { get; set; }

        ITopicService TopicService { get; set; }
    }
}
