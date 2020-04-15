using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.PublicViewModel;
using ViewModel.SmallRoutine.RequestViewModel;

namespace Dto.IService.SmallRoutine
{
    public interface IStudentService
    {

        //添加学生信息 
        BaseViewModel addStudentInfo(StudentAddModel student);
    }
}
