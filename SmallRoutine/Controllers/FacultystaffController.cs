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
using ViewModel.SmallRoutine.RequestViewModel.FacultystaffViewModel;
using ViewModel.SmallRoutine.RequestViewModel.StaffClassRelateViewModel;
using ViewModel.SmallRoutine.RequestViewModel.StaffStationRelateViewModel;
using ViewModel.SmallRoutine.ResponseViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.StaffClassRelateViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.StaffStationRelateViewModel;

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


        /// <summary>
        /// 添加关系（班级负责人和班级）
        /// </summary>
        /// <returns></returns>
        [HttpPost("/RelateStaffToClass/Add")]

        public ActionResult<BaseViewModel> SetRelateFromStaffToClass(AddRelateFromStaffToClassViewModel model)
        {
            BaseViewModel baseViewModel = new BaseViewModel();
            _facultystaffService.AddRelateToClass(model);
           
            baseViewModel.Message = "添加成功";
            baseViewModel.ResponseCode = 200;
            return baseViewModel;
        }

        /// <summary>
        /// 删除关系（班级负责人和班级）
        /// </summary>
        /// <returns></returns>
        [HttpPost("/RelateStaffToClass/GetInfoAndHeathEveryInfo")]

        public ActionResult<BaseViewModel> DeleteRelateFromStaffToClass(DeleteRelateFromStaffToClassViewModel model)
        {
            BaseViewModel baseViewModel = new BaseViewModel();
            _facultystaffService.DeleteRelateToClass(model);

            baseViewModel.Message = "查询成功";
            baseViewModel.ResponseCode = 200;
            return baseViewModel;
        }


        /// <summary>
        /// 根据当前人分管的班级查询所管理的学生的每日健康信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("/RelateStaffToClass/GetInfoByClassAndHeathEveryInfo")]

        public ActionResult<StaffClassRelateResModel> getRelateFromStaffToClass(StaffClassRelateSearchViewModel staffClassRelateSearchView)
        {
            StaffClassRelateResModel staffClassRelateResModel = new StaffClassRelateResModel();
            var result= _facultystaffService.GetRelateToClassInfo(staffClassRelateSearchView);

            staffClassRelateResModel.IsSuccess = true;
            staffClassRelateResModel.staffClassMiddleModels = result;
            staffClassRelateResModel.TotalNum = result.Count();
            staffClassRelateResModel.baseViewModel.Message = "查询成功";
            staffClassRelateResModel.baseViewModel.ResponseCode = 200;

            return Ok(staffClassRelateResModel);
        }


        /// <summary>
        /// 根据当前人分管的岗位获取员工每日健康信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("/RelateStationToClass/GetInfoByStationAndHeathEveryInfo")]

        public ActionResult<StaffStationRelateResModel> getStationFromStaffToClass(StaffStationRelateSearchViewModel  staffStationRelateSearchViewModel)
        {
            StaffStationRelateResModel staffStationRelateResModel = new StaffStationRelateResModel();
           var result= _facultystaffService.GetRelateToStationInfo(staffStationRelateSearchViewModel);
          
            staffStationRelateResModel.IsSuccess = true;
            staffStationRelateResModel.staffStationRelateResModels = result;
            staffStationRelateResModel.TotalNum = result.Count();
            staffStationRelateResModel.baseViewModel.Message = "查询成功";
            staffStationRelateResModel.baseViewModel.ResponseCode = 200;

            return Ok(staffStationRelateResModel);
        }


        /// <summary>
        /// 添加关系（教职工和岗位）zpm
        /// </summary>
        /// <returns></returns>
        [HttpPost("/RelateStaffToStation/Add")]

        public ActionResult<BaseViewModel> SetRelateFromStaffToStation(AddRelateFromStaffToStation model)
        {
            BaseViewModel baseViewModel = new BaseViewModel();
            _facultystaffService.AddRelateToStation(model);

            baseViewModel.Message = "添加成功";
            baseViewModel.ResponseCode = 200;
            return baseViewModel;
        }

        /// <summary>
        /// 删除关系（教职工和岗位）zpm
        /// </summary>
        /// <returns></returns>
        [HttpPost("/RelateStaffToStation/Delete")]

        public ActionResult<BaseViewModel> DeleteRelateFromStaffToStation(DeleteRelateFromStaffToStationViewModel model)
        {
            BaseViewModel baseViewModel = new BaseViewModel();
            _facultystaffService.DeleteRelateToStation(model);

            baseViewModel.Message = "删除成功";
            baseViewModel.ResponseCode = 200;
            return baseViewModel;
        }


    }
}
