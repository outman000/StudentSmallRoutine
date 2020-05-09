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
using ViewModel.SmallRoutine.RequestViewModel.ExceptStudentViewModel;

namespace Dto.Repository.SmallRoutine
{
    public class ExceptStudentRepository : IExceptStudentRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Except_Info_Student> DbSet;

        public ExceptStudentRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Except_Info_Student>();
        }
        public void Add(Except_Info_Student obj)
        {
            DbSet.Add(obj);
        }

        public void deletebyList(List<int> deleteList)
        {
            for (int i = 0; i < deleteList.Count; i++)
            {
              var deletemodel=  DbSet.FirstOrDefault(a => a.Id == deleteList[i]);

                DbSet.Remove(deletemodel);

            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Except_Info_Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public Except_Info_Student GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public List<Except_Info_Student> searchByemploytoclass(ExceptStudengSearchInfoVIewModel exceptStudentSearchInfoVIewModel)
        {
            var preciate = GetByModelWhere(exceptStudentSearchInfoVIewModel);
            //先找到这个人所负责的所有班级
            var searchResult = Db.ClassManager_Relate
            .Where(a => a.facultystaff_InfoId == exceptStudentSearchInfoVIewModel.userKey)
            .Include(a => a.Class_Info).ToList();


            List<Except_Info_Student > Except_Info_Students = new List<Except_Info_Student>();
            for (int i = 0; i < searchResult.Count(); i++)//通过班级code查询
            {
         
                var tempresult = DbSet.Where(a=>a.student_Info.ClassCode== searchResult[i].Class_Info.ClassCode)
                    .Where(preciate).Include(a=>a.student_Info).Include(m=>m.UserFiles_Info).ToList();
                Except_Info_Students.AddRange(tempresult);
            }
            return Except_Info_Students.OrderByDescending(a=>a.CreateDate).ToList();
        }
        public Expression<Func<Except_Info_Student, bool>> GetByModelWhere(ExceptStudengSearchInfoVIewModel  exceptStudengSearchInfoVIewModel)
        {
            var predicate = WhereExtension.True<Except_Info_Student>();//初始化where表达式SchoolName
                                                                       //姓          
            predicate = predicate.And(p => p.student_Info.SchoolCode.Contains(exceptStudengSearchInfoVIewModel.SchoolCode));
            predicate = predicate.And(p => p.student_Info.ClassCode.Contains(exceptStudengSearchInfoVIewModel.ClassCode));
            predicate = predicate.And(p => p.student_Info.GradeCode.Contains(exceptStudengSearchInfoVIewModel.GradeCode));
            predicate = predicate.And(p => p.CreateDate.ToString().Contains(exceptStudengSearchInfoVIewModel.CreateDate));
            predicate = predicate.And(p => p.Name.Contains(exceptStudengSearchInfoVIewModel.Name));
            predicate = predicate.And(p => p.Temperature.Contains(exceptStudengSearchInfoVIewModel.Temperature));
            return predicate;
        }


        public void Update(Except_Info_Student obj)
        {
            DbSet.Update(obj);
        }
    }
}
