using Dto.IRepository.SmallRoutine;
using Dtol;
using Dtol.dtol;
using Dtol.Extension;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.ServiceDTO.SmallRoutine;

namespace Dto.Repository.SmallRoutine
{
    public class GradeInfoRepository : IGradeInfoRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Grade_Info> DbSet;

        public GradeInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Grade_Info>();
        }



        public void Add(Grade_Info obj)
        {
            throw new NotImplementedException();
        }

        public void AddList(List<Grade_Info> grade_Infos)
        {
            DbSet.AddRange(grade_Infos);
        }

        public void AddListBase(List<Grade_Info> gradeInsertList)
        {
            var tempresult = DbSet.ToList();
            var realinsertList = new List<Grade_Info>();
            for (int i = 0; i < gradeInsertList.Count; i++)
            {
                if (!tempresult.Exists(a => a.GradeCode == gradeInsertList[i].GradeCode))//如果数据库存在，就不再插入了
                {
                    realinsertList.Add(gradeInsertList[i]);
                }
            }
            Db.AddRange(realinsertList);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Grade_Info> GetAll()
        {
            throw new NotImplementedException();
        }

        public Grade_Info GetById(Guid id)
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

        public void Update(Grade_Info obj)
        {
            throw new NotImplementedException();
        }

        //验证是否年级信息是否存在
        public bool CheckInfo(string code, string name)
        {
            //查询条件
            var predicate = WhereExtension.True<Grade_Info>();//初始化where表达式
           
            predicate = predicate.And(p => p.GradeCode.Equals(code));
            predicate = predicate.And(p => p.GradeName.Equals(name));

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

        //验证是否学校信息是否存在
        public List<Grade_Info> getclassInfoBycode(string code)
        {
            //查询条件
            var predicate = WhereExtension.True<Grade_Info>();//初始化where表达式

            predicate = predicate.And(p =>p.GradeCode.Substring(0,2).Equals(code));

            var result = DbSet.Where(predicate).OrderBy(a=>a.GradeCode).ToList();
            return result;
        }

    }
}
