using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.DepartViewModel;

namespace Dto.Service.SmallRoutine
{
    public  class DepartService: IDepartService
    {
        private readonly IDepartInfoRepository  departInfoRepository ;
        private readonly IMapper mapper;

        public DepartService(IDepartInfoRepository departInfoRepository, IMapper mapper)
        {
            this.departInfoRepository = departInfoRepository;
            this.mapper = mapper;
        }

        public List<DepartInfoSearchMiddleModel> GetDepartKey(string code)
        {
            var result = departInfoRepository.getdepartInfoBycode(code);

            return mapper.Map<List<Depart_Info>, List<DepartInfoSearchMiddleModel>>(result);

            ;
        }
    }
}
