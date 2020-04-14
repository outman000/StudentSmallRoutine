using Dto.IRepository.SmallRoutine;
using Dtol;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.SmallRoutine.ServiceDTO.SmallRoutine;

namespace Dto.Repository.SmallRoutine
{
    public class SchoolInfoRepository : ISchoolInfoRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<School_Info> DbSet;

        public SchoolInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<School_Info>();
        }


        public void Add(School_Info obj)
        {
            throw new NotImplementedException();
        }

        public void AddList(List<School_Info> school_Infos)
        {
            DbSet.AddRange(school_Infos);
        }

        public void AddListBase(List<School_Info> schoolInsertList)
        {
            var tempresult = DbSet.ToList();

            var realinsertList = new List<School_Info>();
            for (int i = 0; i < schoolInsertList.Count; i++)
            {
                if (!tempresult.Exists(a => a.SchoolCode == schoolInsertList[i].SchoolCode))//如果数据库存在，就不再插入了
                {
                    realinsertList.Add(schoolInsertList[i]);
                }
            }
            Db.AddRange(realinsertList);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<School_Info> GetAll()
        {
            throw new NotImplementedException();
        }

        public School_Info GetById(Guid id)
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

        public void Update(School_Info obj)
        {
            throw new NotImplementedException();
        }
    }
}
