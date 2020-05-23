using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel;
using ViewModel.SmallRoutine.RequestViewModel.BaseControlViewModel;
using ViewModel.SmallRoutine.ResponseViewModel;
using ViewModel.SmallRoutine.ServiceDTO.SmallRoutine;

namespace Dto.IRepository.SmallRoutine
{
    public interface IStudentInfoRepository : IRepository<Student_Info>
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
        /// <summary>
        /// 获取用户信息保活健康信息，每日健康信息等
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>


        Student_Info GetStudentInfoAndHealthInfo(String Idnumber);


        //根据id获取学生信息
        Student_Info getbyID(int id);
        Student_Info getByidNumber(string idnumber);

        //删除信息
        void RemoveInfo(Student_Info info);

        //根据条件查询
        List<Student_Info> GetByModel(StudentSearchModel model);
        List<ClassInfoSearchMiddleModel> GetClasslListContainId(GradeAndClassSearchViewModel gradeAndClassSearchViewModel);
        List<GradeInfoSearchMiddleModel> GetGradeListContainId(GradeAndClassSearchViewModel gradeAndClassSearchViewModel);
        void flushStudentClassId();


        List<StudentIdnumberDTO> GetByAllIdnumbers();
        List<Student_Info> getAllClassByCode(string classCode);
    }
}
