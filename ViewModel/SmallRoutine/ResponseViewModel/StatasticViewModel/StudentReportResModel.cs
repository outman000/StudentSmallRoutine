using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.StatasticViewModel
{
    public class StudentReportResModel
    {
        public bool IsSuccess;
        /// <summary>
        /// 学生列表
        /// </summary>
        public List<StudentReportMiddle> studentComtemlateMiddles;
        /// <summary>
        /// 教职员工列表
        /// </summary>
        public List<EmployeeReportMiddleModel> employReportMiddles;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public StudentReportResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
