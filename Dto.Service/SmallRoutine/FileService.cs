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
using ViewModel.SmallRoutine;
using ViewModel.SmallRoutine.ResponseViewModel;

namespace Dto.Service.SmallRoutine
{
    public class FileService: IFIileService
    {
        private readonly IMapper _IMapper;
        private readonly IFileRepository _fileRepository;
        private readonly IDayandNightRepository _dayandNightRepository;
        private readonly IStudentInfoRepository _studentInfoRepository;
        private readonly IFacultystaffInfoRepository _facultystaffInfoRepository;

        public FileService(IMapper iMapper, IFileRepository fileRepository, IDayandNightRepository dayandNightRepository, IStudentInfoRepository studentInfoRepository, IFacultystaffInfoRepository facultystaffInfoRepository)
        {
            _IMapper = iMapper;
            _fileRepository = fileRepository;
            _dayandNightRepository = dayandNightRepository;
            _studentInfoRepository = studentInfoRepository;
            _facultystaffInfoRepository = facultystaffInfoRepository;
        }



        //随机名称
        public String fileRandName(String fileRealname)
        {
            String RandName = "";
            String[] fileTail = fileRealname.Split('.');
            RandName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + fileTail[1];
            return RandName;
        }

      

        public int InputStudentInfoTimeIntervalIntoDataBase(string filePath, string randomname)
        {
         
            var package = new ExcelPackage(new System.IO.FileInfo(filePath));
            var workbook = package.Workbook;
            var worksheet = workbook.Worksheets.First();
            var StudentInfo = worksheet.ConvertSheetToObjects<Student_DayandNight_Info>(filePath).ToList();
            _dayandNightRepository.AddList(StudentInfo);
            return _dayandNightRepository.SaveChanges();
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


    }
}
