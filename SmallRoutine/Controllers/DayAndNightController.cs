using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.SmallRoutine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;
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
        /// 添加晨午晚检信息
        /// </summary>
        /// <returns></returns>
        //[HttpPost("/DayAndNight/AddDayAndNightInfo")]
        //[ValidateModel]
        //public ActionResult<BaseViewModel> addDayAndNightInfo(DayAndNightDefaultViewModel dayAndNightSearchViewModel)
        //{
        //    BaseViewModel viewModel = dayAndNightService.addDayAndNightInfo(dayAndNightSearchViewModel);
        //    return viewModel;
        //}
        /// <summary>
        /// 批量添加晨午晚检信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("/DayAndNight/AddDayAndNightInfoList")]
        [ValidateModel]
        public ActionResult<BaseViewModel> addDayAndNightInfoList(DayAndNightAddListViewModel model)
        {
            BaseViewModel viewModel = dayAndNightService.addDayAndNightInfoList(model);
            return viewModel;
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
        /// 早午晚检信息每天每人每时段验重
        /// </summary>
        /// <param name="dayAndNightSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost("/DayAndNight/DayAndNightInfoCheck")]
        public ActionResult<DayAndNightSearchResViewModel> getDayAndNightInfoCheck(DayAndNightCheckViewModel dayAndNightSearchViewModel)
        {
            DayAndNightSearchResViewModel dayAndNightSearchResViewModel = new DayAndNightSearchResViewModel();
            
            var result = dayAndNightService.CheckDayAndNightListService(dayAndNightSearchViewModel);
            dayAndNightSearchResViewModel.dayandNightInfoMiddles = result;
            dayAndNightSearchResViewModel.TotalNum = result.Count();
            dayAndNightSearchResViewModel.baseViewModel.Message = "查询成功";
            dayAndNightSearchResViewModel.baseViewModel.ResponseCode = 200;
            return Ok(dayAndNightSearchResViewModel);
        }
        /// <summary>
        /// 获取早午晚检信息(默认导入)
        /// </summary>
        /// <param name="dayAndNightDefaultSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost("/DayAndNight/DefaultDayAndNightInfo")]
        public ActionResult<DefaultDayAndNightSearchResViewModel> getDefaultDayAndNightInfo(DayAndNightDefaultSearchViewModel   dayAndNightDefaultSearchViewModel)
        {
            DefaultDayAndNightSearchResViewModel dayAndNightSearchResViewModel = new DefaultDayAndNightSearchResViewModel();
            var result = dayAndNightService.DefaultSearchDayAndNightListService(dayAndNightDefaultSearchViewModel);
            dayAndNightSearchResViewModel.defaultDayAndNightMiddles = result;
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