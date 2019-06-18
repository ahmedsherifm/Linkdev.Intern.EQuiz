﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linkdev.Intern.EQuiz.Data;

namespace Linkdev.Intern.EQuiz.Repo.Interfaces
{
    public interface IQuestionRepository : IRepository<Question>
    {
        IEnumerable<Question> GetQuestionsByCreationDate(int pageIndex, int pageSize = 10);

        IEnumerable<Question> GetQuestionsByName(bool ascending, int pageIndex, int pageSize = 10);

        IEnumerable<Question> GetQuestionsByText(string text, int pageIndex, int pageSize = 10);

        IEnumerable<Question> GetQuestionsByTopic(Topic topic, int pageIndex, int pageSize = 10);

        IEnumerable<Question> GetQuestionsByTopicName(string topicName, int pageIndex, int pageSize = 10);
    }
}
