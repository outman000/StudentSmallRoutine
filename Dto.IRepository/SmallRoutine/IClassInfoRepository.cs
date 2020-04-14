using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.ServiceDTO.SmallRoutine;

namespace Dto.IRepository.SmallRoutine
{
    public interface IClassInfoRepository : IRepository<Class_Info>
    {
        void AddList(List<Class_Info>  class_Infos);
        void AddListBase(List<Class_Info> classInsertList);
    }
}
