using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.SmallRoutine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.PublicViewModel;

using ViewModel.SmallRoutine.RequestViewModel.HealthViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.HealthViewModel;

namespace SmallRoutine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthInfoController : Controller
    {
        private readonly IHealthRegisterService healthRegisterService;

        public HealthInfoController(IHealthRegisterService healthRegisterService)
        {
            this.healthRegisterService = healthRegisterService;
        }

         /// <summary>
         /// 增加健康登记信息
         /// </summary>
         /// <param name="healthViewModel"></param>
         /// <returns></returns>
        [HttpPost("/HealthRegister/add")]
        // GET: HealthInfo/Details/5
        public ActionResult<BaseViewModel> AddHealthRegisterAdd(HealthInfoAddViewModel healthViewModel)
        {
            BaseViewModel baseViewModel = new BaseViewModel();
            if (healthViewModel.Idnumber.Equals("") || healthViewModel.Idnumber.Equals(null) || healthViewModel.Name.Equals("") || healthViewModel.Name.Equals(null))
            {
                baseViewModel.Message = "增加失败";
                baseViewModel.ResponseCode = 210;
            }
            else
            {
                healthRegisterService.addHealthRegisterInfo(healthViewModel);
                baseViewModel.Message = "增加成功";
                baseViewModel.ResponseCode = 200;
            }
            return Ok(baseViewModel);
        }
        /// <summary>
        /// 删除健康登记信息
        /// </summary>
        /// <param name="healthInfoDeleteViewModel"></param>
        /// <returns></returns>
        [HttpPost("/HealthRegister/Delete")]
        // GET: HealthInfo/Details/5
        public ActionResult<BaseViewModel> DeleteHealthRegister(HealthInfoDeleteViewModel  healthInfoDeleteViewModel)
        {
            BaseViewModel baseViewModel = new BaseViewModel();
            healthRegisterService.DeleteHealthRegisterInfo(healthInfoDeleteViewModel);
            baseViewModel.Message = "删除成功";
            baseViewModel.ResponseCode = 200;
            return Ok(baseViewModel);
        }
        /// <summary>
        /// 查询健康登记信息
        /// </summary>
        /// <param name="healthInfoSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost("/HealthRegister/Search")]
        // GET: HealthInfo/Details/5
        public ActionResult<HealthInfoSearchResModel> SearchHealthRegister(HealthInfoSearchViewModel  healthInfoSearchViewModel)
        {
            HealthInfoSearchResModel healthInfoSearchResModel = new HealthInfoSearchResModel();
            var result=healthRegisterService.SearchHealthRegisterInfo(healthInfoSearchViewModel);

            healthInfoSearchResModel.healthInfoSearchMiddles = result;
            healthInfoSearchResModel.TotalNum = result.Count();
            healthInfoSearchResModel.IsSuccess = true;
            healthInfoSearchResModel.baseViewModel.Message = "查询成功";
            healthInfoSearchResModel.baseViewModel.ResponseCode =200;

            return Ok(healthInfoSearchResModel);
        }



        /// <summary>
        /// 查询健康信息（学生）
        /// </summary>
        /// <param name="studentSearchHealthInfo"></param>
        /// <returns></returns>
        [HttpPost("/HealthRegister/StudentSearch")]
        // GET: HealthInfo/Details/5
        public ActionResult<StudentHealthInfoSearchResModel> StudentSearchHealthRegister(StudentSearchHealthInfo  studentSearchHealthInfo)
        {
            StudentHealthInfoSearchResModel studentHealthInfoSearchResModel = new StudentHealthInfoSearchResModel();
            var data= healthRegisterService.StudentSearchHealthRegisterInfo(studentSearchHealthInfo);
            studentHealthInfoSearchResModel.healthInfoSearchMiddles = data;
            studentHealthInfoSearchResModel.TotalNum = data.Count();
            studentHealthInfoSearchResModel.IsSuccess = true;
            studentHealthInfoSearchResModel.baseViewModel.Message = "查询成功";
            studentHealthInfoSearchResModel.baseViewModel.ResponseCode = 200;

            return Ok(studentHealthInfoSearchResModel);
        }
        /// <summary>
        /// 查询健康信息（职工）
        /// </summary>
        /// <param name="employSearchHealthInfo"></param>
        /// <returns></returns>
        [HttpPost("/HealthRegister/EmploySearch")]
        // GET: HealthInfo/Details/5
        public ActionResult<EmployHealthInfoSearchResModel> EmploySearchHealthRegister(EmploySearchHealthInfo  employSearchHealthInfo)
        {
            EmployHealthInfoSearchResModel employHealthInfoSearchResModel = new EmployHealthInfoSearchResModel();
            employHealthInfoSearchResModel.employHealthInfoSearchMiddles = healthRegisterService.EmploySearchHealthRegisterInfo(employSearchHealthInfo);
            employHealthInfoSearchResModel.TotalNum = healthRegisterService.EmploySearchHealthRegisterInfo(employSearchHealthInfo).Count();
            employHealthInfoSearchResModel.IsSuccess = true;
            employHealthInfoSearchResModel.baseViewModel.Message = "查询成功";
            employHealthInfoSearchResModel.baseViewModel.ResponseCode = 200;

            return Ok(employHealthInfoSearchResModel);
        }






        /// <summary>
        /// 更新健康信息
        /// </summary>
        /// <param name="healthInfoUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost("/HealthRegister/Update")]
        // GET: HealthInfo/Details/5
        public ActionResult<BaseViewModel> UpdateHealthRegister(HealthInfoUpdateViewModel  healthInfoUpdateViewModel)
        {
            BaseViewModel baseViewModel = new BaseViewModel();
            healthRegisterService.UpdateHealthRegisterInfo(healthInfoUpdateViewModel);
            baseViewModel.Message = "更新成功";
            baseViewModel.ResponseCode = 200;
            return Ok(baseViewModel);
        }









    }
}