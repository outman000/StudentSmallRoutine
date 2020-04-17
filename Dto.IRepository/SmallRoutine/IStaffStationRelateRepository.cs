using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.IRepository.SmallRoutine
{
     public  interface IStaffStationRelateRepository : IRepository<StaffStation_Relate>
    {
        void RemoveByid(List<int> id);
    }
}
