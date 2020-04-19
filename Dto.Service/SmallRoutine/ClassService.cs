using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace Dto.Service.SmallRoutine
{
    public class ClassService: IClassService
    {
        private readonly IClassInfoRepository  classInfoRepository;
        private readonly IMapper  mapper;

        public ClassService(IClassInfoRepository classInfoRepository, IMapper mapper)
        {
            this.classInfoRepository = classInfoRepository;
            this.mapper = mapper;
        }

        public List<ClassInfoSearchMiddleModel> GetClassKey(String Code)
        {
            var searchresult = classInfoRepository.getclassInfoBycode(Code);

            var result= mapper.Map<List<Class_Info>, List<ClassInfoSearchMiddleModel>>(searchresult);

            return result;
        }


    }
}
