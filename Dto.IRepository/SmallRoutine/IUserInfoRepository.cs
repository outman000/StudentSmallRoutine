using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.IRepository.SmallRoutine
{
    public   interface IUserInfoRepository: IRepository<User_Info>
    {
        void AddListBase(List<User_Info> insertUserInfoList);

        bool Login();
    }
}
