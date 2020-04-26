using Dto.IRepository.SmallRoutine;
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
            List<Student_Info> student_Infos = new List<Student_Info>();
            List<Health_Info> Health_Info = new List<Health_Info>();
            List<StaffClassMiddleModel> staffClassMiddleModel = new List<StaffClassMiddleModel>();
            var searchResult = DbSet
                .Where(a => a.facultystaff_InfoId == staffClassRelateSearchView.UserKeyId)
                .Include(a => a.Class_Info).ToList();
            for (int i = 0; i < searchResult.Count(); i++)
            {
                var tempresult = Db.Health_Info.Where(a => a.Student_Info.class_InfoId == searchResult[i].Class_InfoId)
                     .Where(preciaateStudent)
                     .Select(a=> new StaffClassMiddleModel
                     { 
                        ClassName= a.Student_Info.ClassName,
                        GradeName=a.Student_Info.GradeName,
                        Name=a.Student_Info.Name,
                        Createdate=a.Createdate,
                        IsComeSchool=a.IsComeSchool,
                        IdNumber= Dtol.Helper.MD5.Decrypt(a.IdNumber),
                        id =a.id,
                        IsFamilyHot=a.IsFamilyHot,
                        IsFamilyThroat=a.IsFamilyThroat,
                        IsFamilyWeakt=a.IsFamilyWeakt,
                        IsHot=a.IsHot,
                        IsThroat=a.IsThroat,
                        IsTouch=a.IsTouch,
                        IsWeak=a.IsWeak
                     })
                     
                     .ToList();
                staffClassMiddleModel.AddRange(tempresult);
            }


            return staffClassMiddleModel.Skip(SkipNum)
                .Take(staffClassRelateSearchView.pageViewModel.PageSize)
                 .OrderByDescending(o => o.Createdate).ToList();

        }




        public List<TeacherSearchClassMiddle> GetClassByTeacher(int UserKey)
        {
            List<TeacherSearchClassMiddle> teacherSearchClassMiddle = new List<TeacherSearchClassMiddle>();
            var searchResult = DbSet
                .Where(a => a.facultystaff_InfoId == UserKey).Include(a=>a.facultystaff_Info).ToList();
            for (int i = 0; i < searchResult.Count();i++)
            {
                var tempresult = Db.Student_Info.Where(a => a.class_InfoId == searchResult[i].Class_InfoId)
                    .Select(a => new TeacherSearchClassMiddle
                    {
                        TeaacherName= searchResult[i].facultystaff_Info.Name,
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
            predicate = predicate.And(p => p.Student_Info .ClassCode .Contains(staffClassRelateSearchView.ClassCode));
            predicate = predicate.And(p => p.Student_Info.GradeCode.Contains(staffClassRelateSearchView.GradeCode));
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
                        Id= searchResult[i].id,
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
    }
}
