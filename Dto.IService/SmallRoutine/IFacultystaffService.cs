using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;

using ViewModel.SmallRoutine.RequestViewModel;
using ViewModel.SmallRoutine.RequestViewModel.BaseControlViewModel;
using ViewModel.SmallRoutine.RequestViewModel.FacultystaffViewModel;
using ViewModel.SmallRoutine.RequestViewModel.StaffClassRelateViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.BaseControlViewModel;
using ViewModel.SmallRoutine.RequestViewModel.StaffStationRelateViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.StaffStationRelateViewModel;
using ViewModel.SmallRoutine.MiddelViewModel.SecondMiddleViewModel;
using ViewModel.PublicViewModel;

namespace Dto.IService.SmallRoutine
{
    public interface IFacultystaffService
    {
        //添加教职工信息 
        BaseViewModel addFacultystaffInfo(FacultystaffBaseModel model);


        //根据 id 删除 教职工信息
        BaseViewModel delFacultystaffInfo(int id);


        //修改 教职工信息
        BaseViewModel updateFacultystafffo(FacultystaffMiddle student);


        //根据条件查询
        List<FacultystaffMiddle> GetListByParas(FacultystaffSearchModel model);
        void AddRelateToClass(AddRelateFromStaffToClassViewModel model);
 
        void DeleteRelateToClass(DeleteRelateFromStaffToClassViewModel model);


        List<StaffClassMiddleModel> GetRelateToClassInfo(StaffClassRelateSearchViewModel staffClassRelateSearchView);

        List<StaffSchoolClassMiddleModel> GetRelateToSchoolClassInfo(StaffSchoolClassRelateSearchViewModel staffClassRelateSearchView);

        //教职工和岗位  关系表增加
        void AddRelateToStation(AddRelateFromStaffToStation model);
        //教职工和岗位   关系表删除
        void DeleteRelateToStation(DeleteRelateFromStaffToStationViewModel model);
        List<StaffStationMiddleModel> GetRelateToStationInfo(StaffStationRelateSearchViewModel staffStationRelateSearchViewModel);
        //关联关系查询
        List<TeacherSearchClassMiddle> GetClassByTeacher(int UserKey);
        List<EmploySearchStationMiddle> GetStationByEmploy(int userKeyId);
        List<TeacherSearchClassAllMiddle> GetClassAllInfoByTeacher(int userKeyId);
        List<EmploySearchStationAllMiddle> GetStationByEmployAll(int userKeyId);
    }
}
