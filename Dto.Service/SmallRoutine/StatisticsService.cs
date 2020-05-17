using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.StatasticViewModel;

namespace Dto.Service.SmallRoutine
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStudentComtemlateRepository  studentComtemlateRepository;
        private readonly IEmployComtemplateRepository  employComtemplateRepository;
        private readonly IMapper _IMapper;

        public StatisticsService(IStudentComtemlateRepository studentComtemlateRepository, IEmployComtemplateRepository employComtemplateRepository, IMapper iMapper)
        {
            this.studentComtemlateRepository = studentComtemlateRepository;
            this.employComtemplateRepository = employComtemplateRepository;
            _IMapper = iMapper;
        }

        public List<StudentComtemlateMiddle> getBaseComtemplateInfo(BaseStudentStasticViewModel baseStudentStasticViewModel)
        {
           var SearchResult= studentComtemlateRepository.GetCompTemplateStudent(baseStudentStasticViewModel);
           
            return _IMapper.Map<List<Template_Student> , List<StudentComtemlateMiddle>>(SearchResult);
        }

        public List<EmployComtemlateMiddle> getBaseComtemplateInfoEmploy(BaseStudentStasticViewModel baseStudentStasticViewModel)
        {
            var SearchResult = employComtemplateRepository.GetCompTemplateEmploy(baseStudentStasticViewModel);

            return _IMapper.Map<List<Template_Employment>, List<EmployComtemlateMiddle>>(SearchResult);
        }




    }
}
