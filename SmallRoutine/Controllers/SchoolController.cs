using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.SmallRoutine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.SmallRoutine.ResponseViewModel.SchoolViewModel;

namespace SmallRoutine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            this.schoolService = schoolService;
        }
        /// <summary>
        /// 获取所有学校信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("/getSchoolInfo")]
        public ActionResult<SchoolSearchResModel> GetSchoolInfos()
        {
            SchoolSearchResModel schoolSearchResModel = new SchoolSearchResModel();
            schoolSearchResModel.schoolSearchMiddles = schoolService.getschoolInfo();
            schoolSearchResModel.IsSuccess = true;
            schoolSearchResModel.baseViewModel.Message = "查询成功";
            schoolSearchResModel.baseViewModel.ResponseCode = 200;

            return Ok(schoolSearchResModel);
        }

    }
}