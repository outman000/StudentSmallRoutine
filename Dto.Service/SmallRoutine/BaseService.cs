using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
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

        private IFacultystaffInfoRepository _facultystaffInfoRepository;
        private readonly IMapper _IMapper;


        public BaseService(IStudentInfoRepository studentInfoRepository,
            IClassInfoRepository classInfoRepository,
            IGradeInfoRepository gradeInfoRespository,
            ISchoolInfoRepository schoolInfoRespository,
            IStationInfoRepository stationInfoRespository,
            IDepartInfoRepository departInfoRespository,
            IFacultystaffInfoRepository facultystaffInfoRepository,
            IMapper iMapper)
        {
            _StudentInfoRepository = studentInfoRepository;
            _classInfoRepository = classInfoRepository;
            _gradeInfoRespository = gradeInfoRespository;
            _schoolInfoRespository = schoolInfoRespository;
            _stationInfoRespository = stationInfoRespository;
            _departInfoRespository = departInfoRespository;
            _facultystaffInfoRepository = facultystaffInfoRepository;
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

            //还差一个所有岗位
        }

        public void structUserInfo()
        {
            
        }
    }
}
