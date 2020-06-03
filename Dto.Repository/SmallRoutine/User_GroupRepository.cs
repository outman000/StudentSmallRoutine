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
    public class User_GroupRepository : IUser_GroupRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<User_Group> DbSet;

        public User_GroupRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<User_Group>();
        }

        public virtual void Add(User_Group obj)
        {
            DbSet.Add(obj);
        }

        public virtual User_Group GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<User_Group> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(User_Group obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public List<User_Group> GetUser_GroupsByStationName(string stationName)
        {
            return DbSet.Where(info => info.StationNames.Contains(stationName)).ToList();
        }
    }
}
