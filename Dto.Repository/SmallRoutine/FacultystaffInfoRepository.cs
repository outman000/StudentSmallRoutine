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
using ViewModel.SmallRoutine.RequestViewModel;
using ViewModel.SmallRoutine.RequestViewModel.BaseControlViewModel;
using ViewModel.SmallRoutine.ServiceDTO.SmallRoutine;

namespace Dto.Repository.SmallRoutine
{
    public class FacultystaffInfoRepository : IFacultystaffInfoRepository
    {

        protected readonly DtolContext Db;
        protected readonly DbSet<facultystaff_Info> DbSet;

        public FacultystaffInfoRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<facultystaff_Info>();
        }



        public void Add(facultystaff_Info obj)
        {
            DbSet.Add(obj);
        }


        public void AddList(List<facultystaff_Info> facultystaff_Infos)
        {
            DbSet.AddRange(facultystaff_Infos);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<facultystaff_Info> GetAll()
        {
            return DbSet;
        }

        public facultystaff_Info GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<DepartInfoServiceDTO> GetDepartList()
        {
            return Db.facultystaff_Info.Select(a => new DepartInfoServiceDTO
            {
                 DepartCode=a.DepartCode,
                DepartName=a.DepartName 

            }).Distinct().ToList();
        }

        public List<StationInfoServiceDTO> GetStationlList()
        {
            return Db.facultystaff_Info.Select(a => new StationInfoServiceDTO
            {
                 StaffCode=a.StaffCode,
                 StaffName = a.StaffName

            }).Distinct().ToList();
        }

        public facultystaff_Info GetStudentInfoAndHealthInfo(string Idnumber)
        {
            return DbSet.Where(a => a.IdNumber == Idnumber).Include(a => a.StudentRegisterHeath_Info).FirstOrDefault();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Update(facultystaff_Info obj)
        {
            DbSet.Update(obj);
        }


        //根据id获取教职工信息
        public facultystaff_Info getbyID(int id)
        {
            facultystaff_Info info = new facultystaff_Info();

            //查询条件
            var predicate = WhereExtension.True<facultystaff_Info>();//初始化where表达式
            predicate = predicate.And(p => p.id.Equals(id));

            var result = DbSet.Where(predicate).ToList();
            if (result.Count > 0)
            {
                info = result.First();
            }
            else
            {
                info = null;
            }

            return info;
        }

        //删除信息
        public void RemoveInfo(facultystaff_Info info)
        {
            DbSet.Remove(info);
        }


        //根据条件查询
        public List<facultystaff_Info> GetByModel(FacultystaffSearchModel model)
        {
            //查询条件
            var predicate = WhereExtension.True<facultystaff_Info>();//初始化where表达式
                                                                //姓名
            if (!String.IsNullOrEmpty(model.Name))
            {
                predicate = predicate.And(p => p.Name.Contains(model.Name));
            }
            //身份证
            if (!String.IsNullOrEmpty(model.IdNumber))
            {
                predicate = predicate.And(p => p.IdNumber.Equals(model.IdNumber));
            }
            //学校
            if (!String.IsNullOrEmpty(model.SchoolCode))
            {
                predicate = predicate.And(p => p.SchoolCode.Equals(model.SchoolCode));
            }
            //部门
            if (!String.IsNullOrEmpty(model.DepartCode))
            {
                predicate = predicate.And(p => p.DepartCode.Equals(model.DepartCode));
            }
            //岗位
            if (!String.IsNullOrEmpty(model.StaffCode))
            {
                predicate = predicate.And(p => p.StaffCode.Equals(model.StaffCode));
            }
            //住址
            if (!String.IsNullOrEmpty(model.PermanentAddress))
            {
                predicate = predicate.And(p => p.PermanentAddress.Contains(model.PermanentAddress));
            }
            var result = DbSet.Where(predicate).ToList();


            return result;
        }

        public facultystaff_Info getByidNumber(string idnumber)
        {
            return DbSet.FirstOrDefault(a => a.IdNumber == idnumber);
        }

        public List<DepartInfoSearchMiddleModel> GetDepartlListContainId(GradeAndClassSearchViewModel gradeAndClassSearchViewModel)
        {
            return Db.facultystaff_Info.Where(a => a.SchoolCode == gradeAndClassSearchViewModel.SchoolCode).Select(a => new DepartInfoSearchMiddleModel
            {

                DepartCode = a.DepartCode,
                DepartName = a.DepartName
            }).Distinct().ToList();
        }

        public List<StationInfoSearchMiddleModel> GetStationListContainId(GradeAndClassSearchViewModel gradeAndClassSearchViewModel)
        {
            return Db.facultystaff_Info.Where(a => a.SchoolCode == gradeAndClassSearchViewModel.SchoolCode).Select(a => new StationInfoSearchMiddleModel
            {

                StaffCode = a.StaffCode,
                StaffName = a.StaffName,

            }).Distinct().ToList();
        }

        public void flushfacultyStationId()
        {
            var StationInfoList = Db.Station_Info.ToList();
            for (int i = 0; i < StationInfoList.Count; i++)
            {
                var temp = DbSet.Where(a => a.StaffCode == StationInfoList[i].StaffCode).ToList();
                temp.ForEach(w => w.station_InfoId = StationInfoList[i].id);
                DbSet.UpdateRange(temp);
            }

        }
    }
}
