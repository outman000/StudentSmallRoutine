using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.SmallRoutine.ResponseViewModel.StaffViewModel;

namespace SmallRoutine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService  staffService;

        public StaffController(IStaffService staffService)
        {
            this.staffService = staffService;
        }


        /// <summary>
        /// 获取岗位信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("/staff/getkey")]
        public ActionResult<StaffSearchResModel> getClassZhuKey(String code)
        {
            StaffSearchResModel staffSearchResModel = new StaffSearchResModel();
            var result = staffService.GetClassKey(code);
            staffSearchResModel.stationInfoSearchMiddleModels = result;
            staffSearchResModel.baseViewModel.Message = "查询成功";
            staffSearchResModel.baseViewModel.ResponseCode = 200;
            return Ok(staffSearchResModel);

        }


    }
}