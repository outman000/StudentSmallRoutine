using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.HealthEveryViewModel;

namespace Dto.Service.SmallRoutine
{
    public class HealthService: IHealthService
    {
        private readonly IMapper _IMapper;
        private readonly IHealthRepository  healthRepository;

        public HealthService(IMapper iMapper, IHealthRepository  healthRepository)
        {
            _IMapper = iMapper;
            this.healthRepository = healthRepository;
        }
        //Health_Info
        public void addHealthEveryRegisterInfo(HealthEveryAddViewModel healthEveryAddViewModel)
        {

            var insertInfo = _IMapper.Map<HealthEveryAddViewModel, Health_Info>(healthEveryAddViewModel);

            healthRepository.Add(insertInfo);

            healthRepository.SaveChanges();

        }

        public void DeleteHealthEveryRegisterInfo(HealthEveryDeleteViewModel healthEveryDeleteViewModel)
        {
            healthRepository.DelByList(healthEveryDeleteViewModel.DeleteList);
            healthRepository.SaveChanges();
        }

        public List<HealthEverySearchMiddleModel> SearchHealthEveryRegisterInfo(HealthEverySearchViewModel healthEverySearchViewModel)
        {
            var result = healthRepository.SearchHealthEveryRegisterInfo(healthEverySearchViewModel);
            var searchresult = _IMapper.Map<List<Health_Info>, List<HealthEverySearchMiddleModel>>(result);
            return searchresult;
        }

        public void UpdateHealthEveryRegisterInfo(HealthEveryUpdateViewModel healthEveryUpdateViewModel)
        {
            var updateInfo = _IMapper.Map<HealthEveryUpdateViewModel, Health_Info>(healthEveryUpdateViewModel);
            healthRepository.Update(updateInfo);
            healthRepository.SaveChanges();
        }
    }
}
