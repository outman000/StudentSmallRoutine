using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dto.Service.Extension;
using Dtol.dtol;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.DayAndNightViewModel;
using ViewModel.SmallRoutine.ResponseViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.DayAndNightViewModel;

namespace Dto.Service.SmallRoutine
{
    public class FileService: IFIileService
    {
        private readonly IMapper _IMapper;
        private readonly IFileRepository _fileRepository;
        private readonly IDayandNightRepository _dayandNightRepository;
        private readonly IStudentInfoRepository _studentInfoRepository;
        private readonly IFacultystaffInfoRepository _facultystaffInfoRepository;


        private readonly IExceptStudentRepository exceptStudentRepository;

        private readonly IExceptEmployRepository  exceptEmployRepository;

        private readonly IValideService  _valideService;


        private readonly IImageRepository _imageRepository;

        public FileService(IMapper iMapper, IFileRepository fileRepository, IDayandNightRepository dayandNightRepository, IStudentInfoRepository studentInfoRepository, IFacultystaffInfoRepository facultystaffInfoRepository, IExceptStudentRepository exceptStudentRepository, IExceptEmployRepository exceptEmployRepository, IValideService valideService, IImageRepository imageRepository)
        {
            _IMapper = iMapper;
            _fileRepository = fileRepository;
            _dayandNightRepository = dayandNightRepository;
            _studentInfoRepository = studentInfoRepository;
            _facultystaffInfoRepository = facultystaffInfoRepository;
            this.exceptStudentRepository = exceptStudentRepository;
            this.exceptEmployRepository = exceptEmployRepository;
            _valideService = valideService;
            _imageRepository = imageRepository;
        }


        //根据文件删除早午晚检查信息
        public void deleteDayandNightInfoByFile(DayAndNightDeleteByFIlesViewModel dayAndNightDeleteByFIlesViewModel)
        {
            var List=  _dayandNightRepository.getInfoByTag(dayAndNightDeleteByFIlesViewModel.tag);

            var fileInfo= _fileRepository.getfileIDByPhyName(dayAndNightDeleteByFIlesViewModel.tag);


            _dayandNightRepository.deleteRange(List);
            _fileRepository.delete(fileInfo);
            _dayandNightRepository.SaveChanges();

        }










        //随机名称
        public String fileRandName(String fileRealname)
        {
            String RandName = "";
            String[] fileTail = fileRealname.Split('.');
            RandName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + fileTail[1];
            return RandName;
        }

        public List<FIleinfoMiddle> GetFileInfoBy(string idnumber)
        {
           var idnumbermd5=  Dtol.Helper.MD5.Md5Hash(idnumber);

           List<UploadFile> uploadFiles=  _fileRepository.getfilebyIdnumber(idnumbermd5);

            return _IMapper.Map<List<UploadFile>, List<FIleinfoMiddle>>(uploadFiles);

        }

        public int InputStudentInfoTimeIntervalIntoDataBase(string filePath, string randomname)
        {
         
            var package = new ExcelPackage(new System.IO.FileInfo(filePath));
            var workbook = package.Workbook;
            var worksheet = workbook.Worksheets.First();
            var StudentInfo = worksheet.ConvertSheetToObjects<Student_DayandNight_Info>(randomname).ToList();
            _dayandNightRepository.AddList(StudentInfo);
            return _dayandNightRepository.SaveChanges();
        }

