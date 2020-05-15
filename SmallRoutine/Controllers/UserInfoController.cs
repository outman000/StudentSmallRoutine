using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.PublicViewModel;
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



        /// <summary>
        /// 登录验证接口
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns name="loginValideResModel"></returns>
        [HttpPost("/LoginAdmin")]

        public ActionResult<LoginValideResModel> UserLoginAdmin(LoginViewModel loginViewModel)
        {
            LoginValideReAdminResModel loginValideResModel = new LoginValideReAdminResModel();
            var result = _iloginService.LoginAdmin(loginViewModel);
            if (result)
            {
                loginValideResModel.Data.IdNumber="admin";
                loginValideResModel.Data.SchoolCode = "";
                loginValideResModel.baseViewModel.Message = "登录成功";
                loginValideResModel.baseViewModel.ResponseCode = 200;
                loginValideResModel.IsSuccess = true;

            }
            else
            {
                loginValideResModel.Data = null;
                loginValideResModel.baseViewModel.Message = "登录失败";
                loginValideResModel.baseViewModel.ResponseCode = 210;
                loginValideResModel.IsSuccess = false;
            }


            return Ok(loginValideResModel);

        }







        /// <summary>
        /// 登录验证接口
        /// </summary>
        /// <param name="editPwdView"></param>
        /// <returns name="BaseViewModel"></returns>
        [HttpPost("/EditPwd")]
        public ActionResult<BaseViewModel> UserEditPwd(EditPwdViewModel  editPwdView)
        {
            BaseViewModel ResModel = new BaseViewModel();
            ResModel = _iloginService.EditPwdView(editPwdView);
            return Ok(ResModel);

        }


          /// <summary>
          /// 密码重置接口
          /// </summary>
          /// <param name="idnumber"></param>
          /// <returns></returns>
        [HttpPost("/ResetPwd")]
        public ActionResult UserResetPwd(string idnumber)
        {
        
           _iloginService.ResetPwd(idnumber);

            return Ok("重置成功");
        }





    }
}
