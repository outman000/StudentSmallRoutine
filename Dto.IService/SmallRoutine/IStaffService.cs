using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace Dto.IService.SmallRoutine
{
    public interface IStaffService
    {
        List<StationInfoSearchMiddleModel> GetClassKey(String Code);
    }
}
