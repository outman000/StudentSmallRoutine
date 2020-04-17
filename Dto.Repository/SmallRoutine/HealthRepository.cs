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
using ViewModel.SmallRoutine.RequestViewModel.HealthEveryViewModel;

namespace Dto.Repository.SmallRoutine
{
    public  class HealthRepository : IHealthRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<Health_Info> DbSet;

        public HealthRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<Health_Info>();
        }

        public void Add(Health_Info obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Health_Info> GetAll()
        {
            throw new NotImplementedException();
        }

        public Health_Info GetById(Guid id)
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

        public void Update(Health_Info obj)
        {
            DbSet.Update(obj);
        }

        public void DelByList(List<int> deleteList)
        {
            for (int i = 0; i < deleteList.Count; i++)
            {
                var model = DbSet.Single(w => w.id == deleteList[i]);

                DbSet.Remove(model);
            }
        }

        public List<Health_Info> SearchHealthEveryRegisterInfo(HealthEverySearchViewModel healthEverySearchViewModel)
        {

            int SkipNum = healthEverySearchViewModel.pageViewModel.CurrentPageNum * healthEverySearchViewModel.pageViewModel.PageSize;
            var preciate = SearchLineWhere(healthEverySearchViewModel);
            return DbSet.Where(preciate)
                 .Skip(SkipNum)
                .Take(healthEverySearchViewModel.pageViewModel.PageSize)
                 .OrderByDescending(o => o.Createdate).ToList();

        }



        private Expression<Func<Health_Info, bool>> SearchLineWhere(HealthEverySearchViewModel healthEverySearchViewModel)
        {

            var aaaaa = healthEverySearchViewModel.Createdate.Value.ToString("yyyy-MM-dd");

            var predicate = WhereExtension.True<Health_Info>();//初始化where表达式
            predicate = predicate.And(p => p.IdNumber.Trim().Contains(healthEverySearchViewModel.IdNumber.Trim() == "" ? "" : Dtol.Helper.MD5.Md5Hash(healthEverySearchViewModel.IdNumber.Trim())));
            predicate = predicate.And(p => p.IsFamilyHot.Contains(healthEverySearchViewModel.IsFamilyHot));
            predicate = predicate.And(p => p.IsFamilyThroat.Contains(healthEverySearchViewModel.IsFamilyThroat));
            predicate = predicate.And(p => p.IsFamilyWeakt.Contains(healthEverySearchViewModel.IsFamilyWeakt));
            predicate = predicate.And(p => p.IsHot.Contains(healthEverySearchViewModel.IsHot));
            predicate = predicate.And(p => p.IsThroat.Contains(healthEverySearchViewModel.IsThroat));
            predicate = predicate.And(p => p.IsWeak.Contains(healthEverySearchViewModel.IsWeak));
            predicate = predicate.And(p => p.IsComeSchool .Contains(healthEverySearchViewModel.IsComeSchool));
            predicate = predicate.And(p => p.IsTouch.Contains(healthEverySearchViewModel.IsTouch));
            predicate = predicate.And(p => p.Name.Contains(healthEverySearchViewModel.Name));
            predicate = predicate.And(p => p.Createdate.ToString().Contains(healthEverySearchViewModel.Createdate == null ? "" : healthEverySearchViewModel.Createdate.Value.ToString("yyyy-MM-dd")));
            // predicate = predicate.And(p => p.Id==lineSearchViewModel.Id);

            return predicate;
        }

        public Health_Info getByidNumber(string idNumber)
        {
            return DbSet.FirstOrDefault(a => a.IdNumber == idNumber);
        }
    }
}
