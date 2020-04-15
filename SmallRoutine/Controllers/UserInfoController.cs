using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IRepository.SmallRoutine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.SmallRoutine.RequestViewModel;

namespace SmallRoutine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoRepository _userInfoRepository;

        public UserInfoController(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }



        [HttpPost("/Login")]
        [ValidateModel]
        public ActionResult UserLogin(LoginViewModel loginViewModel)
        {

            return Ok();

        }
    }
}
