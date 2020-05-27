using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.ServiceDTO.SmallRoutine;

namespace Dto.IRepository.SmallRoutine
{
    public interface IGradeInfoRepository : IRepository<Grade_Info>
    {
        void AddList(List<Grade_Info>  grade_Infos);
        void AddListBase(List<Grade_Info> gradeInsertList);

        //验证是否年级信息是否存在
        bool CheckInfo(string code, string name);
        List<Grade_Info> getclassInfoBycode(string code);
        Grade_Info GetGradeCodeBySchoolCode(School_Info school_Info, string v);
    }
}
