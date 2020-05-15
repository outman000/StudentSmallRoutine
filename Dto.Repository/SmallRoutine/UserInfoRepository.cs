using Dto.IRepository.SmallRoutine;
using Dtol;
using Dtol.dtol;
using Dtol.Extension;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ViewModel.SmallRoutine.RequestViewModel;

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

    
        public bool Login(LoginViewModel loginViewModel)
        {
            return DbSet.Any(a => a.Idnumber == loginViewModel.Idnumber && a.password == loginViewModel.Password);
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
            DbSet.Update(obj);
        }

        public User_Info GetByIdnumber(string  idnumber)
        {
            var res = new User_Info();
            //查询条件
            var predicate = WhereExtension.True<User_Info>();//初始化where表达式
            Console.WriteLine("aaaaaaaa" + idnumber);
            if (!String.IsNullOrEmpty(idnumber))
            {
                predicate = predicate.And(p => Dtol.Helper.MD5.Decrypt(p.Idnumber).Equals(idnumber));
            }

            var result = DbSet.Where(predicate).ToList();
            if (result.Count > 0)
            {
                res = result.First();
            }
            else
            {
                res = null;
            }

            return res;
        }

        public void AddDefault(string idnumber)
        {
            User_Info user_Info = new User_Info();

            user_Info.Idnumber = idnumber;
            user_Info.password = Dtol.Helper.MD5.Md5Hash("ET2020666");
            user_Info.CreateDate = DateTime.Now;

            this.Add(user_Info);
        }
    }
}
