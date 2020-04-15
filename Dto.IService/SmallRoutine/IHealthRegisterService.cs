using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.RequestViewModel.HealthViewModel;

namespace Dto.IService.SmallRoutine
{
    public interface IHealthRegisterService
    {
        void addHealthRegisterInfo(HealthInfoAddViewModel healthViewModel);
    }
}
