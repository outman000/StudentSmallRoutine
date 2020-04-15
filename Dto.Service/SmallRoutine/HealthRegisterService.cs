using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.HealthViewModel;

namespace Dto.Service.SmallRoutine
{
    public class HealthRegisterService : IHealthRegisterService
    {
        private readonly IMapper _IMapper;
        private readonly IHealthRegisterRepository healthRegisterRepository;

        public HealthRegisterService(IMapper iMapper, IHealthRegisterRepository healthRegisterRepository)
        {
            _IMapper = iMapper;
            this.healthRegisterRepository = healthRegisterRepository;
        }
        /// <summary>
        /// 添加登记健康信息
        /// </summary>
        /// <param name="healthViewModel"></param>
        
        public void addHealthRegisterInfo(HealthInfoAddViewModel healthViewModel)
        {
            var insertInfo= _IMapper.Map<HealthInfoAddViewModel, StudentRegisterHeath_Info>(healthViewModel);
            healthRegisterRepository.Add(insertInfo);
            healthRegisterRepository.SaveChanges();
        }
        /// <summary>
        /// 删除登记健康信息
        /// </summary>
        /// <param name="healthInfoDeleteViewModel"></param>
        public void DeleteHealthRegisterInfo(HealthInfoDeleteViewModel healthInfoDeleteViewModel)
        {
          
            healthRegisterRepository.DelByList(healthInfoDeleteViewModel.DeleteList);
            healthRegisterRepository.SaveChanges();
        }
        /// <summary>
        /// 查询登记健康信息
        /// </summary>
        /// <param name="healthInfoSearchViewModel"></param>
        /// <returns></returns>

        public List<HealthInfoSearchMiddle> SearchHealthRegisterInfo(HealthInfoSearchViewModel healthInfoSearchViewModel)
        {
            var searchResult= healthRegisterRepository.searchHealthInfo(healthInfoSearchViewModel);
            var searchresult = _IMapper.Map<List<StudentRegisterHeath_Info>, List<HealthInfoSearchMiddle>>(searchResult);
            return searchresult;
        }
        /// <summary>
        /// 更新登记健康信息
        /// </summary>
        /// <param name="healthInfoUpdateViewModel"></param>
        public void UpdateHealthRegisterInfo(HealthInfoUpdateViewModel healthInfoUpdateViewModel)
        {
            var insertInfo = _IMapper.Map<HealthInfoUpdateViewModel, StudentRegisterHeath_Info>(healthInfoUpdateViewModel);
            healthRegisterRepository.Update(insertInfo);
            healthRegisterRepository.SaveChanges();
        }



    }
}
