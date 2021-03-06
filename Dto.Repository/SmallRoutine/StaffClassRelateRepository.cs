﻿using Dto.IRepository.SmallRoutine;
using Dtol;
using Dtol.dtol;
using Dtol.Extension;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.MiddelViewModel.SecondMiddleViewModel;
using ViewModel.SmallRoutine.RequestViewModel.DayAndNightViewModel;
using ViewModel.SmallRoutine.RequestViewModel.FacultystaffViewModel;
using ViewModel.SmallRoutine.RequestViewModel.StaffClassRelateViewModel;

namespace Dto.Repository.SmallRoutine
{
    public class StaffClassRelateRepository : IStaffClassRelateRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<ClassManager_Relate> DbSet;

        public StaffClassRelateRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<ClassManager_Relate>();
        }

        public void Add(ClassManager_Relate obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ClassManager_Relate> GetAll()
        {
            throw new NotImplementedException();
        }

        public ClassManager_Relate GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<StaffClassMiddleModel> GetStudentsByStaff(StaffClassRelateSearchViewModel staffClassRelateSearchView)
        {
            int SkipNum = staffClassRelateSearchView.pageViewModel.CurrentPageNum * staffClassRelateSearchView.pageViewModel.PageSize;
            var preciaateStudent = GetByModelWhere(staffClassRelateSearchView);
            List<StaffClassMiddleModel> staffClassMiddleModel = new List<StaffClassMiddleModel>();

            //List<Student_Info> student_Infos = new List<Student_Info>();
            //List<Health_Info> Health_Info = new List<Health_Info>();
            if (staffClassRelateSearchView.RoleID == "sys")
            {
                var tempresult = Db.Health_Info.Where(preciaateStudent).Where(info => info.Student_InfoId != null)
                    .Select(a => new StaffClassMiddleModel
                    {
                        SchoolName=a.Student_Info.SchoolName,
                        ClassName = a.Student_Info.ClassName,
                        GradeName = a.Student_Info.GradeName,
                        Name = a.Student_Info.Name,
                        Createdate = a.Createdate,
                        IsComeSchool = a.IsComeSchool,
                        IdNumber = Dtol.Helper.MD5.Decrypt(a.IdNumber),
                        id = a.id,
                        IsFamilyHot = a.IsFamilyHot,
                        IsFamilyThroat = a.IsFamilyThroat,
                        IsFamilyWeakt = a.IsFamilyWeakt,
                        IsHot = a.IsHot,
                        IsThroat = a.IsThroat,
                        IsTouch = a.IsTouch,
                        IsWeak = a.IsWeak,
                        IsAggregate = a.IsAggregate,
                        IsAggregateContain = a.IsAggregateContain,
                        IsTianJin = a.IsTianJin,
                        Temperature = a.Temperature,
                        NotComeSchoolReason = a.NotComeSchoolReason,
                        IsBulu = a.IsBulu,
                        Student_InfoId = a.Student_Info.id
                    })
                    .ToList();
                staffClassMiddleModel.AddRange(tempresult);
            }
            else
            {
                var searchResult = DbSet
                    .Where(a => a.facultystaff_InfoId == staffClassRelateSearchView.UserKeyId)
                    .Include(a => a.Class_Info).ToList();
                for (int i = 0; i < searchResult.Count(); i++)
                {
                    var tempresult = Db.Health_Info.Where(a => a.Student_Info.class_InfoId == searchResult[i].Class_InfoId)
                         .Where(preciaateStudent)
                         .Select(a => new StaffClassMiddleModel
                         {
                             SchoolName = a.Student_Info.SchoolName,
                             ClassName = a.Student_Info.ClassName,
                             GradeName = a.Student_Info.GradeName,
                             Name = a.Student_Info.Name,
                             Createdate = a.Createdate,
                             IsComeSchool = a.IsComeSchool,
                             IdNumber = Dtol.Helper.MD5.Decrypt(a.IdNumber),
                             id = a.id,
                             IsFamilyHot = a.IsFamilyHot,
                             IsFamilyThroat = a.IsFamilyThroat,
                             IsFamilyWeakt = a.IsFamilyWeakt,
                             IsHot = a.IsHot,
                             IsThroat = a.IsThroat,
                             IsTouch = a.IsTouch,
                             IsWeak = a.IsWeak,
                             IsAggregate = a.IsAggregate,
                             IsAggregateContain = a.IsAggregateContain,
                             IsTianJin = a.IsTianJin,
                             Temperature = a.Temperature,
                             NotComeSchoolReason = a.NotComeSchoolReason,
                             IsBulu = a.IsBulu,
                             Student_InfoId = a.Student_Info.id
                         })

                         .ToList();
                    staffClassMiddleModel.AddRange(tempresult);
                }
            }

            return staffClassMiddleModel.Distinct().OrderByDescending(o => o.Createdate).Skip(SkipNum)
                .Take(staffClassRelateSearchView.pageViewModel.PageSize)
              .ToList();

        }

        public List<StaffSchoolClassMiddleModel> GetStudentsByStaffSchool(StaffSchoolClassRelateSearchViewModel staffClassRelateSearchView)
        {
            int SkipNum = staffClassRelateSearchView.pageViewModel.CurrentPageNum * staffClassRelateSearchView.pageViewModel.PageSize;
            var preciaateStudent = GetBySchoolModelWhere(staffClassRelateSearchView);
            List<StaffSchoolClassMiddleModel> staffClassMiddleModel = new List<StaffSchoolClassMiddleModel>();

            //List<Student_Info> student_Infos = new List<Student_Info>();
            //List<Health_Info> Health_Info = new List<Health_Info>();
            if (staffClassRelateSearchView.RoleID == "sys")
            {
                var tempresult = Db.Health_Info.Where(preciaateStudent).Where(info => info.Student_InfoId != null)
                    .Select(a => new StaffSchoolClassMiddleModel
                    {
                        SchoolName = a.Student_Info.SchoolName,
                        SchoolCode =a.Student_Info.SchoolCode,
                        ClassName = a.Student_Info.ClassName,
                        GradeName = a.Student_Info.GradeName,
                        Name = a.Student_Info.Name,
                        Createdate = a.Createdate,
                        IsComeSchool = a.IsComeSchool,
                        IdNumber = Dtol.Helper.MD5.Decrypt(a.IdNumber),
                        id = a.id,
                        IsFamilyHot = a.IsFamilyHot,
                        IsFamilyThroat = a.IsFamilyThroat,
                        IsFamilyWeakt = a.IsFamilyWeakt,
                        IsHot = a.IsHot,
                        IsThroat = a.IsThroat,
                        IsTouch = a.IsTouch,
                        IsWeak = a.IsWeak,
                        IsAggregate = a.IsAggregate,
                        IsAggregateContain = a.IsAggregateContain,
                        IsTianJin = a.IsTianJin,
                        Temperature = a.Temperature,
                        NotComeSchoolReason = a.NotComeSchoolReason,
                        IsBulu = a.IsBulu,
                        Student_InfoId = a.Student_Info.id
                    })
                    .ToList();
                staffClassMiddleModel.AddRange(tempresult);
            }
            else
            {
                var searchResult = DbSet
                    .Where(a => a.facultystaff_InfoId == staffClassRelateSearchView.UserKeyId)
                    .Include(a => a.Class_Info).ToList();
                for (int i = 0; i < searchResult.Count(); i++)
                {
                    var tempresult = Db.Health_Info.Where(a => a.Student_Info.class_InfoId == searchResult[i].Class_InfoId)
                         .Where(preciaateStudent)
                         .Select(a => new StaffSchoolClassMiddleModel
                         {
                             SchoolName = a.Student_Info.SchoolName,
                             SchoolCode = a.Student_Info.SchoolCode,
                             ClassName = a.Student_Info.ClassName,
                             GradeName = a.Student_Info.GradeName,
                             Name = a.Student_Info.Name,
                             Createdate = a.Createdate,
                             IsComeSchool = a.IsComeSchool,
                             IdNumber = Dtol.Helper.MD5.Decrypt(a.IdNumber),
                             id = a.id,
                             IsFamilyHot = a.IsFamilyHot,
                             IsFamilyThroat = a.IsFamilyThroat,
                             IsFamilyWeakt = a.IsFamilyWeakt,
                             IsHot = a.IsHot,
                             IsThroat = a.IsThroat,
                             IsTouch = a.IsTouch,
                             IsWeak = a.IsWeak,
                             IsAggregate = a.IsAggregate,
                             IsAggregateContain = a.IsAggregateContain,
                             IsTianJin = a.IsTianJin,
                             Temperature = a.Temperature,
                             NotComeSchoolReason = a.NotComeSchoolReason,
                             IsBulu = a.IsBulu,
                             Student_InfoId = a.Student_Info.id
                         })

                         .ToList();
                    staffClassMiddleModel.AddRange(tempresult);
                }
            }

            return staffClassMiddleModel.Distinct().OrderByDescending(o => o.Createdate).Skip(SkipNum)
                .Take(staffClassRelateSearchView.pageViewModel.PageSize)
              .ToList();

        }

        public List<DefaultDayAndNightMiddle> GetDefaultStudentsInfosByStaff(DayAndNightDefaultSearchViewModel dayAndNightDefaultSearchViewModel)
        {
            int SkipNum = dayAndNightDefaultSearchViewModel.pageViewModel.CurrentPageNum * dayAndNightDefaultSearchViewModel.pageViewModel.PageSize;


            List<DefaultDayAndNightMiddle> staffClassMiddleModel = new List<DefaultDayAndNightMiddle>();

            var tStudentDefaultpreciate = getStudentDefaultWhere(dayAndNightDefaultSearchViewModel);
            var DefaultInfoDayAndNight = getDefaultInfoDayAndNightWhere(dayAndNightDefaultSearchViewModel);


            staffClassMiddleModel = (from relate in DbSet
                             .Where(a => a.facultystaff_InfoId == dayAndNightDefaultSearchViewModel.userKey)
                             .Include(a => a.Class_Info)
                                     join student in Db.Student_Info.Where(tStudentDefaultpreciate) on relate.Class_InfoId equals student.class_InfoId
                                     join dayandnight in Db.Student_DayandNight_Info.Where(DefaultInfoDayAndNight) on student.IdNumber equals dayandnight.IdNumber
                                     into mergeinfo //这里是是班级对应当日的早午晚检查
                                     from result in mergeinfo.DefaultIfEmpty()//以基本信息为基础左关联查询
                                     select new DefaultDayAndNightMiddle
                                     {
                                         ClassName = student.ClassName,
                                         GradeName = student.GradeName,
                                         IdNumber = student.IdNumber,
                                         ClassCode = student.ClassCode,
                                         GradeCode = student.GradeCode,
                                         SchoolCode = student.SchoolCode,
                                         Name = student.Name,
                                         SchoolName = student.SchoolName,
                                         IsComeSchool = result.IsComeSchool == null ? result.IsComeSchool : "",
                                         IsTianJin = result.IsTianJin == null ? result.IsTianJin : "",
                                         NotComeJinReason = result.NotComeJinReason == null ? result.NotComeJinReason : "",
                                         Temperature = result.Temperature == null ? result.Temperature : "",
                                         AddTimeInterval = result.AddTimeInterval == null ? result.AddTimeInterval : "",
                                         addCreatedate = result.AddCreateDate,
                                         isup = result.IdNumber == null ? "未上传" : "已上传"
                                     }).OrderBy(o => o.ClassName).ToList();
            return staffClassMiddleModel;

        }
        public Expression<Func<Student_Info, bool>> GeInfoWhere(DayAndNightDefaultSearchViewModel dayAndNightDefaultSearchViewModel)
        {

            var predicate = WhereExtension.True<Student_Info>();//初始化where表达式
                                                                //姓名
            predicate = predicate.And(p => p.SchoolCode.Contains(dayAndNightDefaultSearchViewModel.SchoolCode));
            predicate = predicate.And(p => p.ClassName.Contains(dayAndNightDefaultSearchViewModel.ClassCode));
            predicate = predicate.And(p => p.GradeName.Contains(dayAndNightDefaultSearchViewModel.GradeCode));
            predicate = predicate.And(p => p.Name.Contains(dayAndNightDefaultSearchViewModel.Name));
            predicate = predicate.And(p => p.IdNumber.Contains(Dtol.Helper.MD5.Md5Hash(dayAndNightDefaultSearchViewModel.Idnumber)));
            return predicate;
        }

        public Expression<Func<Student_Info, bool>> getStudentDefaultWhere(DayAndNightDefaultSearchViewModel dayAndNightDefaultSearchViewModel)
        {

            var predicate = WhereExtension.True<Student_Info>();//初始化where表达式
                                                                //姓名
                                                                //predicate = predicate.And(p => p.addCreatedate.Value.ToString("yyyy-MM-dd").Contains(dayAndNightDefaultSearchViewModel.AddCreateDate.Value.ToString("yyyy-MM-dd")));
                                                                //predicate = predicate.And(p => p.AddTimeInterval.Contains(dayAndNightDefaultSearchViewModel.AddTimeInterval));
            predicate = predicate.And(p => p.IdNumber.Contains(Dtol.Helper.MD5.Md5Hash(dayAndNightDefaultSearchViewModel.Idnumber)));
            predicate = predicate.And(p => p.Name.Contains(dayAndNightDefaultSearchViewModel.Idnumber));
            predicate = predicate.And(p => p.GradeCode.Contains(dayAndNightDefaultSearchViewModel.GradeCode));
            predicate = predicate.And(p => p.ClassCode.Contains(dayAndNightDefaultSearchViewModel.ClassCode));
            predicate = predicate.And(p => p.SchoolCode.Contains(dayAndNightDefaultSearchViewModel.SchoolCode));
            return predicate;
        }

        public Expression<Func<Student_DayandNight_Info, bool>> getDefaultInfoDayAndNightWhere(DayAndNightDefaultSearchViewModel dayAndNightDefaultSearchViewModel)
        {

            var predicate = WhereExtension.True<Student_DayandNight_Info>();//初始化where表达式
                                                                            //姓名
                                                                            //predicate = predicate.And(p => p.addCreatedate.Value.ToString("yyyy-MM-dd").Contains(dayAndNightDefaultSearchViewModel.AddCreateDate.Value.ToString("yyyy-MM-dd")));
                                                                            //predicate = predicate.And(p => p.AddTimeInterval.Contains(dayAndNightDefaultSearchViewModel.AddTimeInterval));
            predicate = predicate.And(p => p.IdNumber.Contains(Dtol.Helper.MD5.Md5Hash(dayAndNightDefaultSearchViewModel.Idnumber)));
            if (dayAndNightDefaultSearchViewModel.addCreatedate.Value.ToString() != null || dayAndNightDefaultSearchViewModel.addCreatedate.Value.ToString() != "")
            {
                predicate = predicate.And(p => p.AddCreateDate.Value.Year == dayAndNightDefaultSearchViewModel.addCreatedate.Value.Year);
                predicate = predicate.And(p => p.AddCreateDate.Value.Month == dayAndNightDefaultSearchViewModel.addCreatedate.Value.Month);
                predicate = predicate.And(p => p.AddCreateDate.Value.Day == dayAndNightDefaultSearchViewModel.addCreatedate.Value.Day);
            }


            predicate = predicate.And(p => p.AddTimeInterval.Contains(dayAndNightDefaultSearchViewModel.AddTimeInterval));
            return predicate;
        }







        public List<TeacherSearchClassMiddle> GetClassByTeacher(int UserKey)
        {
            List<TeacherSearchClassMiddle> teacherSearchClassMiddle = new List<TeacherSearchClassMiddle>();
            var searchResult = DbSet
                .Where(a => a.facultystaff_InfoId == UserKey).Include(a => a.facultystaff_Info).ToList();
            for (int i = 0; i < searchResult.Count(); i++)
            {
                var tempresult = Db.Student_Info.Where(a => a.class_InfoId == searchResult[i].Class_InfoId)
                    .Select(a => new TeacherSearchClassMiddle
                    {
                        TeaacherName = searchResult[i].facultystaff_Info.Name,
                        ClassCode = a.ClassCode,
                        ClassName = a.ClassName,
                        GradeCode = a.GradeCode,
                        GradeName = a.GradeName,
                    }).Distinct().ToList();
                teacherSearchClassMiddle.AddRange(tempresult);
            }
            return teacherSearchClassMiddle.OrderBy(a => a.ClassCode).ToList();
        }
        public Expression<Func<Health_Info, bool>> GetByModelWhere(StaffClassRelateSearchViewModel staffClassRelateSearchView)
        {

            var predicate = WhereExtension.True<Health_Info>();//初始化where表达式
                                                               //姓名
            predicate = predicate.And(p => p.Student_Info.ClassCode.Contains(staffClassRelateSearchView.ClassCode));
            predicate = predicate.And(p => p.Student_Info.GradeCode.Contains(staffClassRelateSearchView.GradeCode));
            predicate = predicate.And(p => p.Name.Contains(staffClassRelateSearchView.Name));
            predicate = predicate.And(p => p.IdNumber.Contains(Dtol.Helper.MD5.Md5Hash(staffClassRelateSearchView.IdNumber)));

            predicate = predicate.And(p => p.IsHot.Contains(staffClassRelateSearchView.IsHot));
            predicate = predicate.And(p => p.IsComeSchool.Contains(staffClassRelateSearchView.isSchool));
            predicate = predicate.And(p => p.Createdate.ToString().Contains(staffClassRelateSearchView.CreateDate == null ? "" : staffClassRelateSearchView.CreateDate.Value.ToString("yyyy-MM-dd")));
            return predicate;
        }

        public Expression<Func<Health_Info, bool>> GetBySchoolModelWhere(StaffSchoolClassRelateSearchViewModel staffClassRelateSearchView)
        {

            var predicate = WhereExtension.True<Health_Info>();//初始化where表达式
                                                               //姓名
            predicate = predicate.And(p => p.Student_Info.SchoolCode.Contains(staffClassRelateSearchView.SchoolCode));
            predicate = predicate.And(p => p.Student_Info.ClassCode.Contains(staffClassRelateSearchView.ClassCode));
            predicate = predicate.And(p => p.Student_Info.GradeCode.Contains(staffClassRelateSearchView.GradeCode));
            predicate = predicate.And(p => p.Name.Contains(staffClassRelateSearchView.Name));
            predicate = predicate.And(p => p.IdNumber.Contains(Dtol.Helper.MD5.Md5Hash(staffClassRelateSearchView.IdNumber)));

            predicate = predicate.And(p => p.IsHot.Contains(staffClassRelateSearchView.IsHot));
            predicate = predicate.And(p => p.IsComeSchool.Contains(staffClassRelateSearchView.isSchool));
            predicate = predicate.And(p => p.Createdate.ToString().Contains(staffClassRelateSearchView.CreateDate == null ? "" : staffClassRelateSearchView.CreateDate.Value.ToString("yyyy-MM-dd")));
            return predicate;
        }


        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }


        public void RemoveByid(List<int> id)
        {

            for (int i = 0; i < id.Count; i++)
            {
                var model = DbSet.Single(w => w.id == id[i]);

                DbSet.Remove(model);
            }

        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Update(ClassManager_Relate obj)
        {
            throw new NotImplementedException();
        }

        public List<TeacherSearchClassAllMiddle> GetClassByTeacherAll(int userKeyId)
        {
            List<TeacherSearchClassAllMiddle> teacherSearchClassAllMiddles = new List<TeacherSearchClassAllMiddle>();
            var searchResult = DbSet
                .Where(a => a.facultystaff_InfoId == userKeyId).Include(a => a.facultystaff_Info).ToList();
            for (int i = 0; i < searchResult.Count(); i++)
            {
                var tempresult = Db.Student_Info.Where(a => a.class_InfoId == searchResult[i].Class_InfoId)
                    .Select(a => new TeacherSearchClassAllMiddle
                    {
                        Id = searchResult[i].id,
                        TeaacherName = searchResult[i].facultystaff_Info.Name,
                        ClassCode = a.ClassCode,
                        ClassName = a.ClassName,
                        GradeCode = a.GradeCode,
                        GradeName = a.GradeName,
                    }).Distinct().ToList();
                teacherSearchClassAllMiddles.AddRange(tempresult);
            }
            return teacherSearchClassAllMiddles;
        }

        public bool isRepeat(AddRelateFromStaffToClassViewModel model)
        {
            var result = DbSet.FirstOrDefault(a => a.ClassCode == model.ClassCode && a.facultystaff_InfoId == model.facultystaff_InfoId
                                                    && a.Class_InfoId == model.Class_InfoId);
            if (result == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        //获取负责班级
        public List<string> GetResponsibleClassByIdnumber(String idnumber)
        {
            List<string> Responsibleclass = new List<string>();
            var searchResult = Db.ClassManager_Relate
                              .Where(a => a.IdNumber == idnumber)
                                  .Include(a => a.Class_Info).ToList();

            for (int i = 0; i < searchResult.Count(); i++)
            {
                Responsibleclass.Add(int.Parse(searchResult[i].Class_Info.ClassCode.Substring(4, 2)).ToString());
            }
            return Responsibleclass;
        }
        //获取负责年级
        public List<string> GetResponsibleGradeByIdnumber(String idnumber)
        {
            List<string> Responsiblegrade = new List<string>();
            var searchResult = Db.ClassManager_Relate
                              .Where(a => a.IdNumber == idnumber)
                                  .Include(a => a.Class_Info).ToList();

            for (int i = 0; i < searchResult.Count(); i++)
            {
                Responsiblegrade.Add(int.Parse(searchResult[i].Class_Info.ClassCode.Substring(2, 2)).ToString());
            }
            return Responsiblegrade;
        }

        public int GetResponsibleClassPeopleNumber(String ClassCode)
        {
            return Db.Student_Info.Where(a => a.ClassCode == ClassCode).Count();
        }
    }
}
