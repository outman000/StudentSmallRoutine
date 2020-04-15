using AutoMapper;
using Dto.IService.SmallRoutine;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.RequestViewModel.HealthViewModel;

namespace Dto.Service.SmallRoutine
{
    public class HealthRegisterService : IHealthRegisterService
    {
        private readonly IMapper _IMapper;



        public void addHealthRegisterInfo(HealthInfoAddViewModel healthViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
