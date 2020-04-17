using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.SmallRoutine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.SmallRoutine.ResponseViewModel.ClassViewModel;

namespace SmallRoutine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService  classService;

        public ClassController(IClassService classService)
        {
            this.classService = classService;
        }
        /// <summary>
        /// 获取班级信息key
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("/grade/getkey")]
        public  ActionResult<ClassKeyResViewModel> getClassZhuKey(String code)
        {
            ClassKeyResViewModel classKeyResViewModel = new ClassKeyResViewModel();
            var result = classService.GetClassKey(code);
            classKeyResViewModel.classInfoSearchMiddleModels = result;
            classKeyResViewModel.baseViewModel.Message = "查询成功";
            classKeyResViewModel.baseViewModel.ResponseCode = 200;
            return Ok(classKeyResViewModel) ;

        }
    }
}