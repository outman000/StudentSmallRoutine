using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text
    ;
using ViewModel.SmallRoutine.PublicViewModel;
using ViewModel.SmallRoutine.RequestViewModel;

namespace Dto.Service.SmallRoutine
{
    public class StudentService: IStudentService
    {
        private readonly IStudentInfoRepository _studentInfoRepository;
        private readonly IMapper _IMapper;
        private readonly ILogger _ILogger;
        private readonly ISchoolInfoRepository _schoolInfoRepository;
        private readonly IGradeInfoRepository _gradeInfoRepository;
        private readonly IClassInfoRepository _classInfoRepository;

        public StudentService(IStudentInfoRepository studentInfo, IMapper mapper, ILogger logger, ISchoolInfoRepository schoolInfo, 
            IGradeInfoRepository gradeInfo, IClassInfoRepository  classInfo)
        {
            _studentInfoRepository = studentInfo;
            _IMapper = mapper;
            _ILogger = logger;
            _schoolInfoRepository = schoolInfo;
            _gradeInfoRepository = gradeInfo;
            _classInfoRepository = classInfo;
        }



        //添加学生信息 
        public BaseViewModel addStudentInfo(StudentAddModel student)
        {
            BaseViewModel viewModel = new BaseViewModel();
            if(String.IsNullOrEmpty(student.Name) || String.IsNullOrEmpty(student.IdNumber) || String.IsNullOrEmpty(student.SchoolCode)|| String.IsNullOrEmpty(student.GradeCode) || String.IsNullOrEmpty(student.ClassCode) || String.IsNullOrEmpty(student.PermanentAddress))
            {
                viewModel.ResponseCode = 2;
                viewModel.Message = "参数信息为空";
            }
            else
            {
                try
                {
                    //验证 学校、年级、班级是否存在
                    if (_schoolInfoRepository.CheckInfo(student.SchoolCode, student.SchoolName))
                    {
                        if (_gradeInfoRepository.CheckInfo(student.GradeCode, student.GradeName))
                        {
                            if (_classInfoRepository.CheckInfo(student.ClassCode, student.ClassName))
                            {
                                Student_Info info = new Student_Info();
                                info = _IMapper.Map<StudentAddModel, Student_Info>(student);
                                info.CreateDate = DateTime.Now;
                                _studentInfoRepository.Add(info);
                                int i = _studentInfoRepository.SaveChanges();
                                if (i > 0)
                                {
                                    viewModel.ResponseCode = 0;
                                    viewModel.Message = "信息添加成功";
                                }
                                else
                                {
                                    viewModel.ResponseCode = 1;
                                    viewModel.Message = "信息添加失败";
                                }
                            }
                            else
                            {
                                viewModel.ResponseCode = 6;
                                viewModel.Message = "班级信息不存在";
                            }
                        }
                        else
                        {
                            viewModel.ResponseCode = 5;
                            viewModel.Message = "年级信息不存在";
                        }
                    }
                    else
                    {
                        viewModel.ResponseCode = 4;
                        viewModel.Message = "学校信息不存在";
                    }

                }
                catch (Exception ex)
                {
                    viewModel.ResponseCode = 3;
                    viewModel.Message = "出现异常";
                }
               
            }
            return viewModel;
        }


    }
}
