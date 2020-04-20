using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.RequestViewModel.BaseControlViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.BaseControlViewModel;

namespace Dto.IService.SmallRoutine
{
    public interface IBaseService
    {
        void structSystemInfo();
        void structUserInfo();
        GradeAndClassResModel getGradeAndClass(GradeAndClassSearchViewModel gradeAndClassSearchViewModel);

        DepartAndStationResModel getDepartStation(GradeAndClassSearchViewModel gradeAndClassSearchViewModel);

        //记录 用户插入阅读隐私政策记录（参数：openid） 
        BaseViewModel SaveReadLog(string openid);

        //验证 用户是否 阅读隐私政策记录（参数：openid） 
        BaseViewModel CheckReadLog(string openid);

        //获取加密后的身份证号（参数：idnumber） 
        BaseViewModel GetIdnumber(string idnumber);
    }
}
