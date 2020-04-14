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
    public class StationInfoRepository : IStationInfoRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Station_Info> DbSet;

        public StationInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Station_Info>();
        }



        public void Add(Station_Info obj)
        {
            throw new NotImplementedException();
        }

        public void AddListBase(List<Station_Info> stationInsertList)
        {
            var tempresult = DbSet.ToList();
            var realinsertList = new List<Station_Info>();
            for (int i = 0; i < stationInsertList.Count; i++)
            {
                if (!tempresult.Exists(a => a.StaffCode == stationInsertList[i].StaffCode))//如果数据库存在，就不再插入了
                {
                    realinsertList.Add(stationInsertList[i]);
                }
            }
            Db.AddRange(realinsertList);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Station_Info> GetAll()
        {
            throw new NotImplementedException();
        }

        public Station_Info GetById(Guid id)
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

        public void Update(Station_Info obj)
        {
            throw new NotImplementedException();
        }
    }
}
