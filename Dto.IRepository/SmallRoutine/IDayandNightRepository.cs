using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.RequestViewModel.DayAndNightViewModel;

namespace Dto.IRepository.SmallRoutine
{
    public interface IDayandNightRepository: IRepository<Student_DayandNight_Info>
    {
        void AddList(List<Student_DayandNight_Info> obj);

        void   RemoveList(List<int> ids);
         
        List<Student_DayandNight_Info> SearchDayAndNightList(DayAndNightSearchViewModel dayAndNightSearchViewModel); 
        List<Student_DayandNight_Info> CheckDayAndNightList(DayAndNightCheckViewModel dayAndNightSearchViewModel);
        List<Student_DayandNight_Info> getInfoByTag(string tag);
        void deleteRange(List<Student_DayandNight_Info> list);
    }
}
