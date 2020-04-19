using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.IRepository.SmallRoutine
{
    public interface IStaffRepository: IRepository<Station_Info>
    {


        //根据code查找学校
        List<Station_Info> getStaffInfoBycode(string code);
     
    }
}
