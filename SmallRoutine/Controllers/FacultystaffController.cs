using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.SmallRoutine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.PublicViewModel;
using ViewModel.SmallRoutine.RequestViewModel;
using ViewModel.SmallRoutine.ResponseViewModel;


namespace SmallRoutine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultystaffController: ControllerBase
    {
        private readonly IFacultystaffService  _facultystaffService;

        public FacultystaffController(IFacultystaffService service)
        {
            _facultystaffService = service;

        }


        /// <summary>
        /// 添加教职工基础信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("/Facultystaff/Add")]
        [ValidateModel]
        public ActionResult<BaseViewModel> addStudentInfo(FacultystaffBaseModel  facultystaff)
        {
            BaseViewModel viewModel = _facultystaffService.addFacultystaffInfo(facultystaff);
            return viewModel;
        }


        /// <summary>
        /// 删除教职工基础信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("/Facultystaff/Delete")]
        [ValidateModel]
        public ActionResult<BaseViewModel> delStudentInfo(int id)
        {
            BaseViewModel viewModel = _facultystaffService.delFacultystaffInfo(id);
            return viewModel;
        }


        /// <summary>
        /// 更新教职工基础信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("/Facultystaff/Update")]
        [ValidateModel]
        public ActionResult<BaseViewModel> updateStudentInfo(FacultystaffMiddle  facultystaff)
        {
            BaseViewModel viewModel = _facultystaffService.updateFacultystafffo(facultystaff);
            return viewModel;
        }


        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("/Facultystaff/Lists")]

        public ActionResult<FacultystaffSearchResModel> GetListByParas(FacultystaffSearchModel model)
        {
            var lists = _facultystaffService.GetListByParas(model);
            FacultystaffSearchResModel resModel = new FacultystaffSearchResModel();
            resModel.IsSuccess = true;
            resModel.viewModels = lists;
            resModel.TotalNum = lists.Count;
            resModel.baseViewModel.Message = "查询成功";
            resModel.baseViewModel.ResponseCode = 200;
            return resModel;
        }
    }
}
