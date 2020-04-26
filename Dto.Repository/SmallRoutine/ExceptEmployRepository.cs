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

        public void Update(Except_Info_Employ obj)
        {
            DbSet.Update(obj);
        }
    }
}
