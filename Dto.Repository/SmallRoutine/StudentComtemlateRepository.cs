using Dto.IRepository.SmallRoutine;
using Dtol;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dto.Repository.SmallRoutine
{
   public  class StudentComtemlateRepository: IStudentComtemlateRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Template_Student> DbSet;
        protected readonly DbSet<Health_Info> DbSetHealth;
        protected readonly DbSet<Class_Info> DbSetClass;
        protected readonly DbSet<Grade_Info> DbSetGrade;
        protected readonly DbSet<Student_DayandNight_Info> DbSetDayandNight;

        public StudentComtemlateRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Template_Student>();
            DbSetHealth = Db.Set<Health_Info>();
            DbSetClass = Db.Set<Class_Info>();
            DbSetGrade = Db.Set<Grade_Info>();
            DbSetDayandNight = Db.Set<Student_DayandNight_Info>();
        }



        public void CompTemplateStudent()
        {
            ComtemplateNotComeSchool();
            ComtemplateMorningSchool();
            ComtemplatenoonSchool();
            ComtemplateNightSchool();
            ComtemplateDaySchool();
            Db.SaveChanges();
        }

        public void ComtemplateNotComeSchool()
        {
           
            var dbsetclass = DbSetClass.ToList();
            //所有班级生成早午晚见
            for (int i = 0; i < dbsetclass.Count(); i++)
            {
                Template_Student template_Student = new Template_Student();
                string classcode = dbsetclass[i].ClassCode;

                var classStudents = Db.Student_Info.Where(a => a.ClassCode == classcode);

                var firstinfo = classStudents.FirstOrDefault();//一个班的班级都是一样的
                if (firstinfo == null)
                { continue; }

                template_Student.SchoolName = firstinfo.SchoolName;
                template_Student.SchoolCode = firstinfo.SchoolCode;
                template_Student.GradeCode = firstinfo.GradeCode;
                template_Student.GradeName = firstinfo.GradeName;
                template_Student.ClassCode = firstinfo.ClassCode;
                template_Student.ClassName = firstinfo.ClassName;




                // 应道人数
                template_Student.ShouldComeSchoolCount = Db.Student_Info.Where(a => a.ClassCode == classcode)
                                                       .Count();
                //实到
                template_Student.ActualComeSchoolCount = 0;
                //到了发热
                template_Student.ComeSchoolHotCount = 0;
                //未到
                template_Student.NotComeSchoolCount = Db.Student_Info.Where(a => a.ClassCode == classcode)
                                                       .Count();
                //因为发热没到
                template_Student.NotComeSchoolByHotCount = Db.Health_Info.Where(a => a.CheckType == "到校前" && a.Student_Info != null && Convert.ToDecimal(a.Temperature) >= 37.2m
                                                                                 && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                 && a.Student_Info.ClassCode == classcode
                                                                     ).Count();
                //其他原因没到      
                template_Student.NotComeSchoolByOtherCount = Db.Health_Info.Where(a => a.CheckType == "到校前" && a.Student_Info != null && a.NotComeSchoolReason == "其他"
                                                                                   && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                     && a.Student_Info.ClassCode == classcode
                                                                                ).Count();
                //因为在外地没到
                template_Student.NotComeSchoolByOutCount = Db.Health_Info.Where(a => a.CheckType == "到校前" && a.Student_Info != null && a.IsTianJin == "未在津"
                                                                                && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                  && a.Student_Info.ClassCode == classcode
                                                                             ).Count();

                template_Student.type = "到校前";
                template_Student.CreateDate = DateTime.Now;
                DbSet.Add(template_Student);
            }
        }
        public void ComtemplateMorningSchool()
        {
           
            var dbsetclass = DbSetClass.ToList();
            //所有班级生成早午晚见
            for (int i = 0; i < dbsetclass.Count(); i++)
            {
                Template_Student template_Student = new Template_Student();
                string classcode = dbsetclass[i].ClassCode;


                var studentsInfoClass = Db.Student_Info.Where(a => a.ClassCode == classcode).ToList();
                var firstinfo = studentsInfoClass.FirstOrDefault();//一个班的班级都是一样的
                if (firstinfo == null)
                { continue; }
                template_Student.SchoolName = firstinfo.SchoolName;
                template_Student.SchoolCode = firstinfo.SchoolCode;
                template_Student.GradeCode = firstinfo.GradeCode;
                template_Student.GradeName = firstinfo.GradeName;
                template_Student.ClassCode = firstinfo.ClassCode;
                template_Student.ClassName = firstinfo.ClassName;



                var dayandNightClass = DbSetDayandNight.FromSql("select Student_DayandNight_Info.* from Student_DayandNight_Info inner join Student_Info on " +
                                                                    "Student_DayandNight_Info.idnumber=Student_Info.idnumber" +
                                                                    " where Student_Info.ClassCode={0} ", classcode);
                // 应道人数
                template_Student.ShouldComeSchoolCount = studentsInfoClass.Count();
                //实到
                template_Student.ActualComeSchoolCount = dayandNightClass.Where(a => a.IsComeSchool == "是" && a.AddTimeInterval == "晨"
                                                                                    && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                    
                                                                                    ).Count();
                //到了发热
                template_Student.ComeSchoolHotCount = dayandNightClass.Where(a => a.IsComeSchool == "是" && a.AddTimeInterval == "晨" &&
                                                                                     a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")&& 
                                                                                    Convert.ToDecimal(a.Temperature)>=37.2m ).Count();
                //未到
                template_Student.NotComeSchoolCount = dayandNightClass.Where(a => a.IsComeSchool == "否" && a.AddTimeInterval == "晨"
                                                                                        && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")).Count();
                //因为发热没到
                template_Student.NotComeSchoolByHotCount = dayandNightClass.Where(a => a.AddTimeInterval == "晨"  && Convert.ToDecimal(a.Temperature) >= 37.2m
                                                                                 && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                 && a.IsComeSchool == "否"
                                                                     ).Count();
                //其他原因没到      
                template_Student.NotComeSchoolByOtherCount = dayandNightClass.Where(a => a.AddTimeInterval == "晨"  && a.NotComeJinReason=="其他"
                                                                                 && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                 && a.IsComeSchool == "否"
                                                                     ).Count(); 
                //因为在外地没到
                template_Student.NotComeSchoolByOutCount = dayandNightClass.Where(a => a.AddTimeInterval == "晨" &&  a.IsTianJin == "未在津"
                                                                                && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                             ).Count();
                template_Student.type = "晨";
                template_Student.CreateDate = DateTime.Now;
                DbSet.Add(template_Student);
            }
        }
        public void ComtemplatenoonSchool()
        {
          
            var dbsetclass = DbSetClass.ToList();
            //所有班级生成早午晚见
            for (int i = 0; i < dbsetclass.Count(); i++)
            {
                Template_Student template_Student = new Template_Student();
                string classcode = dbsetclass[i].ClassCode;


                var studentsInfoClass = Db.Student_Info.Where(a => a.ClassCode == classcode).ToList();
                var firstinfo = studentsInfoClass.FirstOrDefault();//一个班的班级都是一样的
                if (firstinfo == null)
                { continue; }
                template_Student.SchoolName = firstinfo.SchoolName;
                template_Student.SchoolCode = firstinfo.SchoolCode;
                template_Student.GradeCode = firstinfo.GradeCode;
                template_Student.GradeName = firstinfo.GradeName;
                template_Student.ClassCode = firstinfo.ClassCode;
                template_Student.ClassName = firstinfo.ClassName;

                var dayandNightClass = DbSetDayandNight.FromSql("select Student_DayandNight_Info.* from Student_DayandNight_Info inner join Student_Info on " +
                                                                        "Student_DayandNight_Info.idnumber=Student_Info.idnumber" +
                                                                     " where Student_Info.ClassCode={0} ", classcode);
                // 应道人数
                template_Student.ShouldComeSchoolCount = studentsInfoClass.Count();
                //实到 （实到-异常上报）
                template_Student.ActualComeSchoolCount = dayandNightClass.Where(a => a.IsComeSchool == "是" && a.AddTimeInterval == "午"
                                                                                    && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                   ).Count();
                //到了发热
                template_Student.ComeSchoolHotCount = dayandNightClass.Where(a => a.IsComeSchool == "是" && a.AddTimeInterval == "午" &&
                                                                                     a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd") &&
                                                                                    Convert.ToDecimal(a.Temperature) >= 37.2m).Count();
                //未到 （未到+异常上报）
                template_Student.NotComeSchoolCount = dayandNightClass.Where(a => a.IsComeSchool == "否" && a.AddTimeInterval == "午"
                                                                                        && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")).Count();
                //因为发热没到
                template_Student.NotComeSchoolByHotCount = dayandNightClass.Where(a => a.AddTimeInterval == "午" && Convert.ToDecimal(a.Temperature) >= 37.2m
                                                                                 && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                 && a.IsComeSchool == "否"
                                                                     ).Count();
                //其他原因没到      
                template_Student.NotComeSchoolByOtherCount = dayandNightClass.Where(a => a.AddTimeInterval == "午" && a.NotComeJinReason == "其他"
                                                                                 && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                 && a.IsComeSchool == "否"
                                                                     ).Count();
                //因为在外地没到
                template_Student.NotComeSchoolByOutCount = dayandNightClass.Where(a => a.AddTimeInterval == "午" && a.IsTianJin == "未在津"
                                                                                && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                             ).Count();
                template_Student.type = "午";
                template_Student.CreateDate = DateTime.Now;
                DbSet.Add(template_Student);
            }
        }
        public void ComtemplateNightSchool()
        {
          
            var dbsetclass = DbSetClass.ToList();
            //所有班级生成早午晚见
            for (int i = 0; i < dbsetclass.Count(); i++)
            {
                Template_Student template_Student = new Template_Student();
                string classcode = dbsetclass[i].ClassCode;


                var studentsInfoClass = Db.Student_Info.Where(a => a.ClassCode == classcode).ToList();
                var firstinfo = studentsInfoClass.FirstOrDefault();//一个班的班级都是一样的
                if (firstinfo == null)
                { continue; }
                template_Student.SchoolName = firstinfo.SchoolName;
                template_Student.SchoolCode = firstinfo.SchoolCode;
                template_Student.GradeCode = firstinfo.GradeCode;
                template_Student.GradeName = firstinfo.GradeName;
                template_Student.ClassCode = firstinfo.ClassCode;
                template_Student.ClassName = firstinfo.ClassName;

                var dayandNightClass = DbSetDayandNight.FromSql("select Student_DayandNight_Info.* from Student_DayandNight_Info inner join Student_Info on " +
                                                                         "Student_DayandNight_Info.idnumber=Student_Info.idnumber" +
                                                                         " where Student_Info.ClassCode={0} ", classcode);
                // 应道人数
                template_Student.ShouldComeSchoolCount = studentsInfoClass.Count();
                //实到
                template_Student.ActualComeSchoolCount = dayandNightClass.Where(a => a.IsComeSchool == "是" && a.AddTimeInterval == "晚"
                                                                                    && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                   ).Count();
                //到了发热
                template_Student.ComeSchoolHotCount = dayandNightClass.Where(a => a.IsComeSchool == "是" && a.AddTimeInterval == "晚" &&
                                                                                     a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd") &&
                                                                                    Convert.ToDecimal(a.Temperature) >= 37.2m).Count();
                //未到
                template_Student.NotComeSchoolCount = dayandNightClass.Where(a => a.IsComeSchool == "否" && a.AddTimeInterval == "晚"
                                                                                        && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")).Count();
                //因为发热没到
                template_Student.NotComeSchoolByHotCount = dayandNightClass.Where(a => a.AddTimeInterval == "晚" && Convert.ToDecimal(a.Temperature) >= 37.2m
                                                                                 && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                 && a.IsComeSchool == "否"
                                                                     ).Count();
                //其他原因没到      
                template_Student.NotComeSchoolByOtherCount = dayandNightClass.Where(a => a.AddTimeInterval == "晚" && a.NotComeJinReason == "其他"
                                                                                 && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                 && a.IsComeSchool == "否"
                                                                     ).Count();
                //因为在外地没到
                template_Student.NotComeSchoolByOutCount = dayandNightClass.Where(a => a.AddTimeInterval == "晚" && a.IsTianJin == "未在津"
                                                                                && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                             ).Count();
                template_Student.type = "晚";
                template_Student.CreateDate = DateTime.Now;
                DbSet.Add(template_Student);
            }
        }
        public void ComtemplateDaySchool()
        {
          
            var dbsetclass = DbSetClass.ToList();
            //所有班级生成早午晚见
            for (int i = 0; i < dbsetclass.Count(); i++)
            {
                Template_Student template_Student = new Template_Student();
                string classcode = dbsetclass[i].ClassCode;


                var studentsInfoClass = Db.Student_Info.Where(a => a.ClassCode == classcode).ToList();
                var firstinfo = studentsInfoClass.FirstOrDefault();//一个班的班级都是一样的
                if (firstinfo == null)
                { continue; }
                template_Student.SchoolName = firstinfo.SchoolName;
                template_Student.SchoolCode = firstinfo.SchoolCode;
                template_Student.GradeCode = firstinfo.GradeCode;
                template_Student.GradeName = firstinfo.GradeName;
                template_Student.ClassCode = firstinfo.ClassCode;
                template_Student.ClassName = firstinfo.ClassName;

                var dayandNightClass = DbSetDayandNight.FromSql("select Student_DayandNight_Info.* from Student_DayandNight_Info inner join Student_Info on " +
                                                                  "Student_DayandNight_Info.idnumber=Student_Info.idnumber" +
                                                            " where Student_Info.ClassCode={0} ", classcode);
                // 应道人数
                template_Student.ShouldComeSchoolCount = studentsInfoClass.Count();
                //实到
                template_Student.ActualComeSchoolCount = dayandNightClass.Where(a => a.IsComeSchool == "是" 
                                                                                    && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                   ).Count();
                //到了发热
                template_Student.ComeSchoolHotCount = dayandNightClass.Where(a => a.IsComeSchool == "是"  &&
                                                                                     a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd") &&
                                                                                    Convert.ToDecimal(a.Temperature) >= 37.2m).Count();
                //未到
                template_Student.NotComeSchoolCount = dayandNightClass.Where(a => a.IsComeSchool == "否" 
                                                                                        && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")).Count();
                //因为发热没到
                template_Student.NotComeSchoolByHotCount = dayandNightClass.Where(a =>  Convert.ToDecimal(a.Temperature) >= 37.2m
                                                                                 && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                 && a.IsComeSchool == "否"
                                                                     ).Count();
                //其他原因没到      
                template_Student.NotComeSchoolByOtherCount = dayandNightClass.Where(a =>  a.NotComeJinReason == "其他"
                                                                                 && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                 && a.IsComeSchool == "否"
                                                                     ).Count();
                //因为在外地没到
                template_Student.NotComeSchoolByOutCount = dayandNightClass.Where(a =>  a.IsTianJin == "未在津"
                                                                                && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                             ).Count();
                template_Student.type = "天";
                template_Student.CreateDate = DateTime.Now;
                DbSet.Add(template_Student);
            }
        }
        public object GetReportStatisticData()
        {
            // DbSet.where(a=>a.)
            return null;
            
        }



    }
}
