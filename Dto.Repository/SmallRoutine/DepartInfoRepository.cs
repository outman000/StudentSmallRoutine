using Dto.IRepository.SmallRoutine;
using Dtol;
using Dtol.dtol;
using Dtol.Extension;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.SmallRoutine.ServiceDTO.SmallRoutine;

namespace Dto.Repository.SmallRoutine
{
    public  class DepartInfoRepository: IDepartInfoRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Depart_Info> DbSet;

        public DepartInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Depart_Info>();
        }

        public void Add(Depart_Info obj)
        {
            throw new NotImplementedException();
        }

        public void AddListBase(List<Depart_Info> departInsertList)
        {
            var tempresult = DbSet.ToList();
            var realinsertList = new List<Depart_Info>();
            for (int i = 0; i < departInsertList.Count; i++)
            {
                if (!tempresult.Exists(a => a.DepartCode == departInsertList[i].DepartCode))//如果数据库存在，就不再插入了
                {
                    realinsertList.Add(departInsertList[i]);
                }
            }
            Db.AddRange(realinsertList);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Depart_Info> GetAll()
        {
            throw new NotImplementedException();
        }

        public Depart_Info GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Depart_Info> getdepartInfoBycode(string code)
        {
            //查询条件
            var predicate = WhereExtension.True<Depart_Info>();//初始化where表达式

            predicate = predicate.And(p => p.DepartCode.Substring(0, 2).Equals(code));

            var result = DbSet.Where(predicate).ToList();
            return result;
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Depart_Info obj)
        {
            throw new NotImplementedException();
        }
    }
}
