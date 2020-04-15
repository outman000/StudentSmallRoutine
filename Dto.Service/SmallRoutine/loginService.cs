using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Service.SmallRoutine
{
  
    public class loginService: IloginService
    {
        private readonly IUserInfoRepository _userInfoRepository;

        public loginService(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        public void loginValide()
        {
            //_userInfoRepository.


        }
       
    }
}
