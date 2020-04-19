using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.HealthViewModel;

namespace Dto.IService.SmallRoutine
{
    public interface IHealthRegisterService
    {
        void addHealthRegisterInfo(HealthInfoAddViewModel healthViewModel);

        void DeleteHealthRegisterInfo(HealthInfoDeleteViewModel  healthInfoDeleteViewModel);

        List<HealthInfoSearchMiddle> SearchHealthRegisterInfo(HealthInfoSearchViewModel  healthInfoSearchViewModel);

        void UpdateHealthRegisterInfo(HealthInfoUpdateViewModel  healthInfoUpdateViewModel);
        List<StudentHealthInfoSearchMiddle> StudentSearchHealthRegisterInfo(StudentSearchHealthInfo studentSearchHealthInfo);
        List<EmployHealthInfoSearchMiddle> EmploySearchHealthRegisterInfo(EmploySearchHealthInfo employSearchHealthInfo);
    }
}
