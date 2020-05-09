using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.IRepository.SmallRoutine
{
    public interface IStaffRepository: IRepository<Station_Info>
    {


        //根据code查找学校
        List<Station_Info> getStaffInfoBycode(string code);
        int DeleteByRoleIdList(List<int> deleleIdList);
        Station_Info GetInfoByRoleid(int id);
        List<Station_Info> SearchRoleInfoByWhere(UserRoleSearchViewModel userRoleSearchViewModel);
    }
}
