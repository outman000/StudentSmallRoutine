using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.SmallRoutine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.SmallRoutine.RequestViewModel.HealthViewModel;

namespace SmallRoutine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthInfoController : Controller
    {
        private readonly IHealthRegisterService healthRegisterService;

        public HealthInfoController(IHealthRegisterService healthRegisterService)
        {
            this.healthRegisterService = healthRegisterService;
        }

        [HttpPost]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost("/HealthRegister/add")]
        // GET: HealthInfo/Details/5
        public ActionResult AddHealthRegisterAdd(HealthInfoAddViewModel healthViewModel)
        {
            Dtol.Helper. MD5.Decrypt("3d3e479b1039aca0a7dc9177597d5030");
            healthRegisterService.addHealthRegisterInfo(healthViewModel);
            return Ok();
        }

     
    }
}