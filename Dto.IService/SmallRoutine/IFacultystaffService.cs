using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.PublicViewModel;
using ViewModel.SmallRoutine.RequestViewModel;
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
    }
}
