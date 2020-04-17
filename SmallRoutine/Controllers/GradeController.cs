using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.SmallRoutine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.SmallRoutine.ResponseViewModel.GradeViewModel;

namespace SmallRoutine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService gradeService;

        public GradeController(IGradeService gradeService)
        {
            this.gradeService = gradeService;
        }
        /// <summary>
        /// 获取年级信息key
        /// </summary>
        /// <param name="schoolcode"></param>
        /// <returns></returns>
        [HttpGet("/class/getkey")]
        public ActionResult<GradeKeyResViewModel> getGradeZhuKey(String schoolcode)
        {
            GradeKeyResViewModel gradeKeyResView = new GradeKeyResViewModel();
            var result= gradeService.GetGradeKey(schoolcode);
            gradeKeyResView.gradeInfoSearchMiddleModels = result;
            gradeKeyResView.baseViewModel.Message = "查询成功";
            gradeKeyResView.baseViewModel.ResponseCode = 200;
            return Ok(gradeKeyResView);

        }
    }
}
