using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

using ViewModel.SmallRoutine.RequestViewModel;

namespace Dto.IService.SmallRoutine
{
    public interface IStudentService
    {

        //添加学生信息 
        BaseViewModel addStudentInfo(StudentBaseModel student);


        //根据 id 删除 学生信息
        BaseViewModel delStudentInfo(int id);


        //修改 学生信息
        BaseViewModel updateStudentInfo(StudentMiddle student);


        //根据条件查询
        List<StudentMiddle> GetListByParas(StudentSearchModel model);


        //根据 id 批量删除 学生信息
        BaseViewModel batchdelStudentInfo(List<int> ids, string memo);


        //根据 id 批量学生 信息批量 升班
        BaseViewModel BatchChangeStudentInfo(StudentChangeInfo model);

        //获取该年级班级的 学生总数
        BaseViewModel GetStudentTotalByGC(string GradeCode, string ClassCode);

    }
}
