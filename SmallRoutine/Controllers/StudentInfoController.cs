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


        /// <summary>
        /// 批量删除学生基础信息new
        /// </summary>
        /// <returns></returns>
        [HttpPost("/StudentInfo/BatchDelete")]
        [ValidateModel]
        public ActionResult<BaseViewModel> batchdelStudentInfo(BaseListByInt model)
        {
            List<int> idsNew = model.ids;
            BaseViewModel viewModel = _studentService.batchdelStudentInfo(idsNew, model.memo);
            return viewModel;
        }


        /// <summary>
        /// 学生 信息批量 升班
        /// </summary>
        /// <returns></returns>
        [HttpPost("/StudentInfo/BatchChange")]
        [ValidateModel]
        public ActionResult<BaseViewModel> BatchChangeStudentInfo(StudentChangeInfo model)
        {
            BaseViewModel viewModel = new BaseViewModel();
            viewModel = _studentService.BatchChangeStudentInfo(model);
            return viewModel;
        }


        /// <summary>
        /// 获取该年级班级的 学生总数
        /// </summary>
        /// <returns></returns>
        [HttpPost("/StudentInfo/GetStudentNum")]
        [ValidateModel]
        public ActionResult<BaseViewModel> GetStudentTotal(string GradeCode, string ClassCode)
        {
            BaseViewModel viewModel = new BaseViewModel();
            viewModel = _studentService.GetStudentTotalByGC(GradeCode, ClassCode);
            return viewModel;
        }

    }
}