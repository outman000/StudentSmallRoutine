using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.RequestViewModel;
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
        facultystaff_Info GetStudentInfoAndHealthInfo(string Idnumber);

        //根据id获取教职工信息
        facultystaff_Info getbyID(int id);
         
        //删除信息
        void RemoveInfo(facultystaff_Info info);
        //根据条件查询
        List<facultystaff_Info> GetByModel(FacultystaffSearchModel model);
        facultystaff_Info getByidNumber(string idnumber);
    }
}
