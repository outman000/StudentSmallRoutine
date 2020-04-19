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

using ViewModel.SmallRoutine.RequestViewModel;
using ViewModel.SmallRoutine.ResponseViewModel;


namespace SmallRoutine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentInfoController : ControllerBase
    {

        private readonly IStudentService _studentService;

        public StudentInfoController(IStudentService service)
        {
            _studentService = service;

        }


        /// <summary>
        /// 添加学生基础信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("/StudentInfo/Add")]
        [ValidateModel]
        public ActionResult<BaseViewModel> addStudentInfo(StudentBaseModel student)
        {
            BaseViewModel viewModel = _studentService.addStudentInfo(student);
            return viewModel;
        }


        /// <summary>
        /// 删除学生基础信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("/StudentInfo/Delete")]
        [ValidateModel]
        public ActionResult<BaseViewModel> delStudentInfo(int id)
        {
            BaseViewModel viewModel = _studentService.delStudentInfo(id);
            return viewModel;
        }


        /// <summary>
        /// 更新学生基础信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("/StudentInfo/Update")]
        [ValidateModel]
        public ActionResult<BaseViewModel> updateStudentInfo(StudentMiddle student)
        {
            BaseViewModel viewModel = _studentService.updateStudentInfo(student);
            return viewModel;
        }


        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("/StudentInfo/Lists")]

        public ActionResult<StudentSearchResModel> GetListByParas(StudentSearchModel model)
        {
            var lists = _studentService.GetListByParas(model);
            StudentSearchResModel resModel = new StudentSearchResModel();
            resModel.IsSuccess = true;
            resModel.viewModels = lists;
            resModel.TotalNum = lists.Count;
            resModel.baseViewModel.Message = "查询成功";
            resModel.baseViewModel.ResponseCode = 200;
            return resModel;
        }

    }
}