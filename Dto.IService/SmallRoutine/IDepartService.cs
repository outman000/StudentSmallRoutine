using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.DepartViewModel;

namespace Dto.IService.SmallRoutine
{
    public interface IDepartService
    {
        List<DepartInfoSearchMiddleModel> GetDepartKey(string code);
      
    }
}
