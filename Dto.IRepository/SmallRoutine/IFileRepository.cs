using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine;

namespace Dto.IRepository.SmallRoutine
{
    public interface IFileRepository : IRepository<UploadFile>
    {
        int getfileIDByPhy(FileUploadViewModel fileUploadViewModel);
    }
}
