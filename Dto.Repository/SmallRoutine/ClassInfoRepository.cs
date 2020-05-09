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
    public class ClassInfoRepository : IClassInfoRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Class_Info> DbSet;

        public ClassInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Class_Info>();
        }



        public void Add(Class_Info obj)
        {
            throw new NotImplementedException();
        }

        public void AddList(List<Class_Info> class_Infos)
        {
            Db.AddRange(class_Infos);
        }

        public void AddListBase(List<Class_Info> classInsertList)
        {
            var tempresult = DbSet.ToList();
            var realinsertList = new List<Class_Info>();


            for (int i=0;i< classInsertList.Count;i++)
            {
                if (!tempresult.Exists(a => a.ClassCode == classInsertList[i].ClassCode))//如果数据库存在，就不再插入了
                {
                    realinsertList.Add(classInsertList[i]);
                }
            }
            Db.AddRange(realinsertList);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Class_Info> GetAll()
        {
            throw new NotImplementedException();
        }

        public Class_Info GetById(Guid id)
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

        public void Update(Class_Info obj)
        {
            throw new NotImplementedException();
        }

        //验证是否学校信息是否存在
        public bool CheckInfo(string code, string name)
        {
            //查询条件
            var predicate = WhereExtension.True<Class_Info>();//初始化where表达式

            predicate = predicate.And(p => p.ClassCode.Equals(code));
            predicate = predicate.And(p => p.ClassName.Equals(name));

            var result = DbSet.Where(predicate).ToList();
            if (result.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //根据code查找学校
        public List<Class_Info> getclassInfoBycode(string code)
        {
            //查询条件
            var predicate = WhereExtension.True<Class_Info>();//初始化where表达式

            predicate = predicate.And(p => p.ClassCode.Substring(0,4).Equals(code));

            var result = DbSet.Where(predicate).ToList();
            return result;
        }




      


    }
}
