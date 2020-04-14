using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.ServiceDTO.SmallRoutine;

namespace Dto.IRepository.SmallRoutine
{
    public   interface IStationInfoRepository:IRepository<Station_Info>
    {
        void AddListBase(List<Station_Info> classInsertList);
    }
}
