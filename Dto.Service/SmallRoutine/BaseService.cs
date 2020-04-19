using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.RequestViewModel.BaseControlViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.BaseControlViewModel;
using ViewModel.SmallRoutine.ServiceDTO.SmallRoutine;

namespace Dto.Service.AutoMapper.SmallRoutine
{
    public class BaseService: IBaseService
    {
        private readonly IStudentInfoRepository _StudentInfoRepository;
        private readonly IClassInfoRepository _classInfoRepository;
        private readonly IGradeInfoRepository _gradeInfoRespository;
        private readonly ISchoolInfoRepository _schoolInfoRespository;
        private readonly IStationInfoRepository _stationInfoRespository;
        private readonly IDepartInfoRepository _departInfoRespository;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IReadLogRepository _readLogRepository;

        private IFacultystaffInfoRepository _facultystaffInfoRepository;
        private readonly IMapper _IMapper;

        public BaseService(IStudentInfoRepository studentInfoRepository,
            IClassInfoRepository classInfoRepository,
            IGradeInfoRepository gradeInfoRespository,
            ISchoolInfoRepository schoolInfoRespository,
            IStationInfoRepository stationInfoRespository,
            IDepartInfoRepository departInfoRespository,
            IUserInfoRepository userInfoRepository,
            IFacultystaffInfoRepository facultystaffInfoRepository,
            IReadLogRepository readLog,
            IMapper iMapper)
        {
            _StudentInfoRepository = studentInfoRepository;
            _classInfoRepository = classInfoRepository;
            _gradeInfoRespository = gradeInfoRespository;
            _schoolInfoRespository = schoolInfoRespository;
            _stationInfoRespository = stationInfoRespository;
            _departInfoRespository = departInfoRespository;
            _userInfoRepository = userInfoRepository;
            _facultystaffInfoRepository = facultystaffInfoRepository;
            _readLogRepository = readLog;
            _IMapper = iMapper;
        }

        public void structSystemInfo()
        {
            var schoolList = _StudentInfoRepository.GetSchoolList();//所有学校
            var gradeList = _StudentInfoRepository.GetGradeList();//所有年级
            var classList = _StudentInfoRepository.GetClasslList();//所有班级
            var departList = _facultystaffInfoRepository.GetDepartList();//所有部门
            var staffList = _facultystaffInfoRepository.GetStationlList();//所有岗位
            var schoolInsertList = _IMapper.Map<List<SchoolInfoServiceDTO>, List<School_Info>>(schoolList);//需要插入的学校集合
            var gradeInsertList = _IMapper.Map<List<GradeInfoServiceDTO>, List<Grade_Info>>(gradeList);//需要插入的年级集合
            var classInsertList = _IMapper.Map<List<ClassInfoServiceDTO>, List<Class_Info>>(classList);// 需要插入的班级集合
            var departInsertList = _IMapper.Map<List<DepartInfoServiceDTO>, List<Depart_Info>>(departList);// 需要插入的班级集合
            var staffInsertList = _IMapper.Map<List<StationInfoServiceDTO>, List<Station_Info>>(staffList);// 需要插入的班级集合
            _classInfoRepository.AddListBase(classInsertList);//插入班级
            _gradeInfoRespository.AddListBase(gradeInsertList);//插入年级
            _schoolInfoRespository.AddListBase(schoolInsertList);//插入学校
            _stationInfoRespository.AddListBase(staffInsertList);//插入岗位
            _departInfoRespository.AddListBase(departInsertList);//插入部门
            _StudentInfoRepository.SaveChanges();//所有的save都是全局的用哪个都行。
            _StudentInfoRepository.flushStudentClassId();
            _facultystaffInfoRepository.flushfacultyStationId();

            _StudentInfoRepository.SaveChanges();

            //还差一个所有岗位
        }

