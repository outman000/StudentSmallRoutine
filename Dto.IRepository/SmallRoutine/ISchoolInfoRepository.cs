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
    }
}
