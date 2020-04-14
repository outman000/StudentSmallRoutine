using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.ServiceDTO.SmallRoutine;

namespace Dto.IRepository.SmallRoutine
{
     public interface IFacultystaffInfoRepository : IRepository<facultystaff_Info>
    {
        void AddList(List<facultystaff_Info>  facultystaff_Infos);

        /// <summary>
        /// 获取基础数据中的所有年级
        /// </summary>
        /// <param name="studentInfo"></param>
        /// <returns></returns>
        List<DepartInfoServiceDTO> GetDepartList();
        /// <summary>
        /// 获取基础数据中的所有班级
        /// </summary>
        /// <param name="studentInfo"></param>
        /// <returns></returns>
        List<StationInfoServiceDTO> GetStationlList();
    }
}
