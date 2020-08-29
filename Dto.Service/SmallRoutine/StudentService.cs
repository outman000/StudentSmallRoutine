using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

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

        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IDeleteStudentInfoRepository _deleteStudentInfo;

        public StudentService(IStudentInfoRepository studentInfoRepository, IMapper iMapper, ISchoolInfoRepository schoolInfoRepository,
            IGradeInfoRepository gradeInfoRepository, IClassInfoRepository classInfoRepository, IUserInfoRepository userInfoRepository,
            IDeleteStudentInfoRepository deleteStudentInfo )
        {
            _studentInfoRepository = studentInfoRepository;
            _IMapper = iMapper;
            _schoolInfoRepository = schoolInfoRepository;
            _gradeInfoRepository = gradeInfoRepository;
            _classInfoRepository = classInfoRepository;
            _userInfoRepository = userInfoRepository;
            _deleteStudentInfo = deleteStudentInfo;
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
                                _userInfoRepository.AddDefault(info.IdNumber);//创建默认账号



                               // _userInfoRepository

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
            Student_Info info = _studentInfoRepository.getbyID(id);
            if (info != null)
            {
                _studentInfoRepository.RemoveInfo(info);
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

           var originModel= _studentInfoRepository.getbyID(student.id);
           var info = _IMapper.Map<StudentMiddle, Student_Info>(student, originModel);


            _studentInfoRepository.Update(info);

            var userInfo= _userInfoRepository.GetByIdnumber(info.IdNumber);
            if (userInfo == null)
            {
                _userInfoRepository.AddDefault(info.IdNumber);
            }

      
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
            //if (!string.IsNullOrEmpty(model.IdNumber))
            //{
            //    model.IdNumber = Dtol.Helper.MD5.Md5Hash(model.IdNumber);
            //}

            lists = _studentInfoRepository.GetByModel(model);

            foreach (var item in lists)
            {
                var info = _IMapper.Map<Student_Info, StudentMiddle>(item);

                info.IdNumber = Dtol.Helper.MD5.Decrypt(info.IdNumber);
                nlists.Add(info);
            }

            return nlists;
        }



        //根据 id 批量删除 学生信息 20200828
        public BaseViewModel batchdelStudentInfo(List<int> ids,string memo)
        {
            BaseViewModel baseView = new BaseViewModel();
            int i = 0, j = 0;
            string names = "";
            foreach (var id in ids)
            {
                Student_Info info = _studentInfoRepository.getbyID(id);
                if (info != null)
                {
                    // 保存到备份数据库
                    Student_Info_Delete info_Delete = new Student_Info_Delete();
                    info_Delete = _IMapper.Map<Student_Info, Student_Info_Delete>(info);
                    info_Delete.id = Guid.NewGuid().ToString();
                    info_Delete.Student_id = info.id;
                    info_Delete.Memo = memo;
                    _deleteStudentInfo.Add(info_Delete);
                    int m = _deleteStudentInfo.SaveChanges();


                    _studentInfoRepository.RemoveInfo(info);
                    int n = _studentInfoRepository.SaveChanges();
                    if (n > 0)
                    {
                        i++;
                    }
                    else
                    {
                        j++;
                        names += info.Name + ",";
                    }
                }
                else
                {
                    j++;
                    names += "该id=" + id + "未找到学生信息,";
                }
            }
            if (j > 0)
            {
                baseView.ResponseCode = 1;
                baseView.Message = "删除成功:" + i.ToString() + "条数据；删除失败:" + j + "条数据。删除失败姓名包括：" + names;
            }
            else
            {
                baseView.ResponseCode = 0;
                baseView.Message = "全部删除成功共:" + i.ToString() + "条数据";
            }

            return baseView;
        }


        //根据 id 批量学生 信息批量 升班
        public BaseViewModel BatchChangeStudentInfo(StudentChangeInfo model)
        {
            BaseViewModel baseView = new BaseViewModel();
            int i = 0, j = 0;
            foreach (var id in model.ids)
            {
                Student_Info info = _studentInfoRepository.getbyID(id);
                if (info != null)
                {
                    // 保存到备份数据库
                    Student_Info_Delete info_Delete = new Student_Info_Delete();
                    info_Delete = _IMapper.Map<Student_Info, Student_Info_Delete>(info);
                    info_Delete.id = Guid.NewGuid().ToString();
                    info_Delete.Student_id = info.id;
                    info_Delete.Memo = model.Memo;
                    _deleteStudentInfo.Add(info_Delete);
                    int m = _deleteStudentInfo.SaveChanges();


                    //修改基本信息的   年级、班级信息
                    //获取年级信息
                    info.GradeCode = model.GradeCode;
                    var grades = _gradeInfoRepository.getnameInfoBycode(model.GradeCode);
                    if (grades != null)
                    {
                        info.GradeName = grades.GradeName;
                    }

                    //获取班级信息
                    var classes = _classInfoRepository.getNameInfoBycode(model.ClassCode);
                    if (classes != null)
                    {
                        info.ClassName = classes.ClassName;
                    }
                    info.ClassCode = model.ClassCode;
                   
                    _studentInfoRepository.Update(info);
                    int n = _studentInfoRepository.SaveChanges();
                    if (n > 0)
                    {
                        i++;
                    }
                    else
                    {
                        j++;
                    }
                }
                else
                {
                    j++;
                }
            }
            if (j > 0)
            {
                baseView.ResponseCode = 1;
                baseView.Message = "修改成功:" + i.ToString() + "条数据;修改失败:" + j + "条数据";
            }
            else
            {
                baseView.ResponseCode = 0;
                baseView.Message = "全部修改成功共:" + i.ToString() + "条数据";
            }


            return baseView;
        }


        //获取该年级班级的 学生总数
        public BaseViewModel GetStudentTotalByGC(string GradeCode, string ClassCode)
        {
            BaseViewModel baseView = new BaseViewModel();
            StudentSearchModel student = new StudentSearchModel();
            student.GradeCode = GradeCode;
            student.ClassCode = ClassCode;
            var lists = _studentInfoRepository.GetByModel(student);
            baseView.Message = lists.Count.ToString();
            baseView.ResponseCode = 0;
            return baseView;
        }
    }
}
