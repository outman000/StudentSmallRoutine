using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.StatasticViewModel
{
    public class StudentAndEmployeeReportResModel
    {

        public bool IsSuccess;
        /// <summary>
        /// 数据列表
        /// </summary>
        public List<StudentAndEmployeeReportMiddles> studentAndEmployeeReportMiddles;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public StudentAndEmployeeReportResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
