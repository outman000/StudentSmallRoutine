using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.StaffClassRelateViewModel
{
    public class StaffTeacherClassRelateSearchAllResModel
    {
        public bool IsSuccess;
        public List<TeacherSearchClassAllMiddle>  teacherSearchClassAllMiddles;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public StaffTeacherClassRelateSearchAllResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
