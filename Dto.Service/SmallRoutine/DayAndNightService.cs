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
        private readonly ISchoolInfoRepository schoolInfoRepository;

        public DayAndNightService(IDayandNightRepository dayandNightRepository, IStaffClassRelateRepository staffClassRelateRepository
            , IMapper mapper, ISchoolInfoRepository schoolInfo)
        {
            this.dayandNightRepository = dayandNightRepository;
            this.staffClassRelateRepository = staffClassRelateRepository;
            this.mapper = mapper;
            schoolInfoRepository = schoolInfo;
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
        //批量添加晨午晚检信息
        public BaseViewModel addDayAndNightInfoList(DayAndNightAddListViewModel model)
        {
            BaseViewModel viewModel = new BaseViewModel();
            bool isok = true;
            List<DayAndNightAddListMiddle> list = model.dayAndNightAddListMiddles;
            for (int i = 0; i < list.Count; i++)
            {
                Student_DayandNight_Info info = new Student_DayandNight_Info();
                info = mapper.Map<DayAndNightAddListMiddle, Student_DayandNight_Info>(list[i]);
                if (String.IsNullOrEmpty(info.SchoolName) || String.IsNullOrEmpty(info.Name) || String.IsNullOrEmpty(info.GradeName) || String.IsNullOrEmpty(info.ClassName))
                {
                    viewModel.ResponseCode = 2;
                    viewModel.Message = "参数信息为空";
                    return viewModel;
                }
                else
                {
                    if (info.IsComeSchool == "是")
                    {
                        if (String.IsNullOrEmpty(info.Temperature) || String.IsNullOrEmpty(info.AddTimeInterval))
                        {
                            viewModel.ResponseCode = 2;
                            viewModel.Message = "体温或填报时段信息为空";
                            return viewModel;
                        }
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(info.NotComeJinReason))
                        {
                            viewModel.ResponseCode = 2;
                            viewModel.Message = "未到校原因信息为空";
                            return viewModel;
                        }
                        info.Temperature = "";
                        info.AddTimeInterval = "";
                    }
                    info.IdNumber = Dtol.Helper.MD5.Md5Hash(info.IdNumber);
                    info.tag = Dtol.Helper.MD5.Md5Hash(info.tag);
                    info.AddCreateDate = DateTime.Now;
                    dayandNightRepository.Add(info);
                    if (dayandNightRepository.SaveChanges() <= 0)
                    {
                        isok = false;
                    }
                }
            }
            if (isok)
            {
                viewModel.ResponseCode = 0;
                viewModel.Message = "晨午晚检信息添加成功";
            }
            else
            {
                viewModel.ResponseCode = 1;
                viewModel.Message = "晨午晚检信息添加失败";
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
            var schoolInfo = schoolInfoRepository.GetSchoolNameByCode(dayAndNightSearchViewModel.SchoolCode);
            if (schoolInfo != null)
                dayAndNightSearchViewModel.SchoolName = schoolInfo.SchoolName;
            var searchResult= dayandNightRepository.SearchDayAndNightList(dayAndNightSearchViewModel);
            var result = mapper.Map<List<Student_DayandNight_Info>, List<DayandNightInfoMiddle>>(searchResult);
            return result;
        }
        public List<DayandNightInfoMiddle> CheckDayAndNightListService(DayAndNightCheckViewModel dayAndNightSearchViewModel)
        {
            var searchResult = dayandNightRepository.CheckDayAndNightList(dayAndNightSearchViewModel);
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
