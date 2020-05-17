using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.SmallRoutine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.SmallRoutine.RequestViewModel.StatasticViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.StatasticViewModel;

namespace SmallRoutine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService   istatisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            istatisticsService = statisticsService;
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

    }
}