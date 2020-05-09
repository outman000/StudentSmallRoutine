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
    public class ImageRepository : IImageRepository
    {

        protected readonly DtolContext Db;
        protected readonly DbSet<UserFiles_Info> DbSet;

        public ImageRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<UserFiles_Info>();
        }
        public void Add(UserFiles_Info obj)
        {
            DbSet.Add(obj);
        }
    

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserFiles_Info> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserFiles_Info GetById(Guid id)
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

        public void Update(UserFiles_Info obj)
        {
            throw new NotImplementedException();
        }
    }
}
