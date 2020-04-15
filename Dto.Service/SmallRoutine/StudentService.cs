using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.PublicViewModel;
using ViewModel.SmallRoutine.RequestViewModel;

namespace Dto.Service.SmallRoutine
{
    public class StudentService: IStudentService
    {
        private readonly IStudentInfoRepository _studentInfoRepository;
        private readonly IMapper _IMapper;

        private readonly ISchoolInfoRepository _schoolInfoRepository;
        private readonly IGradeInfoRepository _gradeInfoRepository;
        private readonly IClassInfoRepository _classInfoRepository;

        public StudentService(IStudentInfoRepository studentInfo, IMapper mapper,  ISchoolInfoRepository schoolInfo, 
            IGradeInfoRepository gradeInfo, IClassInfoRepository  classInfo)
        {
            _studentInfoRepository = studentInfo;
            _IMapper = mapper;
            _schoolInfoRepository = schoolInfo;
            _gradeInfoRepository = gradeInfo;
            _classInfoRepository = classInfo;
        }


        //添加学生信息 
        public BaseViewModel addStudentInfo(StudentBaseModel student)
        {
            BaseViewModel viewModel = new BaseViewModel();
            if (String.IsNullOrEmpty(student.Name) || String.IsNullOrEmpty(student.IdNumber) || String.IsNullOrEmpty(student.SchoolCode) || String.IsNullOrEmpty(student.GradeCode) || String.IsNullOrEmpty(student.ClassCode) || String.IsNullOrEmpty(student.PermanentAddress))
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
                                info = _IMapper.Map<StudentBaseModel, Student_Info>(student);
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


        //根据 id 删除 学生信息
        public BaseViewModel delStudentInfo(int id)
        {
            BaseViewModel baseView = new BaseViewModel();
            _studentInfoRepository.RemoveInfo(_studentInfoRepository.getbyID(id));
            int i = _studentInfoRepository.SaveChanges();
            if (i > 0)
            {
                baseView.ResponseCode = 0;
                baseView.Message = "删除成功";
            }
            else
            {
                baseView.ResponseCode = 1;
                baseView.Message = "删除失败";
            }
            return baseView;
        }


        //修改 学生信息
        public BaseViewModel updateStudentInfo(StudentMiddle student)
        {
            BaseViewModel baseView = new BaseViewModel();
            var info = _IMapper.Map<StudentMiddle, Student_Info>(student);
            _studentInfoRepository.Update(info);
            int i = _studentInfoRepository.SaveChanges();
            if (i > 0)
            {
                baseView.ResponseCode = 0;
                baseView.Message = "修改成功";
            }
            else
            {
                baseView.ResponseCode = 1;
                baseView.Message = "修改失败";
            }
            return baseView;
        }


        //根据条件查询
        public List<StudentMiddle> GetListByParas(StudentSearchModel model)
        {
            List<Student_Info> lists = new List<Student_Info>();
            List<StudentMiddle> nlists = new List<StudentMiddle>();
            if (!string.IsNullOrEmpty(model.IdNumber))
            {
                model.IdNumber = Dtol.Helper.MD5.Md5Hash(model.IdNumber);
            }

            lists = _studentInfoRepository.GetByModel(model);

            foreach (var item in lists)
            {
                var info = _IMapper.Map<Student_Info, StudentMiddle>(item);
                nlists.Add(info);
            }

            return nlists;
        }

    }
}
