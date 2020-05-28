using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.StatasticViewModel;

namespace SmallRoutine.Application
{
    public interface IStudentReportQueries
    {
        List<EmployeeReportMiddleModel> GetEmployeeeReportList(StudentStasticSearchViewModel searchModel);
        List<StudentReportMiddle> GetStudentReportList(StudentStasticSearchViewModel searchModel);
        List<StudentAndEmployeeReportMiddles> GetListBySearchModel(StudentStasticSearchViewModel searchModel);
        SchoolAndStudentTopReportMiddleModel GetStudentTopReportMiddleModel(StudentStasticSearchViewModel searchModel);
        HealthStatisticsMiddleModel GetHealthStatisticsMiddleModel(StudentStasticSearchViewModel searchModel);
    }
}
