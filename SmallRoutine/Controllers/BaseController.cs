using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.SmallRoutine;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.SmallRoutine;

namespace SmallRoutine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IFIileService _fileService;
        private readonly IBaseService _baseService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public BaseController(IFIileService fileService, IBaseService baseService, IHostingEnvironment hostingEnvironment)
        {
            _fileService = fileService;
            _baseService = baseService;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 文件上传并导入数据（学生）
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("/StudentInfoUpload")]
        public ActionResult UploadFile_Student_Info(IFormFile file)
        {
            FileUploadViewModel fileUploadViewModel = new FileUploadViewModel();
            var files = Request.Form.Files;
            String filePath = "";//上传文件的路径

            if (files.Count == 0)
            {
                throw new ArgumentException("找不到上传的文件");
            }
            // full path to file in temp location
            foreach (var formFile in files)
            {
                string randomname = _fileService.fileRandName(formFile.FileName);
                filePath = Directory.GetCurrentDirectory() + "\\files\\" + randomname;
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }
                }
                fileUploadViewModel.FileName = formFile.FileName;
                //fileUploadViewModel.Url = "http://60.28.108.84:3000/toufiles/" + formFile.FileName;
                //fileUploadViewModel.Url = "https://bhteda.com.cn/toufiles/" + formFile.FileName;
                fileUploadViewModel.PhysisticName = randomname;
                _fileService.SaveFileInfo(fileUploadViewModel);
                _fileService.InputWhiteListIntoDataBase(filePath, randomname);

            }
            return Ok("导入成功");

        }


        /// <summary>
        /// 文件上传并导入数据（员工）
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("/facultystaffInfo")]
        public ActionResult UploadFile_facultystaffInfo(IFormFile file)
        {
            FileUploadViewModel fileUploadViewModel = new FileUploadViewModel();
            var files = Request.Form.Files;
            String filePath = "";//上传文件的路径

            if (files.Count == 0)
            {
                throw new ArgumentException("找不到上传的文件");
            }
            // full path to file in temp location
            foreach (var formFile in files)
            {
                string randomname = _fileService.fileRandName(formFile.FileName);
                filePath = Directory.GetCurrentDirectory() + "\\files\\" + randomname;
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }
                }
                fileUploadViewModel.FileName = formFile.FileName;
                fileUploadViewModel.PhysisticName = randomname;
                _fileService.SaveFileInfo(fileUploadViewModel);
                _fileService.InputWhiteListIntoDataBase_facultystaffInfo(filePath, randomname);

            }
            return Ok("导入成功");

        }


        /// <summary>
        /// 结构化基础数据
        /// </summary>
        /// <returns></returns>
        [HttpPost("/struct/StructDatabase")]
        public ActionResult StructDatabase()
        {
            _baseService.structSystemInfo();
            return Ok();
        }


        /// <summary>
        /// 结构化基础数据
        /// </summary>
        /// <returns></returns>
        [HttpPost("/struct/GenerateUserLoginInfo")]
        public ActionResult GenerateUserLoginInfo()
         {
            _baseService.structUserInfo();
            return Ok();

        }


    }
}