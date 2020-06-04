using Dto.IRepository.SmallRoutine;
using Dtol;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.SmallRoutine.RequestViewModel.StatasticViewModel;

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
            //第二天凌晨 统计前一天数据
            string time = DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd");
            
            //到校前
            ComtemplateNotComeSchool(time);
            //早检
            ComtemplateMorningSchool(time);
            //午检
            ComtemplatenoonSchool(time);
            //晚检
            ComtemplateNightSchool(time);

            //统计当天的 20200603 开始作废不统计
            //ComtemplateDaySchool(); 
            Db.SaveChanges();
        }


        //到校前
        public void ComtemplateNotComeSchool(string time)
        {
            var dbsetclass = DbSetClass.ToList();
            //所有班级生成到校前 健康信息填报
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
                template_Student.ActualComeSchoolCount = Db.Health_Info.Where(a => a.CheckType == "到校前" && a.Student_Info != null && a.IsComeSchool == "是"
                                                                                 && a.Createdate.Value.ToString("yyyy-MM-dd") == time
                                                                                 && a.Student_Info.ClassCode == classcode
                                                                     ).Count();
                //到了发热
                template_Student.ComeSchoolHotCount = Db.Health_Info.Where(a => a.CheckType == "到校前" && a.Student_Info != null && Convert.ToDouble(a.Temperature) >= 37.2
                                                                                 && a.Createdate.Value.ToString("yyyy-MM-dd") == time && a.IsComeSchool == "是"
                                                                                 && a.Student_Info.ClassCode == classcode
                                                                     ).Count();
                //未到
                template_Student.NotComeSchoolCount = Db.Health_Info.Where(a => a.CheckType == "到校前" && a.Student_Info != null && a.IsComeSchool=="否"
                                                                                 && a.Createdate.Value.ToString("yyyy-MM-dd") == time 
                                                                                 && a.Student_Info.ClassCode == classcode
                                                                     ).Count();
                //因为发热没到
                template_Student.NotComeSchoolByHotCount = Db.Health_Info.Where(a => a.CheckType == "到校前" && a.Student_Info != null && Convert.ToDouble(a.Temperature) >= 37.2
                                                                                 && a.Createdate.Value.ToString("yyyy-MM-dd") == time && a.IsComeSchool == "否"
                                                                                 && a.Student_Info.ClassCode == classcode
                                                                     ).Count();
                //其他原因没到      
                template_Student.NotComeSchoolByOtherCount = Db.Health_Info.Where(a => a.CheckType == "到校前" && a.Student_Info != null && a.NotComeSchoolReason == "其他"
                                                                                   && a.Createdate.Value.ToString("yyyy-MM-dd") == time && a.IsComeSchool == "否"
                                                                                     && a.Student_Info.ClassCode == classcode
                                                                                ).Count();
                //因为在外地没到
                template_Student.NotComeSchoolByOutCount = Db.Health_Info.Where(a => a.CheckType == "到校前" && a.Student_Info != null && a.IsTianJin == "否"
                                                                                && a.Createdate.Value.ToString("yyyy-MM-dd") == time && a.IsComeSchool == "否"
                                                                                  && a.Student_Info.ClassCode == classcode
                                                                             ).Count();

                template_Student.type = "到校前";
                template_Student.CreateDate = DateTime.Now.AddDays(-1);
                DbSet.Add(template_Student);
            }
        }

        //晨检
        public void ComtemplateMorningSchool(string time)
        {
           
            var dbsetclass = DbSetClass.ToList();
            //所有班级生成早检
            for (int i = 0; i < dbsetclass.Count(); i++)
            {
             
                Template_Student template_Student = new Template_Student();
                ////午检查最晚的时间
                //var maxNoontime = Db.Health_Info.Where(a => a.CheckType == "午"
                //                                        && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                //                                        && a.Student_Info != null
                //                                            && a.Student_Info.class_Info.ClassCode == dbsetclass[i].ClassCode
                //                                        ).Select(w => w.Createdate).Max();
                ////午检查后的异常人数
                //var exceptnum = Db.Except_Info_Student.Where(a => a.CreateDate > maxNoontime && a.CreateDate<=DateTime.Now
                //                                && a.student_Info.class_Info.ClassCode == dbsetclass[i].ClassCode).Count();



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
                                                                                        && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == time

                                                                                        ).Count();
                    //到了发热
                    template_Student.ComeSchoolHotCount = dayandNightClass.Where(a => a.IsComeSchool == "是" && a.AddTimeInterval == "晨" &&
                                                                                         a.AddCreateDate.Value.ToString("yyyy-MM-dd") == time &&
                                                                                        Convert.ToDouble(a.Temperature) >= 37.2).Count();
                    //未到
                    template_Student.NotComeSchoolCount = dayandNightClass.Where(a => a.IsComeSchool == "否" && a.AddTimeInterval == "晨"
                                                                                            && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == time).Count();
                    //因为发热没到
                    template_Student.NotComeSchoolByHotCount = dayandNightClass.Where(a => a.AddTimeInterval == "晨" && Convert.ToDouble(a.Temperature) >= 37.2
                                                                                     && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == time
                                                                                     && a.IsComeSchool == "否"
                                                                         ).Count();
                    //其他原因没到      
                    template_Student.NotComeSchoolByOtherCount = dayandNightClass.Where(a => a.AddTimeInterval == "晨" && a.NotComeJinReason == "其他"
                                                                                     && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == time
                                                                                     && a.IsComeSchool == "否"
                                                                         ).Count();
                    //因为在外地没到
                    template_Student.NotComeSchoolByOutCount = dayandNightClass.Where(a => a.AddTimeInterval == "晨" && a.IsTianJin == "否"
                                                                                    && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == time
                                                                                 ).Count();
                    template_Student.type = "晨";
                    template_Student.CreateDate = DateTime.Now.AddDays(-1);
                    DbSet.Add(template_Student);

              
                   
            }
        }

        //午检
        public void ComtemplatenoonSchool(string time)
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
                template_Student.ActualComeSchoolCount = dayandNightClass.Where(a => a.IsComeSchool == "是" && a.AddTimeInterval == "午"
                                                                                    && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == time
                                                                                   ).Count();
                //到了发热
                template_Student.ComeSchoolHotCount = dayandNightClass.Where(a => a.IsComeSchool == "是" && a.AddTimeInterval == "午" &&
                                                                                     a.AddCreateDate.Value.ToString("yyyy-MM-dd") == time &&
                                                                                    Convert.ToDouble(a.Temperature) >= 37.2).Count();
                //未到  
                template_Student.NotComeSchoolCount = dayandNightClass.Where(a => a.IsComeSchool == "否" && a.AddTimeInterval == "午"
                                                                                        && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == time).Count();
                //因为发热没到
                template_Student.NotComeSchoolByHotCount = dayandNightClass.Where(a => a.AddTimeInterval == "午" && Convert.ToDouble(a.Temperature) >= 37.2
                                                                                 && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == time
                                                                                 && a.IsComeSchool == "否"
                                                                     ).Count();
                //其他原因没到      
                template_Student.NotComeSchoolByOtherCount = dayandNightClass.Where(a => a.AddTimeInterval == "午" && a.NotComeJinReason == "其他"
                                                                                 && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == time
                                                                                 && a.IsComeSchool == "否"
                                                                     ).Count();
                //因为在外地没到
                template_Student.NotComeSchoolByOutCount = dayandNightClass.Where(a => a.AddTimeInterval == "午" && a.IsTianJin == "否"
                                                                                && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == time  
                                                                             ).Count();
                template_Student.type = "午";
                template_Student.CreateDate = DateTime.Now.AddDays(-1);
                DbSet.Add(template_Student);
            }
        }

        //晚检
        public void ComtemplateNightSchool(string time)
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
                                                                                    && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == time
                                                                                   ).Count();
                //到了发热
                template_Student.ComeSchoolHotCount = dayandNightClass.Where(a => a.IsComeSchool == "是" && a.AddTimeInterval == "晚" &&
                                                                                     a.AddCreateDate.Value.ToString("yyyy-MM-dd") == time &&
                                                                                    Convert.ToDouble(a.Temperature) >= 37.2).Count();
                //未到
                template_Student.NotComeSchoolCount = dayandNightClass.Where(a => a.IsComeSchool == "否" && a.AddTimeInterval == "晚"
                                                                                        && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == time).Count();
                //因为发热没到
                template_Student.NotComeSchoolByHotCount = dayandNightClass.Where(a => a.AddTimeInterval == "晚" && Convert.ToDouble(a.Temperature) >= 37.2
                                                                                 && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == time
                                                                                 && a.IsComeSchool == "否"
                                                                     ).Count();
                //其他原因没到      
                template_Student.NotComeSchoolByOtherCount = dayandNightClass.Where(a => a.AddTimeInterval == "晚" && a.NotComeJinReason == "其他"
                                                                                 && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == time
                                                                                 && a.IsComeSchool == "否"
                                                                     ).Count();
                //因为在外地没到
                template_Student.NotComeSchoolByOutCount = dayandNightClass.Where(a => a.AddTimeInterval == "晚" && a.IsTianJin == "否"
                                                                                && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == time  
                                                                             ).Count();
                template_Student.type = "晚";
                template_Student.CreateDate = DateTime.Now.AddDays(-1);
                DbSet.Add(template_Student);
            }
        }

        //每日最终统计  20200603 作废
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
                                                                                    Convert.ToDouble(a.Temperature) >= 37.2).Count();
                //未到
                template_Student.NotComeSchoolCount = dayandNightClass.Where(a => a.IsComeSchool == "否" 
                                                                                        && a.AddCreateDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")).Count();
                //因为发热没到
                template_Student.NotComeSchoolByHotCount = dayandNightClass.Where(a =>  Convert.ToDouble(a.Temperature) >= 37.2
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



        public List<Template_Student> GetCompTemplateStudent(BaseStudentStasticViewModel baseStudentStasticViewModel)
        {
            List<Template_Student> template_Students = new List<Template_Student>();

            template_Students.AddRange(GetReportStatisticData(baseStudentStasticViewModel));//到校前初中高中小学
            template_Students.AddRange(GetReportStatisticMorningData(baseStudentStasticViewModel));//早初中高中小学
            template_Students.AddRange(GetReportStatistiNoonData(baseStudentStasticViewModel));//午初中高中小学
            template_Students.AddRange(GetReportStatistiNightData(baseStudentStasticViewModel));//晚高中小学
            return template_Students;

        }
        //到校前

        public List<Template_Student> GetReportStatisticData(BaseStudentStasticViewModel baseStudentStasticViewModel)
        {
            List<Template_Student> template_Students = new List<Template_Student>();
            //到校前
            var searchresultGao = DbSet.Where(a => a.SchoolCode == baseStudentStasticViewModel.SchoolCode
                                                    && a.CreateDate.Value.ToString("yyyy-MM-dd") == baseStudentStasticViewModel.createdate.Value.ToString("yyyy-MM-dd")
                                                    && a.type == "到校前"
                                                    && (a.ClassCode=="10"|| a.ClassCode == "11" || a.ClassCode == "12")
                                                    )
                                                    .GroupBy(m=>new { m.SchoolCode,m.type,m.SchoolName})
                                                    .Select(a => new Template_Student
                                                    {
                                                        SchoolName = a.Key.SchoolName,
                                                        SchoolCode = a.Key.SchoolCode,
                                                        type = a.Key.type,
                                                        ShouldComeSchoolCount = a.Sum(w=>w.ShouldComeSchoolCount),
                                                        ActualComeSchoolCount = a.Sum(w => w.ActualComeSchoolCount),
                                                        ComeSchoolHotCount = a.Sum(w => w.ComeSchoolHotCount),
                                                        NotComeSchoolCount = a.Sum(w => w.NotComeSchoolCount),
                                                        NotComeSchoolByHotCount = a.Sum(w => w.NotComeSchoolByHotCount),
                                                        NotComeSchoolByOutCount = a.Sum(w => w.NotComeSchoolByOutCount),
                                                        NotComeSchoolByOtherCount = a.Sum(w => w.NotComeSchoolByOtherCount)
                                                     }
                                                    );
            template_Students.AddRange(searchresultGao);

            var searchresultZhong = DbSet.Where(a => a.SchoolCode == baseStudentStasticViewModel.SchoolCode
                                                  && a.CreateDate.Value.ToString("yyyy-MM-dd") == baseStudentStasticViewModel.createdate.Value.ToString("yyyy-MM-dd")
                                                  && a.type == "到校前"
                                                  && (a.ClassCode == "7" || a.ClassCode == "8" || a.ClassCode == "9")
                                                  )
                                                  .GroupBy(m => new { m.SchoolCode, m.type, m.SchoolName })
                                  .Select(a => new Template_Student
                                  {
                                      SchoolName = a.Key.SchoolName,
                                      SchoolCode = a.Key.SchoolCode,
                                      type = a.Key.type,
                                      ShouldComeSchoolCount = a.Sum(w => w.ShouldComeSchoolCount),
                                      ActualComeSchoolCount = a.Sum(w => w.ActualComeSchoolCount),
                                      ComeSchoolHotCount = a.Sum(w => w.ComeSchoolHotCount),
                                      NotComeSchoolCount = a.Sum(w => w.NotComeSchoolCount),
                                      NotComeSchoolByHotCount = a.Sum(w => w.NotComeSchoolByHotCount),
                                      NotComeSchoolByOutCount = a.Sum(w => w.NotComeSchoolByOutCount),
                                      NotComeSchoolByOtherCount = a.Sum(w => w.NotComeSchoolByOtherCount)
                                  }
                                  );
            template_Students.AddRange(searchresultZhong);

            var searchresultXiao = DbSet.Where(a => a.SchoolCode == baseStudentStasticViewModel.SchoolCode
                                                  && a.CreateDate.Value.ToString("yyyy-MM-dd") == baseStudentStasticViewModel.createdate.Value.ToString("yyyy-MM-dd")
                                                  && a.type == "到校前"
                                                  && (a.ClassCode == "1" || a.ClassCode == "2" || a.ClassCode == "3"
                                                        || a.ClassCode == "4" || a.ClassCode == "5" || a.ClassCode == "6")
                                                  )
                                                  .GroupBy(m => new { m.SchoolCode, m.type, m.SchoolName })
                                  .Select(a => new Template_Student
                                  {
                                      SchoolName = a.Key.SchoolName,
                                      SchoolCode = a.Key.SchoolCode,
                                      type = a.Key.type,
                                      ShouldComeSchoolCount = a.Sum(w => w.ShouldComeSchoolCount),
                                      ActualComeSchoolCount = a.Sum(w => w.ActualComeSchoolCount),
                                      ComeSchoolHotCount = a.Sum(w => w.ComeSchoolHotCount),
                                      NotComeSchoolCount = a.Sum(w => w.NotComeSchoolCount),
                                      NotComeSchoolByHotCount = a.Sum(w => w.NotComeSchoolByHotCount),
                                      NotComeSchoolByOutCount = a.Sum(w => w.NotComeSchoolByOutCount),
                                      NotComeSchoolByOtherCount = a.Sum(w => w.NotComeSchoolByOtherCount)
                                  }
                                  );

            var searchresultXiaosum = DbSet.Where(a => a.SchoolCode == baseStudentStasticViewModel.SchoolCode
                                                 && a.CreateDate.Value.ToString("yyyy-MM-dd") == baseStudentStasticViewModel.createdate.Value.ToString("yyyy-MM-dd")
                                                 && a.type == "到校前"
                                          
                                                 )
                                                 .GroupBy(m => new { m.SchoolCode, m.type, m.SchoolName })
                                 .Select(a => new Template_Student
                                 {
                                     SchoolName = a.Key.SchoolName,
                                     SchoolCode = a.Key.SchoolCode,
                                     type = a.Key.type,
                                     ShouldComeSchoolCount = a.Sum(w => w.ShouldComeSchoolCount),
                                     ActualComeSchoolCount = a.Sum(w => w.ActualComeSchoolCount),
                                     ComeSchoolHotCount = a.Sum(w => w.ComeSchoolHotCount),
                                     NotComeSchoolCount = a.Sum(w => w.NotComeSchoolCount),
                                     NotComeSchoolByHotCount = a.Sum(w => w.NotComeSchoolByHotCount),
                                     NotComeSchoolByOutCount = a.Sum(w => w.NotComeSchoolByOutCount),
                                     NotComeSchoolByOtherCount = a.Sum(w => w.NotComeSchoolByOtherCount)
                                 }
                                 );

            template_Students.AddRange(searchresultXiaosum);
            //早
            return template_Students;
           }

        //早

        public List<Template_Student> GetReportStatisticMorningData(BaseStudentStasticViewModel baseStudentStasticViewModel)
        {
            List<Template_Student> template_Students = new List<Template_Student>();
            //到校前
            var searchresultGao = DbSet.Where(a => a.SchoolCode == baseStudentStasticViewModel.SchoolCode
                                                    && a.CreateDate.Value.ToString("yyyy-MM-dd") == baseStudentStasticViewModel.createdate.Value.ToString("yyyy-MM-dd")
                                                    && a.type == "早"
                                                    && (a.ClassCode == "10" || a.ClassCode == "11" || a.ClassCode == "12")
                                                    )
                                                    .GroupBy(m => new { m.SchoolCode, m.type, m.SchoolName })
                                                    .Select(a => new Template_Student
                                                    {
                                                        SchoolName = a.Key.SchoolName,
                                                        SchoolCode = a.Key.SchoolCode,
                                                        type = a.Key.type,
                                                        ShouldComeSchoolCount = a.Sum(w => w.ShouldComeSchoolCount),
                                                        ActualComeSchoolCount = a.Sum(w => w.ActualComeSchoolCount),
                                                        ComeSchoolHotCount = a.Sum(w => w.ComeSchoolHotCount),
                                                        NotComeSchoolCount = a.Sum(w => w.NotComeSchoolCount),
                                                        NotComeSchoolByHotCount = a.Sum(w => w.NotComeSchoolByHotCount),
                                                        NotComeSchoolByOutCount = a.Sum(w => w.NotComeSchoolByOutCount),
                                                        NotComeSchoolByOtherCount = a.Sum(w => w.NotComeSchoolByOtherCount)
                                                    }
                                                    );
            template_Students.AddRange(searchresultGao);

            var searchresultZhong = DbSet.Where(a => a.SchoolCode == baseStudentStasticViewModel.SchoolCode
                                                  && a.CreateDate.Value.ToString("yyyy-MM-dd") == baseStudentStasticViewModel.createdate.Value.ToString("yyyy-MM-dd")
                                                  && a.type == "早"
                                                  && (a.ClassCode == "7" || a.ClassCode == "8" || a.ClassCode == "9")
                                                  )
                                                  .GroupBy(m => new { m.SchoolCode, m.type, m.SchoolName })
                                  .Select(a => new Template_Student
                                  {
                                      SchoolName = a.Key.SchoolName,
                                      SchoolCode = a.Key.SchoolCode,
                                      type = a.Key.type,
                                      ShouldComeSchoolCount = a.Sum(w => w.ShouldComeSchoolCount),
                                      ActualComeSchoolCount = a.Sum(w => w.ActualComeSchoolCount),
                                      ComeSchoolHotCount = a.Sum(w => w.ComeSchoolHotCount),
                                      NotComeSchoolCount = a.Sum(w => w.NotComeSchoolCount),
                                      NotComeSchoolByHotCount = a.Sum(w => w.NotComeSchoolByHotCount),
                                      NotComeSchoolByOutCount = a.Sum(w => w.NotComeSchoolByOutCount),
                                      NotComeSchoolByOtherCount = a.Sum(w => w.NotComeSchoolByOtherCount)
                                  }
                                  );
            template_Students.AddRange(searchresultZhong);

            var searchresultXiao = DbSet.Where(a => a.SchoolCode == baseStudentStasticViewModel.SchoolCode
                                                  && a.CreateDate.Value.ToString("yyyy-MM-dd") == baseStudentStasticViewModel.createdate.Value.ToString("yyyy-MM-dd")
                                                  && a.type == "早"
                                                  && (a.ClassCode == "1" || a.ClassCode == "2" || a.ClassCode == "3"
                                                        || a.ClassCode == "4" || a.ClassCode == "5" || a.ClassCode == "6")
                                                  )
                                                  .GroupBy(m => new { m.SchoolCode, m.type, m.SchoolName })
                                  .Select(a => new Template_Student
                                  {
                                      SchoolName = a.Key.SchoolName,
                                      SchoolCode = a.Key.SchoolCode,
                                      type = a.Key.type,
                                      ShouldComeSchoolCount = a.Sum(w => w.ShouldComeSchoolCount),
                                      ActualComeSchoolCount = a.Sum(w => w.ActualComeSchoolCount),
                                      ComeSchoolHotCount = a.Sum(w => w.ComeSchoolHotCount),
                                      NotComeSchoolCount = a.Sum(w => w.NotComeSchoolCount),
                                      NotComeSchoolByHotCount = a.Sum(w => w.NotComeSchoolByHotCount),
                                      NotComeSchoolByOutCount = a.Sum(w => w.NotComeSchoolByOutCount),
                                      NotComeSchoolByOtherCount = a.Sum(w => w.NotComeSchoolByOtherCount)
                                  }
                                  );
            template_Students.AddRange(searchresultXiao);


            var searchresultsum = DbSet.Where(a => a.SchoolCode == baseStudentStasticViewModel.SchoolCode
                                                 && a.CreateDate.Value.ToString("yyyy-MM-dd") == baseStudentStasticViewModel.createdate.Value.ToString("yyyy-MM-dd")
                                                 && a.type == "早"
                                              
                                                 )
                                                 .GroupBy(m => new { m.SchoolCode, m.type, m.SchoolName })
                                 .Select(a => new Template_Student
                                 {
                                     SchoolName = a.Key.SchoolName,
                                     SchoolCode = a.Key.SchoolCode,
                                     type = a.Key.type,
                                     ShouldComeSchoolCount = a.Sum(w => w.ShouldComeSchoolCount),
                                     ActualComeSchoolCount = a.Sum(w => w.ActualComeSchoolCount),
                                     ComeSchoolHotCount = a.Sum(w => w.ComeSchoolHotCount),
                                     NotComeSchoolCount = a.Sum(w => w.NotComeSchoolCount),
                                     NotComeSchoolByHotCount = a.Sum(w => w.NotComeSchoolByHotCount),
                                     NotComeSchoolByOutCount = a.Sum(w => w.NotComeSchoolByOutCount),
                                     NotComeSchoolByOtherCount = a.Sum(w => w.NotComeSchoolByOtherCount)
                                 }
                                 );
            template_Students.AddRange(searchresultXiao);


            //早
            return template_Students;
        }

        //午

        public List<Template_Student> GetReportStatistiNoonData(BaseStudentStasticViewModel baseStudentStasticViewModel)
        {
            List<Template_Student> template_Students = new List<Template_Student>();
            //到校前
            var searchresultGao = DbSet.Where(a => a.SchoolCode == baseStudentStasticViewModel.SchoolCode
                                                    && a.CreateDate.Value.ToString("yyyy-MM-dd") == baseStudentStasticViewModel.createdate.Value.ToString("yyyy-MM-dd")
                                                    && a.type == "午"
                                                    && (a.ClassCode == "10" || a.ClassCode == "11" || a.ClassCode == "12")
                                                    )
                                                    .GroupBy(m => new { m.SchoolCode, m.type, m.SchoolName })
                                                    .Select(a => new Template_Student
                                                    {
                                                        SchoolName = a.Key.SchoolName,
                                                        SchoolCode = a.Key.SchoolCode,
                                                        type = a.Key.type,
                                                        ShouldComeSchoolCount = a.Sum(w => w.ShouldComeSchoolCount),
                                                        ActualComeSchoolCount = a.Sum(w => w.ActualComeSchoolCount),
                                                        ComeSchoolHotCount = a.Sum(w => w.ComeSchoolHotCount),
                                                        NotComeSchoolCount = a.Sum(w => w.NotComeSchoolCount),
                                                        NotComeSchoolByHotCount = a.Sum(w => w.NotComeSchoolByHotCount),
                                                        NotComeSchoolByOutCount = a.Sum(w => w.NotComeSchoolByOutCount),
                                                        NotComeSchoolByOtherCount = a.Sum(w => w.NotComeSchoolByOtherCount)
                                                    }
                                                    );
            template_Students.AddRange(searchresultGao);

            var searchresultZhong = DbSet.Where(a => a.SchoolCode == baseStudentStasticViewModel.SchoolCode
                                                  && a.CreateDate.Value.ToString("yyyy-MM-dd") == baseStudentStasticViewModel.createdate.Value.ToString("yyyy-MM-dd")
                                                  && a.type == "午"
                                                  && (a.ClassCode == "7" || a.ClassCode == "8" || a.ClassCode == "9")
                                                  )
                                                  .GroupBy(m => new { m.SchoolCode, m.type, m.SchoolName })
                                  .Select(a => new Template_Student
                                  {
                                      SchoolName = a.Key.SchoolName,
                                      SchoolCode = a.Key.SchoolCode,
                                      type = a.Key.type,
                                      ShouldComeSchoolCount = a.Sum(w => w.ShouldComeSchoolCount),
                                      ActualComeSchoolCount = a.Sum(w => w.ActualComeSchoolCount),
                                      ComeSchoolHotCount = a.Sum(w => w.ComeSchoolHotCount),
                                      NotComeSchoolCount = a.Sum(w => w.NotComeSchoolCount),
                                      NotComeSchoolByHotCount = a.Sum(w => w.NotComeSchoolByHotCount),
                                      NotComeSchoolByOutCount = a.Sum(w => w.NotComeSchoolByOutCount),
                                      NotComeSchoolByOtherCount = a.Sum(w => w.NotComeSchoolByOtherCount)
                                  }
                                  );
            template_Students.AddRange(searchresultZhong);

            var searchresultXiao = DbSet.Where(a => a.SchoolCode == baseStudentStasticViewModel.SchoolCode
                                                  && a.CreateDate.Value.ToString("yyyy-MM-dd") == baseStudentStasticViewModel.createdate.Value.ToString("yyyy-MM-dd")
                                                  && a.type == "午"
                                                  && (a.ClassCode == "1" || a.ClassCode == "2" || a.ClassCode == "3"
                                                        || a.ClassCode == "4" || a.ClassCode == "5" || a.ClassCode == "6")
                                                  )
                                                  .GroupBy(m => new { m.SchoolCode, m.type, m.SchoolName })
                                  .Select(a => new Template_Student
                                  {
                                      SchoolName = a.Key.SchoolName,
                                      SchoolCode = a.Key.SchoolCode,
                                      type = a.Key.type,
                                      ShouldComeSchoolCount = a.Sum(w => w.ShouldComeSchoolCount),
                                      ActualComeSchoolCount = a.Sum(w => w.ActualComeSchoolCount),
                                      ComeSchoolHotCount = a.Sum(w => w.ComeSchoolHotCount),
                                      NotComeSchoolCount = a.Sum(w => w.NotComeSchoolCount),
                                      NotComeSchoolByHotCount = a.Sum(w => w.NotComeSchoolByHotCount),
                                      NotComeSchoolByOutCount = a.Sum(w => w.NotComeSchoolByOutCount),
                                      NotComeSchoolByOtherCount = a.Sum(w => w.NotComeSchoolByOtherCount)
                                  }
                                  );
            template_Students.AddRange(searchresultXiao);



            var searchresultsum= DbSet.Where(a => a.SchoolCode == baseStudentStasticViewModel.SchoolCode
                                                && a.CreateDate.Value.ToString("yyyy-MM-dd") == baseStudentStasticViewModel.createdate.Value.ToString("yyyy-MM-dd")
                                                && a.type == "午"
                                                )
                                                .GroupBy(m => new { m.SchoolCode, m.type, m.SchoolName })
                                .Select(a => new Template_Student
                                {
                                    SchoolName = a.Key.SchoolName,
                                    SchoolCode = a.Key.SchoolCode,
                                    type = a.Key.type,
                                    ShouldComeSchoolCount = a.Sum(w => w.ShouldComeSchoolCount),
                                    ActualComeSchoolCount = a.Sum(w => w.ActualComeSchoolCount),
                                    ComeSchoolHotCount = a.Sum(w => w.ComeSchoolHotCount),
                                    NotComeSchoolCount = a.Sum(w => w.NotComeSchoolCount),
                                    NotComeSchoolByHotCount = a.Sum(w => w.NotComeSchoolByHotCount),
                                    NotComeSchoolByOutCount = a.Sum(w => w.NotComeSchoolByOutCount),
                                    NotComeSchoolByOtherCount = a.Sum(w => w.NotComeSchoolByOtherCount)
                                }
                                );
            template_Students.AddRange(searchresultXiao);



            //早
            return template_Students;
        }
        //晚

        public List<Template_Student> GetReportStatistiNightData(BaseStudentStasticViewModel baseStudentStasticViewModel)
        {
            List<Template_Student> template_Students = new List<Template_Student>();
            //到校前
            var searchresultGao = DbSet.Where(a => a.SchoolCode == baseStudentStasticViewModel.SchoolCode
                                                    && a.CreateDate.Value.ToString("yyyy-MM-dd") == baseStudentStasticViewModel.createdate.Value.ToString("yyyy-MM-dd")
                                                    && a.type == "晚"
                                                    && (a.ClassCode == "10" || a.ClassCode == "11" || a.ClassCode == "12")
                                                    )
                                                    .GroupBy(m => new { m.SchoolCode, m.type, m.SchoolName })
                                                    .Select(a => new Template_Student
                                                    {
                                                        SchoolName = a.Key.SchoolName,
                                                        SchoolCode = a.Key.SchoolCode,
                                                        type = a.Key.type,
                                                        ShouldComeSchoolCount = a.Sum(w => w.ShouldComeSchoolCount),
                                                        ActualComeSchoolCount = a.Sum(w => w.ActualComeSchoolCount),
                                                        ComeSchoolHotCount = a.Sum(w => w.ComeSchoolHotCount),
                                                        NotComeSchoolCount = a.Sum(w => w.NotComeSchoolCount),
                                                        NotComeSchoolByHotCount = a.Sum(w => w.NotComeSchoolByHotCount),
                                                        NotComeSchoolByOutCount = a.Sum(w => w.NotComeSchoolByOutCount),
                                                        NotComeSchoolByOtherCount = a.Sum(w => w.NotComeSchoolByOtherCount)
                                                    }
                                                    );
            template_Students.AddRange(searchresultGao);

            var searchresultZhong = DbSet.Where(a => a.SchoolCode == baseStudentStasticViewModel.SchoolCode
                                                  && a.CreateDate.Value.ToString("yyyy-MM-dd") == baseStudentStasticViewModel.createdate.Value.ToString("yyyy-MM-dd")
                                                  && a.type == "晚"
                                                  && (a.ClassCode == "7" || a.ClassCode == "8" || a.ClassCode == "9")
                                                  )
                                                  .GroupBy(m => new { m.SchoolCode, m.type, m.SchoolName })
                                  .Select(a => new Template_Student
                                  {
                                      SchoolName = a.Key.SchoolName,
                                      SchoolCode = a.Key.SchoolCode,
                                      type = a.Key.type,
                                      ShouldComeSchoolCount = a.Sum(w => w.ShouldComeSchoolCount),
                                      ActualComeSchoolCount = a.Sum(w => w.ActualComeSchoolCount),
                                      ComeSchoolHotCount = a.Sum(w => w.ComeSchoolHotCount),
                                      NotComeSchoolCount = a.Sum(w => w.NotComeSchoolCount),
                                      NotComeSchoolByHotCount = a.Sum(w => w.NotComeSchoolByHotCount),
                                      NotComeSchoolByOutCount = a.Sum(w => w.NotComeSchoolByOutCount),
                                      NotComeSchoolByOtherCount = a.Sum(w => w.NotComeSchoolByOtherCount)
                                  }
                                  );
            template_Students.AddRange(searchresultZhong);

            var searchresultXiao = DbSet.Where(a => a.SchoolCode == baseStudentStasticViewModel.SchoolCode
                                                  && a.CreateDate.Value.ToString("yyyy-MM-dd") == baseStudentStasticViewModel.createdate.Value.ToString("yyyy-MM-dd")
                                                  && a.type == "晚"
                                                  && (a.ClassCode == "1" || a.ClassCode == "2" || a.ClassCode == "3"
                                                        || a.ClassCode == "4" || a.ClassCode == "5" || a.ClassCode == "6")
                                                  )
                                                  .GroupBy(m => new { m.SchoolCode, m.type, m.SchoolName })
                                  .Select(a => new Template_Student
                                  {
                                      SchoolName = a.Key.SchoolName,
                                      SchoolCode = a.Key.SchoolCode,
                                      type = a.Key.type,
                                      ShouldComeSchoolCount = a.Sum(w => w.ShouldComeSchoolCount),
                                      ActualComeSchoolCount = a.Sum(w => w.ActualComeSchoolCount),
                                      ComeSchoolHotCount = a.Sum(w => w.ComeSchoolHotCount),
                                      NotComeSchoolCount = a.Sum(w => w.NotComeSchoolCount),
                                      NotComeSchoolByHotCount = a.Sum(w => w.NotComeSchoolByHotCount),
                                      NotComeSchoolByOutCount = a.Sum(w => w.NotComeSchoolByOutCount),
                                      NotComeSchoolByOtherCount = a.Sum(w => w.NotComeSchoolByOtherCount)
                                  }
                                  );
            template_Students.AddRange(searchresultXiao);


            var searchresultSum = DbSet.Where(a => a.SchoolCode == baseStudentStasticViewModel.SchoolCode
                                                 && a.CreateDate.Value.ToString("yyyy-MM-dd") == baseStudentStasticViewModel.createdate.Value.ToString("yyyy-MM-dd")
                                                 && a.type == "晚"
                                                 
                                                 )
                                                 .GroupBy(m => new { m.SchoolCode, m.type, m.SchoolName })
                                 .Select(a => new Template_Student
                                 {
                                     SchoolName = a.Key.SchoolName,
                                     SchoolCode = a.Key.SchoolCode,
                                     type = a.Key.type,
                                     ShouldComeSchoolCount = a.Sum(w => w.ShouldComeSchoolCount),
                                     ActualComeSchoolCount = a.Sum(w => w.ActualComeSchoolCount),
                                     ComeSchoolHotCount = a.Sum(w => w.ComeSchoolHotCount),
                                     NotComeSchoolCount = a.Sum(w => w.NotComeSchoolCount),
                                     NotComeSchoolByHotCount = a.Sum(w => w.NotComeSchoolByHotCount),
                                     NotComeSchoolByOutCount = a.Sum(w => w.NotComeSchoolByOutCount),
                                     NotComeSchoolByOtherCount = a.Sum(w => w.NotComeSchoolByOtherCount)
                                 }
                                 );
            template_Students.AddRange(searchresultXiao);
            //早
            return template_Students;
        }

       
    }
}