        public DayAndNightStudentImportResModel InputStudentInfoTimeIntervalIntoDataBaseValide(string filePath, string randomname, string Idnumber)
        {
            DayAndNightStudentImportResModel dayAndNightStudentImportResModel = new DayAndNightStudentImportResModel();


            var package = new ExcelPackage(new System.IO.FileInfo(filePath));
            var workbook = package.Workbook;
            var worksheet = workbook.Worksheets.First();
            var StudentInfo = worksheet.ConvertSheetToObjects<Student_DayandNight_Info>(randomname).ToList();

            var errorinfo = _valideService.ValideListDayAndNight<Student_DayandNight_Info>(StudentInfo, Idnumber);
            errorinfo = _valideService.ValideListDayAndNightOverRall<Student_DayandNight_Info>(StudentInfo, Idnumber, errorinfo);
            errorinfo = _valideService.ValideListDayAndNightNum<Student_DayandNight_Info>(StudentInfo, Idnumber, errorinfo);
            errorinfo = _valideService.ValideListDayAndNightNumIdInClass<Student_DayandNight_Info>(StudentInfo, errorinfo);

            if (errorinfo.Length == 0)
            {
                dayAndNightStudentImportResModel.IsSuccess = true;
                dayAndNightStudentImportResModel.StringBuilder.Append("数据格式正确");
                _dayandNightRepository.AddList(StudentInfo);
                _dayandNightRepository.SaveChanges();
            }
            else
            {
                dayAndNightStudentImportResModel.IsSuccess = false;
                dayAndNightStudentImportResModel.StringBuilder= errorinfo;
            }


            //_dayandNightRepository.AddList(StudentInfo);
            return dayAndNightStudentImportResModel;


        }






        //学生信息导入
        public int InputWhiteListIntoDataBase(string FilePath,string FileName)
        {
            Student_Info student_Info = new Student_Info();
            var aa=student_Info.CreateDate;
            var package = new ExcelPackage(new System.IO.FileInfo(FilePath));
            var workbook = package.Workbook;
            var worksheet = workbook.Worksheets.First();
            var StudentInfo = worksheet.ConvertSheetToObjects<Student_Info>(FileName).ToList();
            _studentInfoRepository.AddList(StudentInfo);
            return _studentInfoRepository.SaveChanges();


        }
        //导入老师以及员工信息
        public int InputWhiteListIntoDataBase_facultystaffInfo(string FilePath, string FileName)
        {
            Student_Info student_Info = new Student_Info();
            var aa = student_Info.CreateDate;
            var package = new ExcelPackage(new System.IO.FileInfo(FilePath));
            var workbook = package.Workbook;
            var worksheet = workbook.Worksheets.First();
            var facultystaffInfo = worksheet.ConvertSheetToObjects<facultystaff_Info>(FileName).ToList();
            _facultystaffInfoRepository.AddList(facultystaffInfo);
            return _facultystaffInfoRepository.SaveChanges();
        }
     

        public FileImgResViewModel SaveFileInfo(FileUploadViewModel fileUploadViewModel)
        {
            var UploadFile= _IMapper.Map<FileUploadViewModel, UploadFile>(fileUploadViewModel);

            var result = _IMapper.Map<FileUploadViewModel, FileImgResViewModel>(fileUploadViewModel);

            _fileRepository.Add(UploadFile);
            _fileRepository.SaveChanges();

            int fileKeyid = _fileRepository.getfileIDByPhy(fileUploadViewModel);
            result.id = fileKeyid;
            return result;

        }


        public int SaveImageFileInfo(FileImageUploadViewModel fileUploadViewModel)
        {
            var UploadFile = _IMapper.Map<FileImageUploadViewModel, UserFiles_Info>(fileUploadViewModel);

            //验证身份证号存在
            var student = _studentInfoRepository.getByidNumber(Dtol.Helper.MD5.Md5Hash(fileUploadViewModel.Idnumber));

            var employ = _facultystaffInfoRepository.getByidNumber(Dtol.Helper.MD5.Md5Hash(fileUploadViewModel.Idnumber));

            if (student == null && employ == null)
            {
                return 0;
            }

            //先把图片上传上去
            _imageRepository.Add(UploadFile);
            _imageRepository.SaveChanges();

            return UploadFile.id;
        }


        public  void deletebyfilephyid(string phyname)
        {
      

            var model = _fileRepository.getfileIDByPhyName(phyname);
            _fileRepository.delete(model);
            _fileRepository.SaveChanges();
    

        }

    }
}
