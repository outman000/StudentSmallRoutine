﻿using System;
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
        /// <param name="studentStasticSearchViewModel"></param>
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
    }
}