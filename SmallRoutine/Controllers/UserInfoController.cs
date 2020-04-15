﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.SmallRoutine.RequestViewModel;
using ViewModel.SmallRoutine.ResponseViewModel;

namespace SmallRoutine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IloginService _iloginService;

        public UserInfoController(IloginService iloginService)
        {
            _iloginService = iloginService;
        }
        /// <summary>
        /// 登录验证接口
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns name="loginValideResModel"></returns>
        [HttpPost("/Login")]
        [ValidateModel]
        public ActionResult<LoginValideResModel> UserLogin(LoginViewModel loginViewModel)
        {
            LoginValideResModel loginValideResModel = new LoginValideResModel();
            var result = _iloginService.Login(loginViewModel);
            if (result != null)
            {
                loginValideResModel.Data = result;
                loginValideResModel.baseViewModel.Message = "登录成功";
                loginValideResModel.baseViewModel.ResponseCode = 200;
                loginValideResModel.IsSuccess = true;

            }
            else
            {
                loginValideResModel.Data = result;
                loginValideResModel.baseViewModel.Message = "登录失败";
                loginValideResModel.baseViewModel.ResponseCode = 210;
                loginValideResModel.IsSuccess = false;
            }

          
            return Ok(loginValideResModel);

        }




        /// <summary>
        /// 登录验证接口
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns name="loginValideResModel"></returns>
        [HttpPost("/LoginEmploy")]
        [ValidateModel]
        public ActionResult<LoginValideResModel> UserLoginEmploy(LoginViewModel loginViewModel)
        {
            LoginValideReEmployesModel loginValideResModel = new LoginValideReEmployesModel();
            var result = _iloginService.LoginEmploy(loginViewModel);
            if (result != null)
            {
                loginValideResModel.Data = result;
                loginValideResModel.baseViewModel.Message = "登录成功";
                loginValideResModel.baseViewModel.ResponseCode = 200;
                loginValideResModel.IsSuccess = true;

            }
            else
            {
                loginValideResModel.Data = result;
                loginValideResModel.baseViewModel.Message = "登录失败";
                loginValideResModel.baseViewModel.ResponseCode = 210;
                loginValideResModel.IsSuccess = false;
            }


            return Ok(loginValideResModel);

        }


    }
}
