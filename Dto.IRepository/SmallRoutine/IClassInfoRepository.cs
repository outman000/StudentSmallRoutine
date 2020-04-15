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

        //验证是否班级信息是否存在
        bool CheckInfo(string code, string name);
    }
}
