using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace Dto.Service.SmallRoutine
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolInfoRepository schoolInfoRepository;
        private readonly IMapper mapper;

        public SchoolService(ISchoolInfoRepository schoolInfoRepository, IMapper mapper)
        {
            this.schoolInfoRepository = schoolInfoRepository;
            this.mapper = mapper;
        }

        public List<SchoolSearchMiddle> getschoolInfo()
        {
            var searchresult=  schoolInfoRepository.GetAll().ToList() ;

            return mapper.Map<List<School_Info>, List<SchoolSearchMiddle>>(searchresult);


        }
    }
}
