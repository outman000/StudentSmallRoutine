using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.SmallRoutine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.SmallRoutine.RequestViewModel.ExceptEmployViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.ExceptEmployViewModel;

namespace SmallRoutine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExceptEmployController : ControllerBase
    {
        private readonly IExceptEmployService exceptEmployService;

        public ExceptEmployController(IExceptEmployService exceptEmployService)
        {
            this.exceptEmployService = exceptEmployService;
        }
        /// <summary>
        /// 员工异常上报添加
        /// </summary>
        /// <param name="exceptEmployAddViewModel"></param>
        /// <returns></returns>

        [HttpPost("/ExceptEmply/Add")]
        public ActionResult ExceptEmplyAdd(ExceptEmployAddViewModel exceptEmployAddViewModel)
        {
            exceptEmployService.addExceptEmployService(exceptEmployAddViewModel);
            return Ok("添加成功");
        }
        /// <summary>
        /// 员工异常上查询
        /// </summary>
        /// <param name="exceptEmploySearchViewModel"></param>
        /// <returns></returns>
        [HttpPost("/ExceptEmply/Search")]
        public ActionResult<ExceptEmploySearchResModel> ExceptEmplySearch(ExceptEmploySearchViewModel  exceptEmploySearchViewModel)
        {
            ExceptEmploySearchResModel exceptEmploySearchResModel = new ExceptEmploySearchResModel();
           var result= exceptEmployService.searchExceptEmployService(exceptEmploySearchViewModel);
            exceptEmploySearchResModel.IsSuccess = true;
            exceptEmploySearchResModel.exceptEmploySearchMiddles = result;
            exceptEmploySearchResModel.baseViewModel.Message = "查询成功";
            exceptEmploySearchResModel.baseViewModel.ResponseCode = 200;
            return Ok(exceptEmploySearchResModel);
        }
        /// <summary>
        /// 员工异常上报更新
        /// </summary>
        /// <param name="exceptEmployUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost("/ExceptEmply/Update")]
        public ActionResult ExceptEmplyUpdate(ExceptEmployUpdateViewModel  exceptEmployUpdateViewModel)
        {
            exceptEmployService.updateExceptEmployService(exceptEmployUpdateViewModel);
            return Ok("更新成功");
        }
        /// <summary>
        /// 员工异常上报删除
        /// </summary>
        /// <param name="exceptEmployDeleteViewModel"></param>
        /// <returns></returns>
        [HttpPost("/ExceptEmply/Delete")]
        public ActionResult ExceptEmplyDelete(ExceptEmployDeleteViewModel  exceptEmployDeleteViewModel )
        {

            exceptEmployService.deleteExceptEmployService(exceptEmployDeleteViewModel.deleteList);

            return Ok("删除成功");
        }



    }
}