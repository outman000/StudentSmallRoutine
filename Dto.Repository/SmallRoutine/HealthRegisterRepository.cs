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
using ViewModel.SmallRoutine.RequestViewModel.HealthViewModel;

namespace Dto.Repository.SmallRoutine
{
    public class HealthRegisterRepository : IHealthRegisterRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<StudentRegisterHeath_Info> DbSet;

        public HealthRegisterRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<StudentRegisterHeath_Info>();
        }

        public void Add(StudentRegisterHeath_Info obj)
        {
            DbSet.Add(obj);
        }

        public void DelByList(List<int> deleteList)
        {
            for (int i = 0; i < deleteList.Count; i++)
            {
                var model = DbSet.Single(w => w.id == deleteList[i]);
                
                DbSet.Remove(model);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<StudentRegisterHeath_Info> GetAll()
        {
            throw new NotImplementedException();
        }

        public StudentRegisterHeath_Info GetById(int id)
        {
            return DbSet.FirstOrDefault(a => a.id == id);
        }

        public StudentRegisterHeath_Info GetById(Guid id)
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

        public List<StudentRegisterHeath_Info> searchHealthInfo(HealthInfoSearchViewModel healthInfoSearchViewModel)
        {
            int SkipNum = healthInfoSearchViewModel.pageViewModel.CurrentPageNum * healthInfoSearchViewModel.pageViewModel.PageSize;
            var preciate = SearchLineWhere(healthInfoSearchViewModel);
            return DbSet.Where(preciate)
                 .Skip(SkipNum)
                .Take(healthInfoSearchViewModel.pageViewModel.PageSize)
                 .OrderByDescending(o => o.CreateDate).ToList();
                

        }
    
        private Expression<Func<StudentRegisterHeath_Info, bool>> SearchLineWhere(HealthInfoSearchViewModel  healthInfoSearchViewModel)
        {
            var aa = DateTime.Now;

            var aaaaaaa = aa.ToString();

         
            var predicate = WhereExtension.True<StudentRegisterHeath_Info>();//初始化where表达式

          
            predicate = predicate.And(p => p.Idnumber.Trim().Contains(healthInfoSearchViewModel.Idnumber.Trim()==""?"":Dtol.Helper.MD5.Md5Hash(healthInfoSearchViewModel.Idnumber.Trim())));
            
           
            predicate = predicate.And(p => p.IsleaveJin.Contains(healthInfoSearchViewModel.IsleaveJin));
            predicate = predicate.And(p => p.IsPassHubei.Contains(healthInfoSearchViewModel.IsPassHubei));
            predicate = predicate.And(p => p.PassHubeiDetail.Contains(healthInfoSearchViewModel.IsPassHubei));
            predicate = predicate.And(p => p.Peers.Contains(healthInfoSearchViewModel.IsPassHubei));
            predicate = predicate.And(p => p.PeersTelephone.Contains(healthInfoSearchViewModel.IsPassHubei));
            predicate = predicate.And(p => p.Residencetemporary.Contains(healthInfoSearchViewModel.IsPassHubei));
            predicate = predicate.And(p => p.Telephone.Contains(healthInfoSearchViewModel.Telephone));
            predicate = predicate.And(p => p.Temperature.Contains(healthInfoSearchViewModel.Temperature));
            predicate = predicate.And(p => p.Traffic.Contains(healthInfoSearchViewModel.Traffic));
            predicate = predicate.And(p => p.BackJinDate.ToString().Contains(healthInfoSearchViewModel.BackJinDate==null? "": healthInfoSearchViewModel.BackJinDate.Value.ToString("yyyy-MM-dd")));
            predicate = predicate.And(p => p.BeforeTianjin.Contains(healthInfoSearchViewModel.Traffic));
            predicate = predicate.And(p => p.Guardian.Contains(healthInfoSearchViewModel.Guardian));
            predicate = predicate.And(p => p.Destination.Contains(healthInfoSearchViewModel.Destination));
            predicate = predicate.And(p => p.ForteenDaysExcepting.Contains(healthInfoSearchViewModel.ForteenDaysExcepting));
            predicate = predicate.And(p => p.CreateDate.ToString().Contains(healthInfoSearchViewModel.CreateDate == null ? "" : healthInfoSearchViewModel.CreateDate.Value.ToString("yyyy-MM-dd")));



            // predicate = predicate.And(p => p.Id==lineSearchViewModel.Id);

            return predicate;
        }





        public void Update(StudentRegisterHeath_Info obj)
        {
            DbSet.Update(obj);
        }
    }
}
