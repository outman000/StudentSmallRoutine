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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
