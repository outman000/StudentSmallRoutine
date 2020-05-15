using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SmallRoutine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService StatisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            StatisticsService = statisticsService;
        }
    }
}