        public void structUserInfo()
        {
            var studentInfoAll = _StudentInfoRepository.GetAll().ToList();
            var facultystaff = _facultystaffInfoRepository.GetAll().ToList();
            var schoolInsertList = _IMapper.Map<List<Student_Info>, List<User_Info>>(studentInfoAll);//需要插入的学校集合
            var facultystafInfoInsertList = _IMapper.Map<List<facultystaff_Info>, List<User_Info>>(facultystaff);//需要插入的学校集合
            _userInfoRepository.AddListBase(schoolInsertList);
            _userInfoRepository.AddListBase(facultystafInfoInsertList);
            _userInfoRepository.SaveChanges();
        }

        public GradeAndClassResModel getGradeAndClass(GradeAndClassSearchViewModel gradeAndClassSearchViewModel)
        {
            GradeAndClassResModel gradeAndClassResModel = new GradeAndClassResModel();
            var classList = _StudentInfoRepository.GetClasslListContainId(gradeAndClassSearchViewModel);
            var GradeList = _StudentInfoRepository.GetGradeListContainId(gradeAndClassSearchViewModel);

            gradeAndClassResModel.classInfoSearchMiddleModels = classList;
            gradeAndClassResModel.gradeInfoSearchMiddleModels = GradeList;

            return gradeAndClassResModel;


        }



        public DepartAndStationResModel getDepartStation(GradeAndClassSearchViewModel gradeAndClassSearchViewModel)
        {
            DepartAndStationResModel ResModel = new DepartAndStationResModel();
            var DepartList = _facultystaffInfoRepository.GetDepartlListContainId(gradeAndClassSearchViewModel);
            var StationList = _facultystaffInfoRepository.GetStationListContainId(gradeAndClassSearchViewModel);

            ResModel.departInfoSearchMiddleModels = DepartList;
            ResModel.stationInfoSearchMiddleModels = StationList;

            return ResModel;


        }




        //记录 用户插入阅读隐私政策记录（参数：openid） 
        public BaseViewModel SaveReadLog(string openid)
        {
            BaseViewModel baseView = new BaseViewModel();
            if (openid == "")
            {
                baseView.Message = "参数为空";
                baseView.ResponseCode = 2;
            }
            else
            {
                try
                {
                    ReadLog log = new ReadLog();
                    log.openid = openid;
                    log.CreateDate = DateTime.Now;
                    _readLogRepository.Add(log);
                    int a = _readLogRepository.SaveChanges();
                    if (a > 0)
                    {
                        baseView.Message = "保存成功";
                        baseView.ResponseCode = 0;
                    }
                    else
                    {
                        baseView.Message = "保存失败";
                        baseView.ResponseCode = 1;
                    }
                }
                catch (Exception ex)
                {
                    baseView.Message = "出现异常";
                    baseView.ResponseCode = 3;
                }
            }
            return baseView;
        }


        //验证 用户是否 阅读隐私政策记录（参数：openid） 
        public BaseViewModel CheckReadLog(string openid)
        {
            BaseViewModel baseView = new BaseViewModel();
            if (openid == "")
            {
                baseView.Message = "参数为空";
                baseView.ResponseCode = 2;
            }
            else
            {
                try
                {
                    //验证 用户是否 阅读隐私政策记录
                    ReadLog log = _readLogRepository.GetReadLog(openid);

                    if (log != null)
                    {
                        baseView.Message = "我已阅读";
                        baseView.ResponseCode = 0;
                    }
                    else
                    {
                        baseView.Message = "我未阅读";
                        baseView.ResponseCode = 1;
                    }
                }
                catch (Exception ex)
                {
                    baseView.Message = "出现异常";
                    baseView.ResponseCode = 3;
                }
            }
            return baseView;
        }



        //获取加密后的身份证号（参数：idnumber） 
        public BaseViewModel GetIdnumber(string idnumber)
        {
            BaseViewModel baseView = new BaseViewModel();
            if (idnumber == "")
            {
                baseView.Message = "参数为空";
                baseView.ResponseCode = 2;
            }
            else
            {
                try
                {
                    baseView.Message = Dtol.Helper.MD5.Md5Hash(idnumber);
                    baseView.ResponseCode = 1;
                }
                catch (Exception ex)
                {
                    baseView.Message = "出现异常";
                    baseView.ResponseCode = 3;
                }
            }
            return baseView;
        }

    }
}
