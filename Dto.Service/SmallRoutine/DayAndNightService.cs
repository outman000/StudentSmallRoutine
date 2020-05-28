using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.DayAndNightViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.DayAndNightViewModel;

namespace Dto.Service.SmallRoutine
{
   public   class DayAndNightService: IDayAndNightService
    {
        private readonly IDayandNightRepository  dayandNightRepository;
        private readonly IStaffClassRelateRepository staffClassRelateRepository;
        private readonly IMapper mapper;

        public DayAndNightService(IDayandNightRepository dayandNightRepository, IStaffClassRelateRepository staffClassRelateRepository, IMapper mapper)
        {
            this.dayandNightRepository = dayandNightRepository;
            this.staffClassRelateRepository = staffClassRelateRepository;
            this.mapper = mapper;
        }
        //添加晨午晚检信息
        public BaseViewModel addDayAndNightInfo(DayAndNightDefaultViewModel dayAndNightSearchViewModel)
        {
            BaseViewModel viewModel = new BaseViewModel();
            if (String.IsNullOrEmpty(dayAndNightSearchViewModel.SchoolName) || String.IsNullOrEmpty(dayAndNightSearchViewModel.Name) || String.IsNullOrEmpty(dayAndNightSearchViewModel.GradeName) || String.IsNullOrEmpty(dayAndNightSearchViewModel.ClassName))
            {
                viewModel.ResponseCode = 2;
                viewModel.Message = "参数信息为空";
            }
            else
            {
                if (dayAndNightSearchViewModel.IsComeSchool == "是")
                {
                    if (String.IsNullOrEmpty(dayAndNightSearchViewModel.Temperature) || String.IsNullOrEmpty(dayAndNightSearchViewModel.AddTimeInterval))
                    {
                        viewModel.ResponseCode = 2;
                        viewModel.Message = "参数信息为空";
                        return viewModel;
                    }
                }
                else
                {
                    if (String.IsNullOrEmpty(dayAndNightSearchViewModel.NotComeJinReason))
                    {
                        viewModel.ResponseCode = 2;
                        viewModel.Message = "参数信息为空";
                        return viewModel;
                    }
                }
                try
                {
                    Student_DayandNight_Info info = new Student_DayandNight_Info();

                    info = mapper.Map<DayAndNightDefaultViewModel, Student_DayandNight_Info>(dayAndNightSearchViewModel);
                    if (dayAndNightSearchViewModel.IsComeSchool == "否")
                    {
                        info.Temperature="";
                        info.AddTimeInterval = "";
                    }
                    info.AddCreateDate = DateTime.Now;
                    dayandNightRepository.Add(info);

                    int i = dayandNightRepository.SaveChanges();
                    if (i > 0)
                    {
                        viewModel.ResponseCode = 0;
                        viewModel.Message = "晨午晚检信息添加成功";
                    }
                    else
                    {
                        viewModel.ResponseCode = 1;
                        viewModel.Message = "晨午晚检信息添加失败";
                    }
                }
                catch (Exception ex)
                {
                    viewModel.ResponseCode = 3;
                    viewModel.Message = "出现异常";
                }

            }
            return viewModel;
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
        public List<DefaultDayAndNightMiddle> DefaultSearchDayAndNightListService(DayAndNightDefaultSearchViewModel  dayAndNightDefaultSearchViewModel)
        {
            return  staffClassRelateRepository.GetDefaultStudentsInfosByStaff(dayAndNightDefaultSearchViewModel);
        }
    }
}
