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
using ViewModel.SmallRoutine.RequestViewModel.ExceptEmployViewModel;

namespace Dto.Repository.SmallRoutine
{
    public class ExceptEmployRepository : IExceptEmployRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Except_Info_Employ> DbSet;

        public ExceptEmployRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Except_Info_Employ>();
        }


        public void Add(Except_Info_Employ obj)
        {
            DbSet.Add(obj);
        }

        public void deleteByList(List<int> deleteList)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Except_Info_Employ> GetAll()
        {
            throw new NotImplementedException();
        }

        public Except_Info_Employ GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return  Db.SaveChanges();
        }

        public List<Except_Info_Employ> searchEmployinfo(ExceptEmploySearchViewModel exceptEmploySearchViewModel)
        {
            var preciate = GetByModelWhere(exceptEmploySearchViewModel);
            List<Except_Info_Employ> Except_Info_Employs = new List<Except_Info_Employ>();
            if (exceptEmploySearchViewModel.RoleID == "sys")
            {
                var tempresult = DbSet.Where(preciate).Include(a => a.facultystaff_Info).Include(m => m.UserFiles_Info).ToList();
                Except_Info_Employs.AddRange(tempresult);

            }
            else
            {
                //先找到这个人所负责的所有班级
                var searchResult = Db.StaffStation_Relate
                .Where(a => a.facultystaff_InfoId == exceptEmploySearchViewModel.userKey)
                .Include(a => a.Station_Info).ToList();


                for (int i = 0; i < searchResult.Count(); i++)//通过班级code查询
                {

                    var tempresult = DbSet.Where(a => a.facultystaff_Info.StaffCode == searchResult[i].Station_Info.StaffCode)
                        .Where(preciate).Include(a => a.facultystaff_Info).Include(m => m.UserFiles_Info).ToList();
                    Except_Info_Employs.AddRange(tempresult);
                }
            }
            return Except_Info_Employs.OrderByDescending(a => a.CreateDate).ToList();
        }

        public Expression<Func<Except_Info_Employ, bool>> GetByModelWhere(ExceptEmploySearchViewModel exceptEmploySearchViewModel)
        {
            var predicate = WhereExtension.True<Except_Info_Employ>();//初始化where表达式SchoolName
                                                                       //姓          
            predicate = predicate.And(p => p.facultystaff_Info.SchoolCode.Contains(exceptEmploySearchViewModel.SchoolCode));
            predicate = predicate.And(p => p.facultystaff_Info.DepartCode.Contains(exceptEmploySearchViewModel.DepartCode));
            predicate = predicate.And(p => p.facultystaff_Info.StaffCode.Contains(exceptEmploySearchViewModel.StaffCode));
            predicate = predicate.And(p => p.CreateDate.ToString().Contains(exceptEmploySearchViewModel.CreateDate));
            predicate = predicate.And(p => p.Name.Contains(exceptEmploySearchViewModel.Name));
            predicate = predicate.And(p => p.Temperature.Contains(exceptEmploySearchViewModel.Temperature));
            return predicate;
        }




        public void Update(Except_Info_Employ obj)
        {
            DbSet.Update(obj);
        }
    }
}
