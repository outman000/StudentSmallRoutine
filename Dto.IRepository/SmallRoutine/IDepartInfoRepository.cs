using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.ServiceDTO.SmallRoutine;

namespace Dto.IRepository.SmallRoutine
{
    public  interface IDepartInfoRepository:IRepository<Depart_Info>
    {
        void AddListBase(List<Depart_Info> departInsertList);
    }
}
