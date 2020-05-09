using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.SmallRoutine.RequestViewModel.ExceptStudentViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.ExceptStudentViewModel;

namespace SmallRoutine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExceptStudentController : ControllerBase
    {
        private readonly IExceptStudentService exceptStudentService;
        private readonly IMapper mapper;

        public ExceptStudentController(IExceptStudentService exceptStudentService, IMapper mapper)
        {
            this.exceptStudentService = exceptStudentService;
            this.mapper = mapper;
        }
        /// <summary>
        /// 添加学生异常信息
        /// </summary>
        /// <param name="exceptStudentAddViewModel"></param>
        /// <returns></returns>
        [HttpPost("StudentExcept/Add")]
        public ActionResult ExceptStudentAdd(ExceptStudentAddViewModel exceptStudentAddViewModel)
        {
  
            exceptStudentService.addExceptStudentAddService(exceptStudentAddViewModel);

            return Ok("添加成功");
        }
        /// <summary>
        /// 更新学生异常信息
        /// </summary>
        /// <param name="exceptStudentUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost("StudentExcept/Update")]

        public ActionResult ExceptStudentUpdate(ExceptStudentUpdateViewModel exceptStudentUpdateViewModel)
        {
            exceptStudentService.updateExceptStudentUpdateServide(exceptStudentUpdateViewModel);

            return Ok("更新成功");
            
     
        }
        /// <summary>
        /// 查询学生异常信息
        /// </summary>
        /// <param name="exceptStudentSearchInfoVIewModel"></param>
        /// <returns></returns>
        [HttpPost("StudentExcept/Search")]
        
        public ActionResult<ExceptStudentSearchResModel> ExceptStudengSearch(ExceptStudengSearchInfoVIewModel exceptStudentSearchInfoVIewModel)
        {
            ExceptStudentSearchResModel exceptStudentSearchResModel = new ExceptStudentSearchResModel();
            var result = exceptStudentService.SearchExceptStudengSearchService(exceptStudentSearchInfoVIewModel);

            exceptStudentSearchResModel.IsSuccess = true;
            exceptStudentSearchResModel.exceptStudentSearchMiddles = result;
            exceptStudentSearchResModel.baseViewModel.Message = "查询成功";
            exceptStudentSearchResModel.baseViewModel.ResponseCode = 200;

            return Ok(exceptStudentSearchResModel);

        
        }
        /// <summary>
        /// 删除学生异常信息
        /// </summary>
        /// <param name="exceptStudentDeleteInfoVIewModel"></param>
        /// <returns></returns>
        [HttpPost("StudentExcept/Delete")]

        public ActionResult ExceptStudengDelete(ExceptStudengDeleteInfoVIewModel exceptStudentDeleteInfoVIewModel)
        {
           exceptStudentService.SearchExceptStudengDeleteService(exceptStudentDeleteInfoVIewModel.deleteList);
            return Ok("删除成功");
        }






    }
}