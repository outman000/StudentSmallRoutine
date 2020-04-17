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

        public List<Health_Info> GetStudentsByStaff(StaffClassRelateSearchViewModel staffClassRelateSearchView)
        {
            int SkipNum = staffClassRelateSearchView.pageViewModel.CurrentPageNum * staffClassRelateSearchView.pageViewModel.PageSize;
            var preciaateStudent = GetByModelWhere(staffClassRelateSearchView);
            List<Student_Info> student_Infos = new List<Student_Info>();
            List<Health_Info> Health_Info = new List<Health_Info>();
            var searchResult = DbSet
                .Where(a => a.facultystaff_InfoId == staffClassRelateSearchView.UserKeyId)
                .Include(a => a.Class_Info).ToList();
            for (int i = 0; i < searchResult.Count();i++)
            {
                var tempresult = Db.Health_Info.Where(a => a.Student_Info.class_InfoId == searchResult[i].Class_InfoId)
                     .Where(preciaateStudent).ToList();
                 Health_Info.AddRange(tempresult);
            }


            return Health_Info.Skip(SkipNum)
                .Take(staffClassRelateSearchView.pageViewModel.PageSize)
                 .OrderByDescending(o => o.Createdate).ToList() ; 
                
        }
        public Expression<Func<Health_Info, bool>> GetByModelWhere(StaffClassRelateSearchViewModel staffClassRelateSearchView)
        {
   
            var predicate = WhereExtension.True<Health_Info>();//初始化where表达式
                                                                     //姓名
            predicate = predicate.And(p => p.Student_Info .ClassCode .Contains(staffClassRelateSearchView.ClassCode));
            predicate = predicate.And(p => p.Student_Info.GradeCode.Contains(staffClassRelateSearchView.GradeCode));
            //predicate = predicate.And(p => p.IsComeSchool .Contains(staffClassRelateSearchView.IsEexception));
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
    }
}
