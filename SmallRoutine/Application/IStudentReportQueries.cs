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
        /// <summary>
        /// 获取学生或老师健康信息
        /// </summary>
        /// <param name="searchModel"></param>
        /// <param name="type"></param>
        /// <param name="IsComeSchool">是、否</param>
        /// <param name="Temperature"></param>
        /// <returns></returns>
        List<HealthEverySearchMiddleModel> GetHealthEverySearchMiddleModels(HealthEverySearchStatasticViewModel searchModel, string type, string IsComeSchool, string Temperature);
        int GetHealthEverySearchMiddleModelsTotal(HealthEverySearchStatasticViewModel searchModel, string type, string IsComeSchool, string Temperature);
        List<HealthInfoStatasticMiddleModel> GetHealthInfoStatasticMiddles(StudentStasticSearchViewModel searchModel);
        HealthInfoFollowStatasticMiddleModel GetHealthInfoFollowStatastic(StudentStasticSearchViewModel searchModel);
        List<HealthEverySearchMiddleModel> GetStudentComeSchoolHealthInfo(HealthEverySearchStatasticViewModel searchModel, string type, string IsComeSchool, string Temperature);
        int GetStudentComeSchoolHealthInfoTotal(HealthEverySearchStatasticViewModel searchModel, string type, string IsComeSchool, string Temperature);
    }
}
