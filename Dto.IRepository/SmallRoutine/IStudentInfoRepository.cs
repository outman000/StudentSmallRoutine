using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.ServiceDTO.SmallRoutine;

namespace Dto.IRepository.SmallRoutine
{
    public interface IStudentInfoRepository : IRepository<School_Info>
    {
        void AddList(List<Student_Info> studentInfo);
        /// <summary>
        /// 获取基础数据中的所有学校
        /// </summary>
        /// <param name="studentInfo"></param>
        /// <returns></returns>
        List<SchoolInfoServiceDTO> GetSchoolList();
        /// <summary>
        /// 获取基础数据中的所有年级
        /// </summary>
        /// <param name="studentInfo"></param>
        /// <returns></returns>
        List<GradeInfoServiceDTO> GetGradeList();
        /// <summary>
        /// 获取基础数据中的所有班级
        /// </summary>
        /// <param name="studentInfo"></param>
        /// <returns></returns>
        List<ClassInfoServiceDTO> GetClasslList();




    }
}
