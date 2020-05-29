using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.IRepository.SmallRoutine
{
    public interface IUser_GroupRepository:IRepository<User_Group>
    {
        List<User_Group> GetUser_GroupsByStationName(string stationName);
    }
}
