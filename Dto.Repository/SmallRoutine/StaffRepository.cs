using Dto.IRepository.SmallRoutine;
using Dtol;
using Dtol.dtol;
using Dtol.Extension;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Update(Station_Info obj)
        {
            throw new NotImplementedException();
        }


        public List<Station_Info> getStaffInfoBycode(string code)
        {
            //查询条件
            var predicate = WhereExtension.True<Station_Info>();//初始化where表达式

            predicate = predicate.And(p => p.StaffCode.Substring(0, 4).Equals(code));

            var result = DbSet.Where(predicate).ToList();
            return result;
        }
    }
}
