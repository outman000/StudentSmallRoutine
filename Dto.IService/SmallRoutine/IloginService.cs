using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel;

namespace Dto.IService.SmallRoutine
{
    public interface IloginService
    {
        ValideMiddleViewModel Login(LoginViewModel loginViewModel);
        ValideMiddleEmployMiddleModel LoginEmploy(LoginViewModel loginViewModel);
    }
}
