using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Linkdev.Intern.EQuiz.Mappers
{
    public static class DTOMapper
    {
        public static readonly IMapper Mapper;

        static DTOMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Topic, Data.Topic>();
                cfg.CreateMap<ICollection<Topic>, ICollection<Data.Topic>>();

                cfg.CreateMap<Answer, Data.Answer>();
                cfg.CreateMap<ICollection<Answer>, ICollection<Data.Answer>>();

                cfg.CreateMap<Employee, Data.Employee>();
                cfg.CreateMap<ICollection<Employee>, ICollection<Data.Employee>>();

                cfg.CreateMap<Employees_Questions_Templates, Data.Employees_Questions_Templates>();
                cfg.CreateMap<ICollection<Employees_Questions_Templates>, ICollection<Data.Employees_Questions_Templates>>();

                cfg.CreateMap<Employees_Templates, Data.Employees_Templates>();
                cfg.CreateMap<ICollection<Employees_Templates>, ICollection<Data.Employees_Templates>>();

                cfg.CreateMap<Question, Data.Question>();
                cfg.CreateMap<ICollection<Question>, ICollection<Data.Question>>();

                cfg.CreateMap<Questions_Templates, Data.Questions_Templates>();
                cfg.CreateMap<ICollection<Questions_Templates>, ICollection<Data.Questions_Templates>>();

                cfg.CreateMap<Quiz, Data.Quiz>();
                cfg.CreateMap<ICollection<Quiz>, ICollection<Data.Quiz>>();

                cfg.CreateMap<Template, Data.Template>();
                cfg.CreateMap<ICollection<Template>, ICollection<Data.Template>>();
            });

            Mapper = config.CreateMapper();
        }
    }
}