using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.FacultystaffViewModel;
using ViewModel.SmallRoutine.RequestViewModel.StaffStationRelateViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.StaffStationRelateViewModel;

namespace Dto.IRepository.SmallRoutine
{
     public  interface IStaffStationRelateRepository : IRepository<StaffStation_Relate>
    {
        void RemoveByid(List<int> id);
        List<StaffStationMiddleModel> GethealthByStaff(StaffStationRelateSearchViewModel staffStationRelateSearchViewModel);
        List<EmploySearchStationMiddle> GetStationbindByEmploy(int userKeyId);
        List<EmploySearchStationAllMiddle> GetStationbindByEmployAll(int userKeyId);
        bool isRepeat(AddRelateFromStaffToStation model);
    }
}
