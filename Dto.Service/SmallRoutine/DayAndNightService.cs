using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.DayAndNightViewModel;

namespace Dto.Service.SmallRoutine
{
   public   class DayAndNightService: IDayAndNightService
    {
        private readonly IDayandNightRepository  dayandNightRepository;
        private readonly IMapper mapper;

        public DayAndNightService(IDayandNightRepository dayandNightRepository, IMapper mapper)
        {
            this.dayandNightRepository = dayandNightRepository;
            this.mapper = mapper;
        }

        public void RemveIDayAndNightService(List<int> obj)
        {
            dayandNightRepository.RemoveList(obj);
            dayandNightRepository.SaveChanges();
        }

        public List<DayandNightInfoMiddle> SearchDayAndNightListService(DayAndNightSearchViewModel dayAndNightSearchViewModel)
        {
            var searchResult= dayandNightRepository.SearchDayAndNightList(dayAndNightSearchViewModel);
            var result = mapper.Map<List<Student_DayandNight_Info>, List<DayandNightInfoMiddle>>(searchResult);
            return result;
        }

        public void UpdateIDayAndNightService(DayAndNightUpdateViewModel dayAndNightUpdateViewModel)
        {
            var update= mapper.Map<DayAndNightUpdateViewModel, Student_DayandNight_Info>(dayAndNightUpdateViewModel);
            dayandNightRepository.Update(update);
            dayandNightRepository.SaveChanges();
        }
    }
}
