using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.RequestViewModel
{
    public class StudentChangeInfo
    {
        //学生信息id数组
        public List<int> ids { set; get; }
        //修改后年级
        public string GradeCode { set; get; }
        //修改后班级
        public string ClassCode { set; get; }
        //备注
        public string Memo { set; get; }
    }
}
