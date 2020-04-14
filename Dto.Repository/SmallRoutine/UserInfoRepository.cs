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
    public class UserInfoRepository : IUserInfoRepository
    {

        protected readonly DtolContext Db;
        protected readonly DbSet<User_Info> DbSet;

        public UserInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<User_Info>();
        }


        public void Add(User_Info obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<User_Info> GetAll()
        {
            throw new NotImplementedException();
        }

        public User_Info GetById(Guid id)
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

        public void Update(User_Info obj)
        {
            throw new NotImplementedException();
        }
    }
}
