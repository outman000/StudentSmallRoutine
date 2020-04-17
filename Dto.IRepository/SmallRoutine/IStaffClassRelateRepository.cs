using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.RequestViewModel.StaffClassRelateViewModel;

namespace Dto.IRepository.SmallRoutine
{
    public  interface IStaffClassRelateRepository : IRepository<ClassManager_Relate>
    {
        void RemoveByid(List<int> id);
        List<Health_Info> GetStudentsByStaff(StaffClassRelateSearchViewModel staffClassRelateSearchView);
    }
}
