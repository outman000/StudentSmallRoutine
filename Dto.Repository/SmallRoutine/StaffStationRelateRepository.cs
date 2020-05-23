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
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.FacultystaffViewModel;
using ViewModel.SmallRoutine.RequestViewModel.StaffClassRelateViewModel;
using ViewModel.SmallRoutine.RequestViewModel.StaffStationRelateViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.StaffStationRelateViewModel;

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

        public List<StaffStationMiddleModel> GethealthByStaff(StaffStationRelateSearchViewModel  staffStationRelateSearchViewModel)
        {
            int SkipNum = staffStationRelateSearchViewModel.pageViewModel.CurrentPageNum * staffStationRelateSearchViewModel.pageViewModel.PageSize;
            var preciaateStudent = GetByModelWhere(staffStationRelateSearchViewModel);
 
            List<Health_Info> Health_Info = new List<Health_Info>();
            List<StaffStationMiddleModel> staffStationMiddleModel = new List<StaffStationMiddleModel>();
            var searchResult = DbSet
                .Where(a => a.facultystaff_InfoId == staffStationRelateSearchViewModel.UserKeyId)
                .Include(a => a.Station_Info).ToList();

            for (int i = 0; i < searchResult.Count(); i++)
            {
                var tempresult = Db.Health_Info.Where(a => a.facultystaff_Info.station_InfoId == searchResult[i].Station_InfoId)
                     .Where(preciaateStudent)
                      .Select(a => new StaffStationMiddleModel
                      {
                          StaffName = a.facultystaff_Info.StaffName,
                          DepartName = a.facultystaff_Info.DepartName,
                          Name = a.facultystaff_Info.Name,
                          Createdate = a.Createdate,
                          IsComeSchool = a.IsComeSchool,
                          IdNumber = Dtol.Helper.MD5.Decrypt(a.IdNumber),
                          id = a.id,
                          IsFamilyHot = a.IsFamilyHot,
                          IsFamilyThroat = a.IsFamilyThroat,
                          IsFamilyWeakt = a.IsFamilyWeakt,
                          IsHot = a.IsHot,
                          IsThroat = a.IsThroat,
                          IsTouch = a.IsTouch,
                          IsWeak = a.IsWeak,
                          CheckType = a.CheckType,
                          Temperature = a.Temperature,
                          IsAggregate = a.IsAggregate,
                          IsTianJin = a.IsTianJin,
                          IsAggregateContain = a.IsAggregateContain,
                          NotComeSchoolReason = a.NotComeSchoolReason,
                          IsBulu = a.IsBulu

                      })
                     ;
                staffStationMiddleModel.AddRange(tempresult);
            }
            return staffStationMiddleModel.Distinct().OrderByDescending(o => o.Createdate).Skip(SkipNum)
                .Take(staffStationRelateSearchViewModel.pageViewModel.PageSize)
                .ToList();

        }
        public Expression<Func<Health_Info, bool>> GetByModelWhere(StaffStationRelateSearchViewModel  staffStationRelateSearchViewModel)
        {

            var predicate = WhereExtension.True<Health_Info>();//初始化where表达式
                                                               //姓名

            predicate = predicate.And(p => p.facultystaff_Info.DepartCode .Contains(staffStationRelateSearchViewModel.DepartCode));
            predicate = predicate.And(p => p.facultystaff_Info.StaffCode.Contains(staffStationRelateSearchViewModel.StationCode));

            predicate = predicate.And(p => p.Name .Contains( staffStationRelateSearchViewModel.Name));
            predicate = predicate.And(p => p.IdNumber .Contains(Dtol.Helper.MD5.Md5Hash(staffStationRelateSearchViewModel.IdNumber)));

            predicate = predicate.And(p => p.IsHot.Contains(staffStationRelateSearchViewModel.IsHot));
            predicate = predicate.And(p => p.IsComeSchool.Contains(staffStationRelateSearchViewModel.isSchool));
            predicate = predicate.And(p => p.CheckType.Contains(staffStationRelateSearchViewModel.CheckType));
            predicate = predicate.And(p => p.Createdate.ToString().Contains(staffStationRelateSearchViewModel.CreateDate == null ? "" : staffStationRelateSearchViewModel.CreateDate.Value.ToString("yyyy-MM-dd")));
            return predicate;
        }


        public void RemoveByid(List<int> id)
        {

            for (int i = 0; i < id.Count; i++)
            {
                var model = DbSet.Single(w => w.id == id[i]);

                DbSet.Remove(model);
            }

        }

        public List<EmploySearchStationMiddle> GetStationbindByEmploy(int userKeyId)
        {

            List<EmploySearchStationMiddle>   employSearchStationResModels   = new List<EmploySearchStationMiddle>();
            var searchResult = DbSet
                .Where(a => a.facultystaff_InfoId == userKeyId)
                .Include(a => a.facultystaff_Info).ToList();
            for (int i = 0; i < searchResult.Count(); i++)
            {
                var tempresult = Db.facultystaff_Info.Where(a => a.station_InfoId == searchResult[i].Station_InfoId)
                    .Select(a => new EmploySearchStationMiddle
                    {
                         emplyname = searchResult[i].facultystaff_Info.Name,
                         DepartCode = a.DepartCode,
                         DepartName = a.DepartName,
                         StaffCode  = a.StaffCode,
                         StaffName  = a.StaffName,
                    }).Distinct().ToList();
                employSearchStationResModels.AddRange(tempresult);
            }

            return employSearchStationResModels.OrderBy(a => a.StaffCode).ToList();
        }

        public List<EmploySearchStationAllMiddle> GetStationbindByEmployAll(int userKeyId)
        {
            List<EmploySearchStationAllMiddle> employSearchStationAllMiddles = new List<EmploySearchStationAllMiddle>();
            var searchResult = DbSet
                .Where(a => a.facultystaff_InfoId == userKeyId)
                .Include(a => a.facultystaff_Info).ToList();
            for (int i = 0; i < searchResult.Count(); i++)
            {
                var tempresult = Db.facultystaff_Info.Where(a => a.station_InfoId == searchResult[i].Station_InfoId)
                    .Select(a => new EmploySearchStationAllMiddle
                     {
                         Id = searchResult[i].id,
                         emplyname = searchResult[i].facultystaff_Info.Name,
                         DepartCode = a.DepartCode,
                         DepartName = a.DepartName,
                         StaffCode = a.StaffCode,
                         StaffName = a.StaffName,
                     }).Distinct().ToList();
                employSearchStationAllMiddles.AddRange(tempresult);
            }

            return employSearchStationAllMiddles;
        }

        public bool isRepeat(AddRelateFromStaffToStation model)
        {
           var result= DbSet.FirstOrDefault(a => a.StaffCode == model.StaffCode && a.facultystaff_InfoId == model.facultystaff_InfoId
                                                       && a.facultystaff_InfoId==model.facultystaff_InfoId);
            if (result == null)
            {
                return true;
            }
            else
            {
                return false;
            }
          
        }
    }
}
