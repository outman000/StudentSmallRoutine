using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;


namespace ViewModel.SmallRoutine.ResponseViewModel.StaffClassRelateViewModel
{
    public class StaffTeacherClassRelateSearchResModel
    {
        public bool IsSuccess;
        public List<TeacherSearchClassMiddle>  teacherSearchClassMiddles;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public StaffTeacherClassRelateSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
