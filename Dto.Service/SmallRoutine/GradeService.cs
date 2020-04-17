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
    public class GradeService : IGradeService
    {
        private readonly IGradeInfoRepository gradeInfoRepository;
        private readonly IMapper _IMapper;

        public GradeService(IGradeInfoRepository gradeInfoRepository, IMapper iMapper)
        {
            this.gradeInfoRepository = gradeInfoRepository;
            _IMapper = iMapper;
        }

        public List<GradeInfoSearchMiddleModel>  GetGradeKey(String Code)
        {
            var searchresult = gradeInfoRepository.getclassInfoBycode(Code);

            var  result = _IMapper.Map<List<Grade_Info>, List<GradeInfoSearchMiddleModel>>(searchresult);
         

            return result;
        }

    }
}
