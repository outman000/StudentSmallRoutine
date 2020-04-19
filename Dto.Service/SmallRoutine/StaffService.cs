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
    public class StaffService: IStaffService
    {
        private readonly IStaffRepository  staffRepository;
     
        private readonly IMapper _IMapper;

        public StaffService(IStaffRepository staffRepository, IMapper iMapper)
        {
            this.staffRepository = staffRepository;
            _IMapper = iMapper;
        }

        public List<StationInfoSearchMiddleModel> GetClassKey(string Code)
        {
            var result = staffRepository.getStaffInfoBycode(Code);
            var searchresult = _IMapper.Map<List<Station_Info>, List<StationInfoSearchMiddleModel>>(result);



            return searchresult;

;

        }
    }
}
