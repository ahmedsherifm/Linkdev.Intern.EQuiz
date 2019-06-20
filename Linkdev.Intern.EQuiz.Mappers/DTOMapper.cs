using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                
                cfg.CreateMap<Topic, Data.Topic>().ReverseMap();
                cfg.CreateMap<Expression<Func<Topic, bool>>, Expression<Func<Data.Topic, bool>>>();

                cfg.CreateMap<Answer, Data.Answer>().ReverseMap();
                cfg.CreateMap<Expression<Func<Topic, bool>>, Expression<Func<Data.Topic, bool>>>();

                cfg.CreateMap<Employee, Data.Employee>().ReverseMap();
                cfg.CreateMap<Expression<Func<Topic, bool>>, Expression<Func<Data.Topic, bool>>>();

                cfg.CreateMap<Employees_Questions_Templates, Data.Employees_Questions_Templates>().ReverseMap();
                cfg.CreateMap<Expression<Func<Topic, bool>>, Expression<Func<Data.Topic, bool>>>();

                cfg.CreateMap<Employees_Templates, Data.Employees_Templates>().ReverseMap();
                cfg.CreateMap<Expression<Func<Topic, bool>>, Expression<Func<Data.Topic, bool>>>();

                cfg.CreateMap<Question, Data.Question>().ReverseMap();
                cfg.CreateMap<Expression<Func<Topic, bool>>, Expression<Func<Data.Topic, bool>>>();

                cfg.CreateMap<Questions_Templates, Data.Questions_Templates>().ReverseMap();
                cfg.CreateMap<Expression<Func<Topic, bool>>, Expression<Func<Data.Topic, bool>>>();

                cfg.CreateMap<Quiz, Data.Quiz>().ReverseMap();
                cfg.CreateMap<Expression<Func<Topic, bool>>, Expression<Func<Data.Topic, bool>>>();

                cfg.CreateMap<Template, Data.Template>().ReverseMap();
                cfg.CreateMap<Expression<Func<Topic, bool>>, Expression<Func<Data.Topic, bool>>>();

                cfg.CreateMap<Questions_Quizes, Data.Questions_Quizes>().ReverseMap();
                cfg.CreateMap<Expression<Func<Questions_Quizes, bool>>, Expression<Func<Data.Questions_Quizes, bool>>>();

                cfg.CreateMap<EmployeeTemplateStatus, Data.EmployeeTemplateStatus>().ReverseMap();

            });
            
            Mapper = config.CreateMapper();
        }
    }
}