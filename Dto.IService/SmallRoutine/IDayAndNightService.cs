using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.DayAndNightViewModel;

namespace Dto.IService.SmallRoutine
{
    public interface IDayAndNightService
    { 

        void UpdateIDayAndNightService(DayAndNightUpdateViewModel dayAndNightUpdateViewModel );

        void RemveIDayAndNightService(List<int> obj);

        List<DayandNightInfoMiddle> SearchDayAndNightListService(DayAndNightSearchViewModel dayAndNightSearchViewModel);
    }
}
