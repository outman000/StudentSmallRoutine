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
    public class EmployComtemplateRepository: IEmployComtemplateRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Template_Employment> DbSet;
        protected readonly DbSet<Health_Info> DbSetHealth;
        protected readonly DbSet<Class_Info> DbSetClass;
        protected readonly DbSet<Grade_Info> DbSetGrade;
        protected readonly DbSet<Student_DayandNight_Info> DbSetDayandNight;

        public EmployComtemplateRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Template_Employment>();
            DbSetHealth = Db.Set<Health_Info>();
            DbSetClass = Db.Set<Class_Info>();
            DbSetGrade = Db.Set<Grade_Info>();
            DbSetDayandNight = Db.Set<Student_DayandNight_Info>();
        }


        public void CompTemplateEmploy()
        {
         
            ComtemplateNotComeEmploy();
            ComtemplateMorningEmploy();
            ComtemplatenoonEmploy();
            ComtemplateNightEmploy();
            ComtemplateDayEmploy();
            Db.SaveChanges();
        }

        private void ComtemplateNotComeEmploy()
        {

            var station_Infos  = Db.Station_Info.ToList();
            //所班级生成早午晚见

            for (int i = 0; i < station_Infos.Count(); i++)
            {
                Template_Employment template_Student = new Template_Employment();



                var worker = Db.facultystaff_Info.FirstOrDefault(a => a.StaffCode == station_Infos[i].StaffCode);
                if (worker == null)
                {
                    continue;
                }


                template_Student.SchoolName = worker.SchoolName;
                template_Student.SchoolCode = worker.SchoolCode;
                template_Student.DepartName = worker.DepartName;
                template_Student.DepartCode = worker.DepartCode;
                template_Student.StaffName = worker.StaffName;
                template_Student.StaffCode = worker.StaffCode;
                // 应道人数
                template_Student.ShouldComeSchoolCount = Db.facultystaff_Info.Where(a => a.StaffCode == station_Infos[i].StaffCode)
                                                       .Count();
                //实到
                template_Student.ActualComeSchoolCount = 0;
                //到了发热
                template_Student.ComeSchoolHotCount = 0;
                //未到
                template_Student.NotComeSchoolCount = Db.facultystaff_Info.Where(a => a.StaffCode == station_Infos[i].StaffCode)
                                                       .Count();
             
                //因为发热没到
                template_Student.NotComeSchoolByHotCount = Db.Health_Info.Where(a => a.CheckType == "到校前" && a.facultystaff_Info != null && Convert.ToDecimal(a.Temperature) >= 37.2m
                                                                                 && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                     ).Count();
                //其他原因没到      
                template_Student.NotComeSchoolByOtherCount = Db.Health_Info.Where(a => a.CheckType == "到校前" && a.facultystaff_Info != null && a.NotComeSchoolReason == "其他"
                                                                                   && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                    && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                                ).Count();
                //因为在外地没到
                template_Student.NotComeSchoolByOutCount = Db.Health_Info.Where(a => a.CheckType == "到校前" && a.facultystaff_Info != null && a.IsTianJin == "未在津"
                                                                                && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                 && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                             ).Count();

                template_Student.type = "到校前";
                template_Student.CreateDate = DateTime.Now;
                DbSet.Add(template_Student);
            }



        }
        private void ComtemplateMorningEmploy()
        {

            var station_Infos = Db.Station_Info.ToList();
            //所有班级生成早午晚见
            for (int i = 0; i < station_Infos.Count(); i++)
            {
                Template_Employment template_Student = new Template_Employment();

                if (station_Infos[i].StaffCode == "010704")
                {
                    var aa = "aaa";
                }


                var worker = Db.facultystaff_Info.FirstOrDefault(a => a.StaffCode == station_Infos[i].StaffCode);
                if (worker == null)
                {
                    return;
                }

                template_Student.SchoolName = worker.SchoolName;
                template_Student.SchoolCode = worker.SchoolCode;
                template_Student.DepartName = worker.DepartName;
                template_Student.DepartCode = worker.DepartCode;
                template_Student.StaffName = worker.StaffName;
                template_Student.StaffCode = worker.StaffCode;

               

                // 应道人数
                template_Student.ShouldComeSchoolCount = Db.facultystaff_Info.Where(a => a.StaffCode == station_Infos[i].StaffCode)
                                                       .Count();

             
                                                    //&& a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                    //  && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                  //  );
                //到了发热


                //实到
                template_Student.ActualComeSchoolCount = Db.Health_Info.Where(a => a.IsComeSchool == "是" && a.CheckType == "晨"&& a.facultystaff_Info != null
                                                                                    && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                      && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                                   ).Count();
                //到了发热
                template_Student.ComeSchoolHotCount = Db.Health_Info.Where(a => a.IsComeSchool == "是" && a.CheckType == "晨" &&
                                                                                     a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd") &&
                                                                                    Convert.ToDecimal(a.Temperature) >= 37.2m
                                                                                    && a.facultystaff_Info != null
                                                                                      && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                                      ).Count();
                //未到
                template_Student.NotComeSchoolCount = Db.Health_Info.Where(a => a.IsComeSchool == "否" && a.CheckType == "晨" && a.facultystaff_Info != null
                                                                                        && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")).Count();
                //因为发热没到
                template_Student.NotComeSchoolByHotCount = Db.Health_Info.Where(a => a.CheckType == "晨" && Convert.ToDecimal(a.Temperature) >= 37.2m
                                                                                 && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                 && a.IsComeSchool == "否" && a.facultystaff_Info != null
                                                                                   && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                     ).Count();
                //其他原因没到      
                template_Student.NotComeSchoolByOtherCount = Db.Health_Info.Where(a => a.CheckType == "晨" && a.NotComeSchoolReason == "其他"
                                                                                 && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                 && a.IsComeSchool == "否" && a.facultystaff_Info != null
                                                                                   && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                     ).Count();
                //因为在外地没到
                template_Student.NotComeSchoolByOutCount = Db.Health_Info.Where(a => a.CheckType == "晨" && a.IsTianJin == "未在津" && a.facultystaff_Info != null
                                                                                && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                  && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                             ).Count();
                template_Student.type = "晨";
                template_Student.CreateDate = DateTime.Now;
                DbSet.Add(template_Student);
            }
        }
        private void ComtemplatenoonEmploy()
        {

            var station_Infos = Db.Station_Info.ToList();
            //所有班级生成早午晚见
            for (int i = 0; i < station_Infos.Count(); i++)
            {
                Template_Employment template_Student = new Template_Employment();


                var worker = Db.facultystaff_Info.FirstOrDefault(a => a.StaffCode == station_Infos[i].StaffCode);
                if (worker == null)
                {
                    return;
                }

                template_Student.SchoolName = worker.SchoolName;
                template_Student.SchoolCode = worker.SchoolCode;
                template_Student.DepartName = worker.DepartName;
                template_Student.DepartCode = worker.DepartCode;
                template_Student.StaffName = worker.StaffName;
                template_Student.StaffCode = worker.StaffCode;


                // 应道人数
                template_Student.ShouldComeSchoolCount = Db.facultystaff_Info.Where(a => a.StaffCode == station_Infos[i].StaffCode)
                                                       .Count();
                //实到 （实到-异常上报）
                template_Student.ActualComeSchoolCount = Db.Health_Info.Where(a => a.IsComeSchool == "是" && a.CheckType == "午"
                                                                                    && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                    && a.facultystaff_Info != null
                                                                                      && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                                   ).Count();
                //到了发热
                template_Student.ComeSchoolHotCount = Db.Health_Info.Where(a => a.IsComeSchool == "是" && a.CheckType == "午" &&
                                                                                     a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd") &&
                                                                                    Convert.ToDecimal(a.Temperature) >= 37.2m
                                                                                    && a.facultystaff_Info != null
                                                                                      && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                                      ).Count();
                //未到 （未到+异常上报）
                template_Student.NotComeSchoolCount = Db.Health_Info.Where(a => a.IsComeSchool == "否" && a.CheckType == "午"
                                                                            && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                            && a.facultystaff_Info != null
                                                                              && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                              ).Count();
                //因为发热没到
                template_Student.NotComeSchoolByHotCount = Db.Health_Info.Where(a => a.CheckType == "午" && Convert.ToDecimal(a.Temperature) >= 37.2m
                                                                                 && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                 && a.IsComeSchool == "否"
                                                                                 && a.facultystaff_Info != null
                                                                                   && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                     ).Count();
                //其他原因没到      
                template_Student.NotComeSchoolByOtherCount = Db.Health_Info.Where(a => a.CheckType == "午" && a.NotComeSchoolReason == "其他"
                                                                                 && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                 && a.IsComeSchool == "否"
                                                                                 && a.facultystaff_Info != null
                                                                                   && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                     ).Count();
                //因为在外地没到
                template_Student.NotComeSchoolByOutCount = Db.Health_Info.Where(a => a.CheckType == "午" && a.IsTianJin == "未在津"
                                                                                && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                && a.facultystaff_Info != null
                                                                                  && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                             ).Count();
                template_Student.type = "午";
                template_Student.CreateDate = DateTime.Now;
                DbSet.Add(template_Student);
            }
        }
        private void ComtemplateNightEmploy()
        {

            var station_Infos = Db.Station_Info.ToList();
            //所有班级生成早午晚见
            for (int i = 0; i < station_Infos.Count(); i++)
            {
                Template_Employment template_Student = new Template_Employment();


                var worker = Db.facultystaff_Info.FirstOrDefault(a => a.StaffCode == station_Infos[i].StaffCode);

                if (worker == null)
                {
                    return;
                }
                template_Student.SchoolName = worker.SchoolName;
                template_Student.SchoolCode = worker.SchoolCode;
                template_Student.DepartName = worker.DepartName;
                template_Student.DepartCode = worker.DepartCode;
                template_Student.StaffName = worker.StaffName;
                template_Student.StaffCode = worker.StaffCode;

                // 应道人数
                template_Student.ShouldComeSchoolCount = Db.facultystaff_Info.Where(a => a.StaffCode == station_Infos[i].StaffCode)
                                                       .Count();
                //实到
                template_Student.ActualComeSchoolCount = Db.Health_Info.Where(a => a.IsComeSchool == "是" && a.CheckType == "晚"
                                                                                    && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                    && a.facultystaff_Info != null
                                                                                      && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                                   ).Count();
                //到了发热
                template_Student.ComeSchoolHotCount = Db.Health_Info.Where(a => a.IsComeSchool == "是" && a.CheckType == "晚" &&
                                                                                     a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd") &&
                                                                                    Convert.ToDecimal(a.Temperature) >= 37.2m
                                                                                      && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                                    && a.facultystaff_Info != null).Count();
                //未到
                template_Student.NotComeSchoolCount = Db.Health_Info.Where(a => a.IsComeSchool == "否" && a.CheckType == "晚"
                                                                                        && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                        && a.facultystaff_Info != null
                                                                                          && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                                        ).Count();
                //因为发热没到
                template_Student.NotComeSchoolByHotCount = Db.Health_Info.Where(a => a.CheckType == "晚" && Convert.ToDecimal(a.Temperature) >= 37.2m
                                                                                 && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                 && a.IsComeSchool == "否"
                                                                                 && a.facultystaff_Info != null
                                                                                   && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                     ).Count();
                //其他原因没到      
                template_Student.NotComeSchoolByOtherCount = Db.Health_Info.Where(a => a.CheckType == "晚" && a.NotComeSchoolReason == "其他"
                                                                                 && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                 && a.IsComeSchool == "否"
                                                                                 && a.facultystaff_Info != null
                                                                                   && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                     ).Count();
                //因为在外地没到
                template_Student.NotComeSchoolByOutCount = Db.Health_Info.Where(a => a.CheckType == "晚" && a.IsTianJin == "未在津"
                                                                                && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                && a.facultystaff_Info != null
                                                                                  && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                             ).Count();
                template_Student.type = "晚";
                template_Student.CreateDate = DateTime.Now;
                DbSet.Add(template_Student);
            }
        }
        private void ComtemplateDayEmploy()
        {

            var station_Infos = Db.Station_Info.ToList();
            //所有班级生成早午晚见
            for (int i = 0; i < station_Infos.Count(); i++)
            {
                Template_Employment template_Student = new Template_Employment();


                var worker = Db.facultystaff_Info.FirstOrDefault(a => a.StaffCode == station_Infos[i].StaffCode);
                if (worker == null)
                {
                    return;
                }

                template_Student.SchoolName = worker.SchoolName;
                template_Student.SchoolCode = worker.SchoolCode;
                template_Student.DepartName = worker.DepartName;
                template_Student.DepartCode = worker.DepartCode;
                template_Student.StaffName = worker.StaffName;
                template_Student.StaffCode = worker.StaffCode;

                // 应道人数
                template_Student.ShouldComeSchoolCount = Db.facultystaff_Info.Where(a => a.StaffCode == station_Infos[i].StaffCode)
                                                       .Count();
                //实到
                template_Student.ActualComeSchoolCount = Db.Health_Info.Where(a => a.IsComeSchool == "是"
                                                                                    && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                    && a.facultystaff_Info != null
                                                                                      && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                                   ).Count();
                //到了发热
                template_Student.ComeSchoolHotCount = Db.Health_Info.Where(a => a.IsComeSchool == "是" &&
                                                                                     a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd") &&
                                                                                    Convert.ToDecimal(a.Temperature) >= 37.2m
                                                                                    && a.facultystaff_Info != null
                                                                                      && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                                    ).Count();
                //未到
                template_Student.NotComeSchoolCount = Db.Health_Info.Where(a => a.IsComeSchool == "否"
                                                                                        && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                        && a.facultystaff_Info != null
                                                                                          && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                                        ).Count();
                //因为发热没到
                template_Student.NotComeSchoolByHotCount = Db.Health_Info.Where(a => Convert.ToDecimal(a.Temperature) >= 37.2m
                                                                                 && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                 && a.IsComeSchool == "否"
                                                                                 && a.facultystaff_Info != null
                                                                                   && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                     ).Count();
                //其他原因没到      
                template_Student.NotComeSchoolByOtherCount = Db.Health_Info.Where(a => a.CheckType == "其他"
                                                                                 && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                 && a.IsComeSchool == "否"
                                                                                 && a.facultystaff_Info != null
                                                                                   && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                     ).Count();
                //因为在外地没到
                template_Student.NotComeSchoolByOutCount = Db.Health_Info.Where(a => a.IsTianJin == "未在津"
                                                                                && a.Createdate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                                                                                && a.facultystaff_Info != null
                                                                                  && a.facultystaff_Info.station_Info.StaffCode == station_Infos[i].StaffCode
                                                                             ).Count();
                template_Student.type = "天";
                template_Student.CreateDate = DateTime.Now;
                DbSet.Add(template_Student);
            }
        }


   

        public List<Template_Employment> GetCompTemplateEmploy(BaseStudentStasticViewModel baseStudentStasticViewModel)
        {
            List<Template_Employment> template_Students = new List<Template_Employment>();

            template_Students.AddRange(GetReportStatisticData(baseStudentStasticViewModel));//到校前初中高中小学
            template_Students.AddRange(GetReportStatisticMorningData(baseStudentStasticViewModel));//早初中高中小学
            template_Students.AddRange(GetReportStatistiNoonData(baseStudentStasticViewModel));//午初中高中小学
            template_Students.AddRange(GetReportStatistiNightData(baseStudentStasticViewModel));//晚高中小学
            return template_Students;

        }
        //到校前
        private List<Template_Employment> GetReportStatisticData(BaseStudentStasticViewModel baseStudentStasticViewModel)
        {
            List<Template_Employment> template_Students = new List<Template_Employment>();
            //到校前
            var searchresultGao = DbSet.Where(a => a.SchoolCode == baseStudentStasticViewModel.SchoolCode
                                                    && a.CreateDate.Value.ToString("yyyy-MM-dd") == baseStudentStasticViewModel.createdate.Value.ToString("yyyy-MM-dd")
                                                    && a.type == "到校前"
                                                    )
                                                    .GroupBy(m => new { m.SchoolCode, m.type, m.SchoolName })
                                                    .Select(a => new Template_Employment
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


            //早
            return template_Students;
        }
        //早
        private List<Template_Employment> GetReportStatisticMorningData(BaseStudentStasticViewModel baseStudentStasticViewModel)
        {
            List<Template_Employment> template_Students = new List<Template_Employment>();
            //到校前
            var searchresultGao = DbSet.Where(a => a.SchoolCode == baseStudentStasticViewModel.SchoolCode
                                                    && a.CreateDate.Value.ToString("yyyy-MM-dd") == baseStudentStasticViewModel.createdate.Value.ToString("yyyy-MM-dd")
                                                    && a.type == "早"
                                                    )
                                                    .GroupBy(m => new { m.SchoolCode, m.type, m.SchoolName })
                                                    .Select(a => new Template_Employment
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
            //早
            return template_Students;
        }
        //午
        private List<Template_Employment> GetReportStatistiNoonData(BaseStudentStasticViewModel baseStudentStasticViewModel)
        {
            List<Template_Employment> template_Students = new List<Template_Employment>();
            //到校前
            var searchresultGao = DbSet.Where(a => a.SchoolCode == baseStudentStasticViewModel.SchoolCode
                                                    && a.CreateDate.Value.ToString("yyyy-MM-dd") == baseStudentStasticViewModel.createdate.Value.ToString("yyyy-MM-dd")
                                                    && a.type == "午"
                                                    )
                                                    .GroupBy(m => new { m.SchoolCode, m.type, m.SchoolName })
                                                    .Select(a => new Template_Employment
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

   



            //早
            return template_Students;
        }
        //晚
        private List<Template_Employment> GetReportStatistiNightData(BaseStudentStasticViewModel baseStudentStasticViewModel)
        {
            List<Template_Employment> template_Students = new List<Template_Employment>();
          
            var searchresultGao = DbSet.Where(a => a.SchoolCode == baseStudentStasticViewModel.SchoolCode
                                                    && a.CreateDate.Value.ToString("yyyy-MM-dd") == baseStudentStasticViewModel.createdate.Value.ToString("yyyy-MM-dd")
                                                    && a.type == "晚"
                                                    )
                                                    .GroupBy(m => new { m.SchoolCode, m.type, m.SchoolName })
                                                    .Select(a => new Template_Employment
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

            //早
            return template_Students;
        }


    }
}
