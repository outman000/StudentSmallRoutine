using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.RequestViewModel.StaffStationRelateViewModel;

namespace Dto.IRepository.SmallRoutine
{
     public  interface IStaffStationRelateRepository : IRepository<StaffStation_Relate>
    {
        void RemoveByid(List<int> id);
        List<Health_Info> GethealthByStaff(StaffStationRelateSearchViewModel staffStationRelateSearchViewModel);
    }
}
