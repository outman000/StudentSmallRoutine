using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel;

namespace Dto.IService.SmallRoutine
{
    public interface IloginService
    {
        ValideMiddleViewModel Login(LoginViewModel loginViewModel);
        ValideMiddleEmployMiddleModel LoginEmploy(LoginViewModel loginViewModel);

        bool LoginAdmin(LoginViewModel loginViewModel);

        //修改密码
        BaseViewModel EditPwdView(EditPwdViewModel editPwdView);
    }
}
