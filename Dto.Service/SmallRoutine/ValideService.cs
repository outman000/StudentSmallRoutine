using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.Attribute;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Dto.Service.SmallRoutine
{
    public class ValideService : IValideService
    {
        private readonly IStudentInfoRepository _StudentInfoRepository;
        private readonly IClassInfoRepository _classInfoRepository;
        private readonly IGradeInfoRepository _gradeInfoRespository;
        private readonly ISchoolInfoRepository _schoolInfoRespository;
        private readonly IStationInfoRepository _stationInfoRespository;
        private readonly IDepartInfoRepository _departInfoRespository;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IReadLogRepository _readLogRepository;
        private readonly IStaffClassRelateRepository _staffClassRelateRepository;

        private IFacultystaffInfoRepository _facultystaffInfoRepository;
        private readonly IMapper _IMapper;

        public ValideService(IStudentInfoRepository studentInfoRepository, IClassInfoRepository classInfoRepository, IGradeInfoRepository gradeInfoRespository, ISchoolInfoRepository schoolInfoRespository, IStationInfoRepository stationInfoRespository, IDepartInfoRepository departInfoRespository, IUserInfoRepository userInfoRepository, IReadLogRepository readLogRepository, IStaffClassRelateRepository staffClassRelateRepository, IFacultystaffInfoRepository facultystaffInfoRepository, IMapper iMapper)
        {
            _StudentInfoRepository = studentInfoRepository;
            _classInfoRepository = classInfoRepository;
            _gradeInfoRespository = gradeInfoRespository;
            _schoolInfoRespository = schoolInfoRespository;
            _stationInfoRespository = stationInfoRespository;
            _departInfoRespository = departInfoRespository;
            _userInfoRepository = userInfoRepository;
            _readLogRepository = readLogRepository;
            _staffClassRelateRepository = staffClassRelateRepository;
            _facultystaffInfoRepository = facultystaffInfoRepository;
            _IMapper = iMapper;
        }

        public StringBuilder ValideListDayAndNight<T>(List<Student_DayandNight_Info> sheet, String idnumber)
        {
            var a2222= sheet;
            Type type = typeof(ExcelAttribute);
            Func<CustomAttributeData, bool> columnOnly = y => y.AttributeType == typeof(ExcelAttribute);
            var columns = typeof(T)//反射实体类
                                   //获取实体类的所有属性，他返回的一个属性数组，之后通过linq查询这个数组，因为这个数组继承自枚举类，所以支持linq
                .GetProperties()
                //根据条件来查询属性，（x => x.CustomAttributes.Any(columnOnly)）获取存在属性的特性
                .Where(x => x.CustomAttributes.Any(columnOnly))
                .Select(p => new
                {
                    Property = p,
                    Column = p.GetCustomAttributes<ExcelAttribute>().First().ColumnName
                }).ToList();

            StringBuilder stringBuilder = new StringBuilder();


            int i = 2;

            sheet.ForEach((row)=> {
                
                 columns.ForEach(col =>
                {

                    Type Ts = row.GetType();

                    var item = Ts.GetProperty(col.Property.Name).GetValue(row, null)==null?"" : Ts.GetProperty(col.Property.Name).GetValue(row, null).ToString();

              

                  //  var item = col.Property.GetValue(col.Property.Name).ToString();
                   
                    

                    if (item == null || item == "")
                    {
                        stringBuilder.Append("数据错误:导入表格第 " +i+ " 行 ,’" + col.Column.ToString() + "‘列的值是'空值'请仔细核对;\n");
                    }
                    if (col.Column.Equals("身份证号"))//这个需要验证身份证号
                    {
                        var existidnumber = _StudentInfoRepository.GetByAllIdnumbers().FirstOrDefault(a => a.Idnumber == item);
                        if (existidnumber == null)
                        {
                          var a=  Dtol.Helper.MD5.Decrypt(item);

                            stringBuilder.Append("数据错误:导入表格第 " + i + " 行 ,’" + col.Column.ToString() + "‘列 '身份证号不存在于基础数据中' 请仔细核对;\n");
                        }
                    }
                    //学校名称（需与提供的学校全称完全一致）
                    if (col.Column.Equals("学校名称（需与提供的学校全称完全一致）"))
                    {
                        if (!_schoolInfoRespository.CheckInfoByname(item))
                        {
                            stringBuilder.Append("数据错误:导入表格第 " +i+ " 行 ,’" + col.Column.ToString() + "‘列的值'学校名称不正确或该学校不存在您的负责范围'请仔细核对;\n");
                        }
                    }


                    if (col.Column.Equals("年级（需与提供的年级完全一致）"))//这个需要年级，首先是格式，其次他是否负责这个班级
                    {

                        var grade = _staffClassRelateRepository.GetResponsibleGradeByIdnumber(idnumber);
                        var tempgrade = grade.FirstOrDefault(a => a == item);
                        if (tempgrade == null)
                        {
                            stringBuilder.Append("数据错误:导入表格第 " +i+ " 行 ,’" + col.Column.ToString() + "‘列的值'年级名称不正确或该年级不存在您的负责范围'请仔细核对;\n");
                        }
                    }
                    if (col.Column.Equals("班级（需与提供的班级完全一致）"))//这个需要验证身份证号
                    {
                        var classs = _staffClassRelateRepository.GetResponsibleClassByIdnumber(idnumber);
                        var tempclass = classs.FirstOrDefault(a => a == item);
                        if (tempclass == null)
                        {
                            stringBuilder.Append("数据错误:导入表格第 " +i+ " 行 ,’" + col.Column.ToString() + "‘列的值'班级名称不正确或该班级不在您的负责范围'请仔细核对;\n");
                        }
                    }
                    if (col.Column.Equals("体温"))//这个需要验证体温
                    {
                        string tempregex = string.Empty;
                        tempregex = "((3[5-9])|40).\\d";
                        if (!Regex.IsMatch(item, tempregex))
                        {
                            stringBuilder.Append("数据错误:导入表格第 " +i+ " 行 ,’" + col.Column.ToString() + "‘列的值是'体温格式不正确(36请改为36.0)'空值请仔细核对;\n");
                        }
                    }
                    if (col.Column.Equals("填报时段（晨/午/晚）"))//这个需要验证体温
                    {
                        if (item!= "晨" && item != "午"&& item != "晚")
                        {
                            stringBuilder.Append("数据错误:导入表格第 " + i + " 行 ,’" + col.Column.ToString() + "‘列的值是'时段只能填写晨，午，晚'请仔细核对;\n");
                        }
                    }


                    if (col.Column.Equals("应填报时间"))//这个需要验证身份证号
                    {
                        //时间只能存在一个，并且
                        if (item == null || item == "")
                        {
                            return;
                        }
                        else
                        {
                            var time = Convert.ToDateTime(item.ToString());
                            if (time > DateTime.Now)
                            {
                                stringBuilder.Append("数据错误:导入表格第 " +i+ " 行 ,’" + col.Column.ToString() + "‘列的值'导入的填报时间不能大于当前时间'空值请仔细核对;\n");
                            }
                        }
                    }

                });

                  i++;
            });
            return stringBuilder;

        }
        //总体验证
        public StringBuilder ValideListDayAndNightOverRall<T>(List<Student_DayandNight_Info> sheet, String idnumber, StringBuilder stringBuilder)
        {
            var gradenams = sheet.Select(a => a.GradeName).Distinct();

            var classnames = sheet.Select(a => a.ClassName).Distinct();

            var schoolsnames = sheet.Select(a => a.SchoolName).Distinct();

            var dates = sheet.Select(a => a.AddCreateDate.Value.ToString("yyyy-MM-dd")).Distinct();

            var Intervals = sheet.Select(a => a.AddTimeInterval).Distinct();

            var Idnumbers = sheet.Select(a => a.IdNumber).Distinct().ToList();

            if (gradenams.Count() != 1)
            {
                stringBuilder.Append("数据整体性错误:您导入的数据存在多个‘年级名称’，请保证本次导入的年级唯一\n;");
            }
            if (classnames.Count() != 1)
            {
                stringBuilder.Append("数据整体性错误:您导入的数据存在多个‘班级名称’，请保证本次导入的班级唯一\n;");
            }

            if (schoolsnames.Count() != 1)
            {
                stringBuilder.Append("数据整体性错误:您导入的数据存在多个‘学校名称’，请保证本次导入的学校名称唯一\n;");
            }
            if (dates.Count() != 1)
            {
                stringBuilder.Append("数据整体性错误:您导入的数据存在多个‘时间段’，请保证本次导入的时间唯一\n;");
            }
            if (Intervals.Count() != 1)
            {
                stringBuilder.Append("数据整体性错误:您导入的数据存在多个‘晨午晚’时段，请保证本次导入的时段唯一\n;");
            }
            if (Idnumbers.Count() < sheet.Count)
            {
                var repeatresult = sheet.GroupBy(w => w.IdNumber).Where(m=>m.Count()>1).ToList();


                for (int i = 0; i < repeatresult.Count(); i++)
                {
                 
                    stringBuilder.Append("数据重复性错误:您导入的数据存在多个‘" + Dtol.Helper.MD5.Decrypt(repeatresult[i].Key) + "’身份证号，请保证本次导入的身份证号唯一\n;");
                }


            }
            return stringBuilder;
         }
        //数量验证
        public StringBuilder ValideListDayAndNightNum<T>(List<Student_DayandNight_Info> sheet, String idnumber, StringBuilder stringBuilder)
        {
            var gradenams = sheet.Select(a => a.GradeName).Distinct();

            var classnames = sheet.Select(a => a.ClassName).Distinct();

            var SchoolName = sheet.Select(a => a.SchoolName).Distinct();

            var schoolcode = _schoolInfoRespository.GetSchoolCodeByName(SchoolName.FirstOrDefault());
            var GradeCode = _gradeInfoRespository.GetGradeCodeBySchoolCode(schoolcode, gradenams.FirstOrDefault());
            var ClassCode = _classInfoRepository.GetClassCodeByGradeCode(GradeCode, classnames.FirstOrDefault());

            if (ClassCode == null)
            {
                stringBuilder.Append("数量错误:请您先核对，学校，班级，年级信息\n;");
            }
            else
            {
                var classpeoplenum = _staffClassRelateRepository.GetResponsibleClassPeopleNumber(ClassCode.ClassCode);

                if (classpeoplenum != sheet.Count())
                {
                    stringBuilder.Append("数量错误:您所导入的数据总数 :'"+ sheet.Count() + "'，小于您所负责班级的的总人数:'"+ classpeoplenum + "'，请保证导入数量与班级数量一致\n;");
                }
            }
            return stringBuilder;
        }
        //身份证是否存在班级当中
        public StringBuilder ValideListDayAndNightNumIdInClass<T>(List<Student_DayandNight_Info> sheet,StringBuilder stringBuilder)
        {
            var gradenams = sheet.Select(a => a.GradeName).Distinct();

            var classnames = sheet.Select(a => a.ClassName).Distinct();

            var SchoolName = sheet.Select(a => a.SchoolName).Distinct();

            var schoolcode = _schoolInfoRespository.GetSchoolCodeByName(SchoolName.FirstOrDefault());
            var GradeCode = _gradeInfoRespository.GetGradeCodeBySchoolCode(schoolcode, gradenams.FirstOrDefault());
            var ClassCode = _classInfoRepository.GetClassCodeByGradeCode(GradeCode, classnames.FirstOrDefault());

            if (ClassCode == null)
            {
                stringBuilder.Append("数量错误:请您先核对，学校，班级，年级信息\n;");
            }
            else
            {
                var classpeoplenum = _StudentInfoRepository.getAllClassByCode(ClassCode.ClassCode);


                sheet.ForEach(w =>
                {
                    var x= classpeoplenum.Exists(a => a.IdNumber == w.IdNumber && a.Name == w.Name);

                    if (!classpeoplenum.Exists(a => a.IdNumber == w.IdNumber && a.Name == w.Name))
                    {
                        stringBuilder.Append("数据错误:'身份证号:" + Dtol.Helper.MD5.Decrypt(w.IdNumber)+",姓名:"+w.Name+"'不属于本班人员请仔细核对;\n");
                    }
                });


                  
                
            }
            return stringBuilder;
        }







    }
}
