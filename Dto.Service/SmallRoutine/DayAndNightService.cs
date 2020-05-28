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
        private readonly ISchoolInfoRepository _schoolInfoRepository;
        private readonly IGradeInfoRepository _gradeInfoRepository;
        private readonly IClassInfoRepository _classInfoRepository;
        private readonly IUserInfoRepository _userInfoRepository;

        public DayAndNightService(IDayandNightRepository dayandNightRepository, IStaffClassRelateRepository staffClassRelateRepository, IMapper mapper, ISchoolInfoRepository _schoolInfoRepository, IGradeInfoRepository _gradeInfoRepository, IClassInfoRepository _classInfoRepository, IUserInfoRepository _userInfoRepository)
        {
            this.dayandNightRepository = dayandNightRepository;
            this.staffClassRelateRepository = staffClassRelateRepository;
            this.mapper = mapper;
            this._schoolInfoRepository = _schoolInfoRepository;
            this._gradeInfoRepository = _gradeInfoRepository;
            this._classInfoRepository = _classInfoRepository;
            this._userInfoRepository = _userInfoRepository;
        }
        //添加晨午晚检信息
        public BaseViewModel addDayAndNightInfo(DayAndNightSearchViewModel dayAndNightSearchViewModel)
        {
            BaseViewModel viewModel = new BaseViewModel();
            if (String.IsNullOrEmpty(dayAndNightSearchViewModel.SchoolName) || String.IsNullOrEmpty(dayAndNightSearchViewModel.Name) || String.IsNullOrEmpty(dayAndNightSearchViewModel.GradeName) || String.IsNullOrEmpty(dayAndNightSearchViewModel.ClassName) || String.IsNullOrEmpty(dayAndNightSearchViewModel.Temperature) || String.IsNullOrEmpty(dayAndNightSearchViewModel.IsComeSchool) || String.IsNullOrEmpty(dayAndNightSearchViewModel.tag))
            {
                viewModel.ResponseCode = 2;
                viewModel.Message = "参数信息为空";
            }
            else
            {
                try
                {
                    //验证 学校是否存在
                    if (_schoolInfoRepository.CheckInfoByname(dayAndNightSearchViewModel.SchoolName))
                    {
                        Student_DayandNight_Info info = new Student_DayandNight_Info();

                        info = mapper.Map<DayAndNightSearchViewModel, Student_DayandNight_Info>(dayAndNightSearchViewModel);
                        info.AddTimeInterval = DateTime.Now.ToString();
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
                    else
                    {
                        viewModel.ResponseCode = 4;
                        viewModel.Message = "学校信息不存在";
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
