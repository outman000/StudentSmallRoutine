﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.SmallRoutine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.RequestViewModel.DayAndNightViewModel;
using ViewModel.SmallRoutine.RequestViewModel.HealthEveryViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.HealthEveryViewModel;

namespace SmallRoutine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthEveryDayController : ControllerBase
    {
        private readonly IHealthService  healthService;

        public HealthEveryDayController(IHealthService  healthService)
        {
            this.healthService = healthService;
        }

        /// <summary>
        /// 增加每日健康登记信息
        /// </summary>
        /// <param name="healthViewModel"></param>
        /// <returns></returns>
        [HttpPost("/HealthEveryDayRegister/add")]
        // GET: HealthInfo/Details/5
        public ActionResult<BaseViewModel> AddHealthRegisterAdd(HealthEveryAddViewModel healthViewModel)
        {
            BaseViewModel baseViewModel = new BaseViewModel();
            healthService.addHealthEveryRegisterInfo(healthViewModel);
            baseViewModel.Message = "增加成功";
            baseViewModel.ResponseCode = 200;
            return Ok(baseViewModel);
        }
        /// <summary>
        /// 删除每日健康登记信息
        /// </summary>
        /// <param name="healthInfoDeleteViewModel"></param>
        /// <returns></returns>
        [HttpPost("/HealthEveryDayRegister/Delete")]
        // GET: HealthInfo/Details/5
        public ActionResult<BaseViewModel> DeleteHealthRegister(HealthEveryDeleteViewModel healthInfoDeleteViewModel)
        {
            BaseViewModel baseViewModel = new BaseViewModel();
            healthService.DeleteHealthEveryRegisterInfo(healthInfoDeleteViewModel);
            baseViewModel.Message = "删除成功";
            baseViewModel.ResponseCode = 200;
            return Ok(baseViewModel);
        }
        /// <summary>
        /// 查询每日健康登记信息
        /// </summary>
        /// <param name="healthInfoSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost("/HealthEveryDayRegister/Search")]
        // GET: HealthInfo/Details/5
        public ActionResult<HealthInfoEverySearchResModel> SearchHealthRegister(HealthEverySearchViewModel healthInfoSearchViewModel)
        {
            HealthInfoEverySearchResModel healthInfoSearchResModel = new HealthInfoEverySearchResModel();
            var result = healthService.SearchHealthEveryRegisterInfo(healthInfoSearchViewModel);

            healthInfoSearchResModel.healthEverySearchMiddleModels = result;
            healthInfoSearchResModel.TotalNum = result.Count();
            healthInfoSearchResModel.IsSuccess = true;
            healthInfoSearchResModel.baseViewModel.Message = "查询成功";
            healthInfoSearchResModel.baseViewModel.ResponseCode = 200;

            return Ok(healthInfoSearchResModel);
        }
        /// <summary>
        /// 更新每日健康信息
        /// </summary>
        /// <param name="healthInfoUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost("/HealthEveryDayRegister/Update")]
        // GET: HealthInfo/Details/5
        public ActionResult<BaseViewModel> UpdateHealthRegister(HealthEveryUpdateViewModel healthInfoUpdateViewModel)
        {
            BaseViewModel baseViewModel = new BaseViewModel();
            healthService.UpdateHealthEveryRegisterInfo(healthInfoUpdateViewModel);
            baseViewModel.Message = "更新成功";
            baseViewModel.ResponseCode = 200;
            return Ok(baseViewModel);
        }

        /// <summary>
        /// 更新每日健康信息
        /// </summary>
        /// <param name="healthInfoUpdateViewModel"></param>
        /// <returns></returns>
        //[HttpPost("/HealthEveryDayRegister/Update")]
        //// GET: HealthInfo/Details/5
        //public ActionResult<BaseViewModel> getDefaultDayAndNight(DayAndNightDefaultSearchViewModel dayAndNightDefaultSearchViewModel )
        //{
        //    healthService.getDefaultDayAndNightInfo(dayAndNightDefaultSearchViewModel);


        //    BaseViewModel baseViewModel = new BaseViewModel();
        //    healthService.UpdateHealthEveryRegisterInfo(healthInfoUpdateViewModel);
        //    baseViewModel.Message = "更新成功";
        //    baseViewModel.ResponseCode = 200;
        //    return Ok(baseViewModel);
        //}




    }
}
