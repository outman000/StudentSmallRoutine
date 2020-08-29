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
        List<Class_Info> getclassInfoBycode(string code);
        Class_Info GetClassCodeByGradeCode(Grade_Info gradeCode, string v);


        //根据code查找name 20200828
         Class_Info getNameInfoBycode(string code);
    }
}
