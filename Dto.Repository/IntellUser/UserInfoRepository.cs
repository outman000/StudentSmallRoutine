
using Dtol;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dto.IRepository.IntellUser;
using ViewModel.UserViewModel.RequsetModel;
using System.Linq.Expressions;
using ViewModel.UserViewModel.MiddleModel;
using Dtol.Extension;

namespace Dto.Repository.IntellUser
{
    public class UserInfoRepository : IUserInfoRepository
    {
        protected readonly DtolContext Db;
        protected readonly DbSet<User_System> DbSet;

        public UserInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<User_System>();
        }

        public virtual void Add(User_System obj)
        {
            DbSet.Add(obj);
        }

        public virtual User_System GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public  IQueryable<User_System> GetUserAll(UserSearchViewModel userSearchViewModel)
        {
            var predicate = SearchUserWhere(userSearchViewModel);

            return DbSet.Where(predicate);
        }

        public virtual void Update(User_System obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int DeleteByUseridList(List<int> IdList)
        {
            int DeleteRowNum = 1;
            for (int i = 0; i < IdList.Count; i++)
            {
               var model= DbSet.Single(w => w.Id == IdList[i]);
               // model.status = "1";
                DbSet.Update(model);
                SaveChanges();
                DeleteRowNum = i+1;
            }
            return DeleteRowNum;
        

        }


        public IQueryable<User_System> GetInfoByUserid(string userid)
        {
            IQueryable<User_System> User_Systems = DbSet.Where(uid => uid.UserId.Equals(userid));
            return User_Systems;
        }
        //根据用户主键id查询
        public User_System GetInfoByUserid(int id)
        {
            User_System User_System = DbSet.Single(uid => uid.Id.Equals(id));
            return User_System;
        }

        //根据条件查询

        public List<User_System> SearchInfoByWhere(UserSearchViewModel userSearchViewModel)
        {
            int SkipNum = userSearchViewModel.pageViewModel.CurrentPageNum * userSearchViewModel.pageViewModel.PageSize;

            //查询条件
            var predicate = SearchUserWhere(userSearchViewModel);
           
            var result= DbSet.Where(predicate)
                .Skip(SkipNum)
                .Take(userSearchViewModel.pageViewModel.PageSize)
                .OrderBy(o => o.AddDate).ToList();
            

            return result;
        }


        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        #region 查询条件
        //根据条件查询用户
        private Expression<Func<User_System, bool>> SearchUserWhere(UserSearchViewModel userSearchViewModel)
        {
            var predicate = WhereExtension.True<User_System>();//初始化where表达式
                predicate = predicate.And(p => p.UserId.Contains(userSearchViewModel.UserId));
                //predicate = predicate.And(p => p.UserName.Contains(userSearchViewModel.UserName));
                //predicate = predicate.And(p => p.Levels.Contains(userSearchViewModel.Levels));
                //predicate = predicate.And(p => p.status.Contains(userSearchViewModel.status));
                //predicate = predicate.And(p => p.User_DepartId== userSearchViewModel.User_DepartId);
            return predicate;
        }

        public IQueryable<User_System> GetAll()
        {
            throw new NotImplementedException();
        }

        //public User_System GetInfoAndDepartByUserid(int id)
        //{
        //    User_System User_System = DbSet.Include(a=>a.User_Depart)
        //                         .Single(uid => uid.Id.Equals(id))       
        //        ;
        //    return User_System;
        //}
        /// <summary>
        /// 根据部门查用户
        /// </summary>
        /// <param name="userByDepartSearchViewModel"></param>
        /// <returns></returns>
        //public List<User_System> SearchUserInfoByDepartWhere(UserByDepartSearchViewModel userByDepartSearchViewModel)
        //{
        //    int SkipNum = userByDepartSearchViewModel.pageViewModel.CurrentPageNum * userByDepartSearchViewModel.pageViewModel.PageSize;
        //    int lineid = userByDepartSearchViewModel.User_DepartId;
        //    var queryResult = DbSet.Where(k => k.User_DepartId == lineid && k.status == "0")
        //             .Skip(SkipNum)
        //             .Take(userByDepartSearchViewModel.pageViewModel.PageSize)
        //             .ToList();
        //    return queryResult;
        //}
        /// <summary>
        /// 根据部门查用户用户
        /// </summary>
        /// <param name="userByDepartSearchViewModel"></param>
        /// <returns></returns>
        //public IQueryable<User_System> GetUserByDepartAll(UserByDepartSearchViewModel userByDepartSearchViewModel)
        //{
        //    int departId = userByDepartSearchViewModel.User_DepartId;
        //    var queryResult = DbSet.Where(k => k.User_DepartId == departId && k.status == "0");
        //    return queryResult;
        //}


        #endregion


    }
}
