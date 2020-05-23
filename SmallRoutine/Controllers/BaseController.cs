using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.SmallRoutine;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using SystemFilter.PublicFilter;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel;
using ViewModel.SmallRoutine.RequestViewModel.BaseControlViewModel;
using ViewModel.SmallRoutine.RequestViewModel.DayAndNightViewModel;
using ViewModel.SmallRoutine.ResponseViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.BaseControlViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.FileViewModel;

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
      /// 上传图片
      /// </summary>
      /// <param name="file"></param>
      /// <param name="IdNumber"></param>
      /// <returns></returns>
        [HttpPost("/UploadImage")]
        public ActionResult UploadFile_Image(IFormFile file,String IdNumber)
        {
            FileImageUploadViewModel fileUploadViewModel = new FileImageUploadViewModel();
            ImageUploadResModel imageUploadResModel = new ImageUploadResModel();

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

                filePath = _hostingEnvironment.WebRootPath + "\\files\\" + formFile.FileName;

                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }
                }
                fileUploadViewModel.Idnumber = IdNumber;
                fileUploadViewModel.FileName = formFile.FileName;
                fileUploadViewModel.PhysisticName = randomname;
                fileUploadViewModel.Path = filePath;
                fileUploadViewModel.Url = Request.Scheme+"://"+ Request.Host+"/files/" + formFile.FileName;


                imageUploadResModel.key= _fileService.SaveImageFileInfo(fileUploadViewModel);//上传成功
            }

            if (imageUploadResModel.key == 0)
            {
                imageUploadResModel.IsSuccess = true;
                imageUploadResModel.baseViewModel.Message = "身份证号不存在";
                imageUploadResModel.baseViewModel.ResponseCode = 204;
                return Ok(imageUploadResModel);
            }
            else
            {
                imageUploadResModel.IsSuccess = true;
                imageUploadResModel.baseViewModel.Message = "上传图片成功";
                imageUploadResModel.baseViewModel.ResponseCode = 200;
                return Ok(imageUploadResModel);
            }
           

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
        /// 文件上传并导入数据（早午晚检学生）
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("/StudentInfoDayAndNightUpload")]
        public ActionResult UploadFile_StudentInfoTimeInterval(IFormFile file,String idNumber)
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
                fileUploadViewModel.upload_percent = Dtol.Helper.MD5.Md5Hash(idNumber);
                _fileService.SaveFileInfo(fileUploadViewModel);
                _fileService.InputStudentInfoTimeIntervalIntoDataBase(filePath, randomname);

            }
            return Ok("导入成功");

        }
        /// <summary>
        /// 文件上传并导入数据（早午晚检学生）带验证
        /// </summary>
        /// <param name="file"></param>
        /// <param name="idNumber"></param>
        /// <returns></returns>
        [HttpPost("/StudentInfoDayAndNightUploadValide")]
        public ActionResult UploadFile_StudentInfoTimeIntervalValide(IFormFile file, String idNumber)
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
                fileUploadViewModel.upload_percent = Dtol.Helper.MD5.Md5Hash(idNumber);
                var model= _fileService.SaveFileInfo(fileUploadViewModel);
                var result=  _fileService.InputStudentInfoTimeIntervalIntoDataBaseValide(filePath, randomname, idNumber);
                if (!result.IsSuccess)
                {
                    _fileService.deletebyfilephyid(model.PhysisticName);
                }

                
                return Ok(result);

            }
            return Ok("未找到文件");

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
        /// 结构化基础数据用户名和密码
        /// </summary>
        /// <returns></returns>
        [HttpPost("/struct/GenerateUserLoginInfo")]
        public ActionResult GenerateUserLoginInfo()
         {
            _baseService.structUserInfo();
            return Ok();

        }


        /// <summary>
        /// 获取年级，班级列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("/struct/BaseSelectInfo")]
        public ActionResult<GradeAndClassResModel> getBaseSelectInfo(GradeAndClassSearchViewModel gradeAndClassSearchViewModel)
        {
            var gradeAndClassResModel= _baseService.getGradeAndClass(gradeAndClassSearchViewModel);

            gradeAndClassResModel.IsSuccess = true;
            gradeAndClassResModel.baseViewModel.Message = "查询成功";
            gradeAndClassResModel.baseViewModel.ResponseCode = 200;
            return Ok(gradeAndClassResModel);

        }



        /// <summary>
        /// 获取教职工单位，岗位列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("/struct/BaseDepartInfo")]
        public ActionResult<DepartAndStationResModel> getDepartStationInfo(GradeAndClassSearchViewModel gradeAndClassSearchViewModel)
        {
            var gradeAndClassResModel = _baseService.getDepartStation(gradeAndClassSearchViewModel);

            gradeAndClassResModel.IsSuccess = true;
            gradeAndClassResModel.baseViewModel.Message = "查询成功";
            gradeAndClassResModel.baseViewModel.ResponseCode = 200;
            return Ok(gradeAndClassResModel);

        }




        /// <summary>
        /// 验证 用户是否 阅读隐私政策记录（参数：openid） 
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpPost("/CheckReadLog")]
        public ActionResult<BaseViewModel> CheckReadLog(openidViewModel userInfo)
        {
            BaseViewModel baseView = new BaseViewModel();
            baseView = _baseService.CheckReadLog(userInfo.openid);
            return baseView;
        }


        /// <summary>
        ///记录 用户插入阅读隐私政策记录（参数：openid）
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpPost("/SaveReadLog")]
        public ActionResult<BaseViewModel> SaveReadLog(openidViewModel userInfo)
        {
            BaseViewModel baseView = new BaseViewModel();
            baseView = _baseService.SaveReadLog(userInfo.openid);
            return baseView;
        }


        /// <summary>
        ///获取加密后的身份证号（参数：idnumber）
        /// </summary>
        /// <param name="idnumber"></param>
        /// <returns></returns>
        [HttpPost("/Md5HashIdnumber")]
        public ActionResult<BaseViewModel> GetJMSFZ(IDNumberModel idnumber)
        {
            BaseViewModel baseView = new BaseViewModel();
            baseView = _baseService.GetIdnumber(idnumber.Idnumber);
            return baseView;
        }


        [HttpGet("/getMyFiles")]
        public ActionResult<FileSearchResModel> GetFileInfoBy(string idnumber)
        {
            FileSearchResModel fileSearchResModel = new FileSearchResModel();
            fileSearchResModel.fIleinfoMiddles = _fileService.GetFileInfoBy(idnumber);
            fileSearchResModel.baseViewModel.Message = "查询成功";
            fileSearchResModel.baseViewModel.ResponseCode = 200;
            fileSearchResModel.IsSuccess = true;
            return fileSearchResModel;
        }

        [HttpPost("/deleteMyFiles")]
        [ValidateModel]

        public ActionResult DeletefilesAndInfo (DayAndNightDeleteByFIlesViewModel dayAndNightDeleteByFIlesViewModel)
        {

            _fileService.deleteDayandNightInfoByFile(dayAndNightDeleteByFIlesViewModel);

            return Ok("删除文件以及相关信息成功");
        
        }



    }
}