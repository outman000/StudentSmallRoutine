using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.HealthEveryViewModel;

namespace Dto.IRepository.SmallRoutine
{
    public interface IHealthRepository :IRepository<Health_Info>
    {
        void DelByList(List<int> deleteList);

        List<Health_Info> SearchHealthEveryRegisterInfo(HealthEverySearchViewModel healthEverySearchViewModel);
        Health_Info getByidNumber(string idNumber);
        bool existhealthInfo(HealthEveryAddViewModel healthEveryAddViewModel);
        bool collectionexisthealthInfo(HealthEveryCollectionViewModel healthEveryAddViewModel);
    }
}
