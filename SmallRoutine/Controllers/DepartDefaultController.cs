using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.SmallRoutine.ResponseViewModel.DepartViewModel;

namespace SmallRoutine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartDefaultController : ControllerBase
    {
        private readonly IDepartService  departService;

        public DepartDefaultController(IDepartService departService)
        {
            this.departService = departService;
        }


        /// <summary>
        /// 获取岗位信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("/depart/getkey")]
        public ActionResult<DepartSearchResViewModel> getClassZhuKey(string code)
        {
            DepartSearchResViewModel departSearchResViewModel = new DepartSearchResViewModel();
            var result = departService.GetDepartKey(code);
            departSearchResViewModel.departSearchResViewModels = result;
            departSearchResViewModel.baseViewModel.Message = "查询成功";
            departSearchResViewModel.baseViewModel.ResponseCode = 200;
            return Ok(departSearchResViewModel);

        }
    }
}