using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.RequestViewModel.HealthViewModel;

namespace Dto.IRepository.SmallRoutine
{
    public interface IHealthRegisterRepository : IRepository<StudentRegisterHeath_Info>
    {
        void DelByList(List<int> deleteList);
        List<StudentRegisterHeath_Info> searchHealthInfo(HealthInfoSearchViewModel healthInfoSearchViewModel);
    }
}
