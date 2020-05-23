using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.ServiceDTO.SmallRoutine;

namespace Dto.IRepository.SmallRoutine
{
    public interface ISchoolInfoRepository : IRepository<School_Info>
    {
        void AddList(List<School_Info>  school_Infos);
        void AddListBase(List<School_Info> schoolInsertList);

        //验证是否学校信息是否存在
        bool CheckInfo(string code, string name);

        bool CheckInfoByname(string name);
        School_Info GetSchoolCodeByName(string v);
      
    }
}
