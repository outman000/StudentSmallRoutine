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
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.Repository.SmallRoutine
{
    public class StaffRepository : IStaffRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Station_Info> DbSet;

        public StaffRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Station_Info>();
        }


        public void Add(Station_Info obj)
        {
            Db.Add(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Station_Info> GetAll()
        {
            throw new NotImplementedException();
        }

        public Station_Info GetById(Guid id)
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

        public void Update(Station_Info obj)
        {
            DbSet.Update(obj);
        }


        public List<Station_Info> getStaffInfoBycode(string code)
        {
            //查询条件
            var predicate = WhereExtension.True<Station_Info>();//初始化where表达式

            predicate = predicate.And(p => p.StaffCode.Substring(0, 4).Equals(code));

            var result = DbSet.Where(predicate).ToList();
            return result;
        }

        public int DeleteByRoleIdList(List<int> deleleIdList)
        {
            for (int i = 0; i < deleleIdList.Count; i++)
            {

               var deletemodel=  DbSet.FirstOrDefault(a => a.id == deleleIdList[i]);

                DbSet.Remove(deletemodel);
            
            }
            return Db.SaveChanges();
        }

        public Station_Info GetInfoByRoleid(int id)
        {
           return DbSet.FirstOrDefault(a => a.id == id);
           
        }

        public List<Station_Info> SearchRoleInfoByWhere(UserRoleSearchViewModel userRoleSearchViewModel)
        {
            int SkipNum = userRoleSearchViewModel.pageViewModel.CurrentPageNum * userRoleSearchViewModel.pageViewModel.PageSize;

            var preciate = SearchRoleWhere(userRoleSearchViewModel);
            return DbSet.Where(preciate).Skip(SkipNum)
                .Take(userRoleSearchViewModel.pageViewModel.PageSize).ToList();
                
        }

        private Expression<Func<Station_Info, bool>> SearchRoleWhere(UserRoleSearchViewModel userRoleSearchViewModel)
        {
            var predicate = WhereExtension.True<Station_Info>();//初始化where表达式
            predicate = predicate.And(p => p.StaffCode.Contains(userRoleSearchViewModel.StaffCode));
            predicate = predicate.And(p => p.StaffName.Contains(userRoleSearchViewModel.StaffName));
          //  predicate = predicate.And(p => p.Createdate.ToString().Contains(healthEverySearchViewModel.Createdate == null ? "" : healthEverySearchViewModel.Createdate.Value.ToString("yyyy-MM-dd")));
            // predicate = predicate.And(p => p.Id==lineSearchViewModel.Id);

            return predicate;
        }

    }
}
