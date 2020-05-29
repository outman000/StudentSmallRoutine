using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.DayAndNightViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.DayAndNightViewModel;

namespace Dto.IService.SmallRoutine
{
    public interface IDayAndNightService
    {
        //添加晨午晚检信息 
        BaseViewModel addDayAndNightInfo(DayAndNightDefaultViewModel student);
        //批量添加晨午晚检信息 
        BaseViewModel addDayAndNightInfoList(DayAndNightAddListViewModel student);
        void UpdateIDayAndNightService(DayAndNightUpdateViewModel dayAndNightUpdateViewModel );

        void RemveIDayAndNightService(List<int> obj);

        List<DayandNightInfoMiddle> SearchDayAndNightListService(DayAndNightSearchViewModel dayAndNightSearchViewModel);
        List<DefaultDayAndNightMiddle> DefaultSearchDayAndNightListService(DayAndNightDefaultSearchViewModel  dayAndNightDefaultSearchViewModel);
    }
}
