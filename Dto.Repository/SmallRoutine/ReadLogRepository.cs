using Dtol;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Dtol.Extension;
using Dto.IRepository.SmallRoutine;

namespace Dto.Repository.SmallRoutine
{
    public class ReadLogRepository: IReadLogRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<ReadLog> DbSet;

        public ReadLogRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<ReadLog>();
        }
        public virtual void Add(ReadLog obj)
        {
            DbSet.Add(obj);
        }

        public virtual ReadLog GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual void Update(ReadLog obj)
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

        public IQueryable<ReadLog> GetAll()
        {
            throw new NotImplementedException();
        }

        //获取用户阅读政策记录
        public ReadLog GetReadLog(string openid)
        {
            ReadLog log = new ReadLog();
            //查询条件
            var predicate = WhereExtension.True<ReadLog>();//初始化where表达式
      
            if (!String.IsNullOrEmpty(openid))
            {
                predicate = predicate.And(p => p.openid.Contains(openid));
            }
            var result = DbSet.Where(predicate).ToList();
            if (result.Count != 0)
            {
                log = result.First();
            }
            else
            {
                log = null;
            }
            return log;
        }
    }
}
