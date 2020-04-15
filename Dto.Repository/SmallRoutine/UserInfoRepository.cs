using Dto.IRepository.SmallRoutine;
using Dtol;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public void AddListBase(List<User_Info> insertUserInfoList)
        {
            var tempresult = DbSet.ToList();
            var realinsertList = new List<User_Info>();
            for (int i = 0; i < insertUserInfoList.Count; i++)
            {
                if (!tempresult.Exists(a => a.Idnumber == insertUserInfoList[i].Idnumber))//如果数据库存在，就不再插入了
                {
             
                    insertUserInfoList[i].password = Dtol.Helper.MD5.Md5Hash("ET2020666");
                    realinsertList.Add(insertUserInfoList[i]);
                }
            }
            DbSet.AddRange(realinsertList);
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<User_Info> GetAll()
        {
            return DbSet;
        }

        public User_Info GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Login()
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

        public void Update(User_Info obj)
        {
            throw new NotImplementedException();
        }
    }
}
