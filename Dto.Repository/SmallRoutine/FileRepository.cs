using Dto.IRepository.SmallRoutine;
using Dtol;
using Dtol.dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.SmallRoutine;

namespace Dto.Repository.SmallRoutine
{
    public class FileRepository : IFileRepository
    {

        protected readonly DtolContext Db;
        protected readonly DbSet<UploadFile> DbSet;

        public FileRepository(DtolContext context)
        {
            Db = context;
            DbSet = Db.Set<UploadFile>();
        }
        public void Add(UploadFile obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<UploadFile> GetAll()
        {
            throw new NotImplementedException();
        }

        public UploadFile GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public int getfileIDByPhy(FileUploadViewModel fileUploadViewModel)
        {
            return DbSet.Single(a => a.PhysisticName.Trim() == fileUploadViewModel.PhysisticName).id;

        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Update(UploadFile obj)
        {
            throw new NotImplementedException();
        }
    }
}
