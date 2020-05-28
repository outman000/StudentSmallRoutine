using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.SmallRoutine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmallRoutine.Application;
using ViewModel.SmallRoutine.RequestViewModel.StatasticViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.StatasticViewModel;

namespace SmallRoutine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService   istatisticsService;
        private readonly IStudentReportQueries _studentReportQueries;

        public StatisticsController(IStatisticsService statisticsService, IStudentReportQueries studentReportQueries)
        {
            istatisticsService = statisticsService;
            _studentReportQueries = studentReportQueries;
        }

        [HttpPost("/report/StudentBaseReport")]

        public ActionResult<StudentBaseResModel> getStudentBaseTemplate(BaseStudentStasticViewModel baseStudentStasticViewModel)
        {
            StudentBaseResModel studentBaseResModel = new StudentBaseResModel();

            studentBaseResModel.studentComtemlateMiddles = istatisticsService.getBaseComtemplateInfo(baseStudentStasticViewModel);
            studentBaseResModel.IsSuccess = true;
            studentBaseResModel.baseViewModel.Message = "查询成功";
            studentBaseResModel.baseViewModel.ResponseCode = 200;
            return Ok(studentBaseResModel);
        }

        [HttpPost("/report/EmployBaseReport")]

        public ActionResult<EmployBaseResModel> getEmployBaseTemplate(BaseStudentStasticViewModel baseStudentStasticViewModel)
        {
            EmployBaseResModel employBaseResModel = new EmployBaseResModel();

            employBaseResModel.employComtemlateMiddles = istatisticsService.getBaseComtemplateInfoEmploy(baseStudentStasticViewModel);
            employBaseResModel.IsSuccess = true;
            employBaseResModel.baseViewModel.Message = "查询成功";
            employBaseResModel.baseViewModel.ResponseCode = 200;
            return Ok(employBaseResModel);
        }

        /// <summary>
        /// 获取某一个学校下的教职员工和学生数据
        /// </summary>
        /// <param name="studentStasticSearchViewModel">查询模型</param>
        /// <returns></returns>
        [HttpPost("/report/GetSecondListReport")]
        public ActionResult<StudentReportResModel> GetSecondListReport(StudentStasticSearchViewModel studentStasticSearchViewModel)
        {
            try
            {
                StudentReportResModel result = new StudentReportResModel();
                var listStudent = _studentReportQueries.GetStudentReportList(studentStasticSearchViewModel);
                var listEmployee = _studentReportQueries.GetEmployeeeReportList(studentStasticSearchViewModel);

                result.studentComtemlateMiddles = listStudent;
                result.employReportMiddles = listEmployee;
                result.IsSuccess = true;
                result.baseViewModel.Message = "查询成功";
                result.baseViewModel.ResponseCode = 200;
                return Ok(result);
            }
            catch(Exception e)
            {
                return NotFound("系统错误请联系管理员");
            }
        }

        /// <summary>
        /// 获取教职员工及学生总体数据
        /// </summary>
        /// <param name="studentStasticSearchViewModel">查询模型</param>
        /// <returns></returns>
        [HttpPost("/report/GetStudentAndEmployeeListReport")]
        public ActionResult<StudentAndEmployeeReportResModel> GetStudentAndEmployeeListReport(StudentStasticSearchViewModel studentStasticSearchViewModel)
        {
            try
            {
                StudentAndEmployeeReportResModel result = new StudentAndEmployeeReportResModel();
                var list = _studentReportQueries.GetListBySearchModel(studentStasticSearchViewModel);
                result.studentAndEmployeeReportMiddles = list;
                result.IsSuccess = true;
                result.baseViewModel.Message = "查询成功";
                result.baseViewModel.ResponseCode = 200;

                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound("系统错误请联系管理员");
            }

        }

        /// <summary>
        /// 统计头部数据 复课学校、学生、教职工
        /// </summary>
        /// <param name="studentStasticSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost("reprot/GetSchoolAndStudentTop")]
        public ActionResult<SchoolAndStudentTopReportResModel> GetSchoolAndStudentTop(StudentStasticSearchViewModel studentStasticSearchViewModel)
        {
            try
            {
                SchoolAndStudentTopReportResModel result = new SchoolAndStudentTopReportResModel();
                var info = _studentReportQueries.GetStudentTopReportMiddleModel(studentStasticSearchViewModel);
                result.IsSuccess = true;
                result.schoolAndStudentTopReportMiddleModel = info;
                result.baseViewModel.ResponseCode = 200;
                result.baseViewModel.Message = "数据查询成功";
                return Ok(result);
            }
            catch(Exception ex)
            {
                return NotFound("系统问题请联系管理员");
            }
        }
        /// <summary>
        /// 统计  健康情况数据 包含健康填报率情况
        /// </summary>
        /// <param name="studentStasticSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost("report/GetHealStatisticsReport")]
        public ActionResult<HealthReportResModel> GetHealStatisticsReport(StudentStasticSearchViewModel studentStasticSearchViewModel)
        {
            try
            {
                HealthReportResModel result = new HealthReportResModel();
                var info = _studentReportQueries.GetHealthStatisticsMiddleModel(studentStasticSearchViewModel);
                result.healthStatisticsMiddleModel = info;
                result.IsSuccess = true;
                result.baseViewModel.ResponseCode = 200;
                result.baseViewModel.Message = "数据查询成功";

                return Ok(result);
            }
            catch(Exception ex)
            {
                return NotFound("系统错误，请联系管理员");
            }
        }

        /// <summary>
        /// 获取学生未到校存在原因的信息
        /// </summary>
        /// <param name="SearchViewModel"></param>
        /// <returns></returns>
        [HttpPost("report/GetStudentNoComSchool")]
        public ActionResult<HealthNoComSchoolResModel> GetStudentNoComSchool(HealthEverySearchStatasticViewModel SearchViewModel)
        {
            try
            {
                HealthNoComSchoolResModel result = new HealthNoComSchoolResModel();
                var info = _studentReportQueries.GetHealthEverySearchMiddleModels(SearchViewModel, "学生");
                int totalNum= _studentReportQueries.GetHealthEverySearchMiddleModelsTotal(SearchViewModel, "学生");
                result.healthEverySearchMiddleModels = info;
                result.TotalNum = totalNum;
                result.IsSuccess = true;
                result.baseViewModel.ResponseCode = 200;
                result.baseViewModel.Message = "数据查询成功";

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound("系统错误，请联系管理员");
            }
        }

        /// <summary>
        /// 获取教职工未到校存在原因的信息
        /// </summary>
        /// <param name="SearchViewModel"></param>
        /// <returns></returns>
        [HttpPost("report/GetTeachNoComSchool")]
        public ActionResult<HealthNoComSchoolResModel> GetTeachNoComSchool(HealthEverySearchStatasticViewModel SearchViewModel)
        {
            try
            {
                HealthNoComSchoolResModel result = new HealthNoComSchoolResModel();
                var info = _studentReportQueries.GetHealthEverySearchMiddleModels(SearchViewModel, "教职工");
                int totalNum = _studentReportQueries.GetHealthEverySearchMiddleModelsTotal(SearchViewModel, "教职工");
                result.healthEverySearchMiddleModels = info;
                result.TotalNum = totalNum;
                result.IsSuccess = true;
                result.baseViewModel.ResponseCode = 200;
                result.baseViewModel.Message = "数据查询成功";

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound("系统错误，请联系管理员");
            }
        }

        /// <summary>
        /// 获取学校学生健康信息上报情况
        /// </summary>
        /// <param name="SearchViewModel"></param>
        /// <returns></returns>
        [HttpPost("report/GetHealthInfoStatasticReportResModel")]
       public ActionResult<HealthInfoStatasticReportResModel> HealthInfoStatasticReportResModel(StudentStasticSearchViewModel SearchViewModel)
        {
            try
            {
                HealthInfoStatasticReportResModel result = new HealthInfoStatasticReportResModel();
                var info = _studentReportQueries.GetHealthInfoStatasticMiddles(SearchViewModel);
                result.healthInfoStatasticMiddles = info;
                result.baseViewModel.ResponseCode = 200;
                result.baseViewModel.Message = "数据查询成功";
                return Ok(result);
            }
            catch(Exception ex)
            {
                return NotFound("系统错误，请联系管理员");
            }
        }
    }
}