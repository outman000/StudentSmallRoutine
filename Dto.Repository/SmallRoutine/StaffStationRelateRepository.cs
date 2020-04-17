using Dto.IRepository.SmallRoutine;
using Dtol;
using Dtol.dtol;
using Dtol.Extension;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ViewModel.SmallRoutine.RequestViewModel.StaffClassRelateViewModel;
using ViewModel.SmallRoutine.RequestViewModel.StaffStationRelateViewModel;

namespace Dto.Repository.SmallRoutine
{
    public class StaffStationRelateRepository : IStaffStationRelateRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<StaffStation_Relate> DbSet;

        public StaffStationRelateRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<StaffStation_Relate>();
        }
        public void Add(StaffStation_Relate obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<StaffStation_Relate> GetAll()
        {
            throw new NotImplementedException();
        }

        public StaffStation_Relate GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return  Db.SaveChanges();
        }

        public void Update(StaffStation_Relate obj)
        {
            throw new NotImplementedException();
        }

        public List<Health_Info> GethealthByStaff(StaffStationRelateSearchViewModel  staffStationRelateSearchViewModel)
        {
            int SkipNum = staffStationRelateSearchViewModel.pageViewModel.CurrentPageNum * staffStationRelateSearchViewModel.pageViewModel.PageSize;
            var preciaateStudent = GetByModelWhere(staffStationRelateSearchViewModel);
 
            List<Health_Info> Health_Info = new List<Health_Info>();
            var searchResult = DbSet
                .Where(a => a.facultystaff_InfoId == staffStationRelateSearchViewModel.UserKeyId)
                .Include(a => a.Station_InfoId).ToList();
            for (int i = 0; i < searchResult.Count(); i++)
            {
                var tempresult = Db.Health_Info.Where(a => a.facultystaff_Info.station_InfoId == searchResult[i].Station_InfoId)
                     .Where(preciaateStudent).ToList();
                Health_Info.AddRange(tempresult);
            }
            return Health_Info.Skip(SkipNum)
                .Take(staffStationRelateSearchViewModel.pageViewModel.PageSize)
                 .OrderByDescending(o => o.Createdate).ToList();

        }
        public Expression<Func<Health_Info, bool>> GetByModelWhere(StaffStationRelateSearchViewModel  staffStationRelateSearchViewModel)
        {

            var predicate = WhereExtension.True<Health_Info>();//初始化where表达式
                                                               //姓名

            predicate = predicate.And(p => p.facultystaff_Info.DepartCode .Contains(staffStationRelateSearchViewModel.DepartCode));
            predicate = predicate.And(p => p.facultystaff_Info.StaffCode.Contains(staffStationRelateSearchViewModel.StationCode));
          // predicate = predicate.And(p => p.IsComeSchool.Contains(staffStationRelateSearchViewModel.IsEexception));
            predicate = predicate.And(p => p.IsComeSchool.Contains(staffStationRelateSearchViewModel.isSchool));
            predicate = predicate.And(p => p.Createdate.ToString().Contains(staffStationRelateSearchViewModel.CreateDate == null ? "" : staffStationRelateSearchViewModel.CreateDate.Value.ToString("yyyy-MM-dd")));
            return predicate;
        }




    }
}
