using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.HealthEveryViewModel;

namespace Dto.IService.SmallRoutine
{
    public interface IHealthService
    {
        void addHealthEveryRegisterInfo(HealthEveryAddViewModel  healthEveryAddViewModel);
        void collectionHealthEveryRegisterInfo(HealthEveryCollectionViewModel healthEveryAddViewModel);

        void DeleteHealthEveryRegisterInfo(HealthEveryDeleteViewModel  healthEveryDeleteViewModel);

        List<HealthEverySearchMiddleModel> SearchHealthEveryRegisterInfo(HealthEverySearchViewModel  healthEverySearchViewModel);

        void UpdateHealthEveryRegisterInfo(HealthEveryUpdateViewModel  healthEveryUpdateViewModel);

    }
}
