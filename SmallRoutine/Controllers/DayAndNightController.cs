﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.SmallRoutine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.SmallRoutine.RequestViewModel.DayAndNightViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.DayAndNightViewModel;

namespace SmallRoutine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayAndNightController : ControllerBase
    {
        private readonly IDayAndNightService  dayAndNightService;

        public DayAndNightController(IDayAndNightService dayAndNightService)
        {
            this.dayAndNightService = dayAndNightService;
        }


        /// <summary>
        /// 获取早午晚检信息
        /// </summary>
        /// <param name="dayAndNightSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost("/DayAndNight/DayAndNightInfo")]
        public ActionResult<DayAndNightSearchResViewModel> getDayAndNightInfo(DayAndNightSearchViewModel   dayAndNightSearchViewModel)
        {
            DayAndNightSearchResViewModel dayAndNightSearchResViewModel = new DayAndNightSearchResViewModel();
            var result = dayAndNightService.SearchDayAndNightListService(dayAndNightSearchViewModel);
            dayAndNightSearchResViewModel.dayandNightInfoMiddles = result;
            dayAndNightSearchResViewModel.TotalNum = result.Count();
            dayAndNightSearchResViewModel.baseViewModel.Message = "查询成功";
            dayAndNightSearchResViewModel.baseViewModel.ResponseCode = 200;
            return Ok(dayAndNightSearchResViewModel);
        }

        /// <summary>
        /// 更新早午晚检信息
        /// </summary>
        /// <param name="dayAndNightUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost("/DayAndNight/Update")]
        public ActionResult<DayAndNightSearchResViewModel> UpdateDayAndNightInfo(DayAndNightUpdateViewModel dayAndNightUpdateViewModel)
        {
            DayAndNightSearchResViewModel dayAndNightSearchResViewModel = new DayAndNightSearchResViewModel();
            dayAndNightService.UpdateIDayAndNightService(dayAndNightUpdateViewModel);
            return Ok("更新成功");
        }
        /// <summary>
        /// 删除早午晚检信息
        /// </summary>
        /// <param name="dayAndNightDeleteViewModel"></param>
        /// <returns></returns>
        [HttpPost("/DayAndNight/Delete")]
        public ActionResult<DayAndNightSearchResViewModel> DeleteDayAndNightInfo(DayAndNightDeleteViewModel  dayAndNightDeleteViewModel)
        {
            DayAndNightSearchResViewModel dayAndNightSearchResViewModel = new DayAndNightSearchResViewModel();
            dayAndNightService.RemveIDayAndNightService(dayAndNightDeleteViewModel.DeleteList);
            return Ok("删除成功");
        }


    }
}