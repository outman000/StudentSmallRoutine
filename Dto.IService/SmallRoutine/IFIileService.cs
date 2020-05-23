using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.DayAndNightViewModel;
using ViewModel.SmallRoutine.ResponseViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.DayAndNightViewModel;

namespace Dto.IService.SmallRoutine
{
    public  interface IFIileService
    {
        /// <summary>
        /// 随机文件名称
        /// </summary>
        /// <param name="fileRealname"></param>
        /// <returns></returns>
        String fileRandName(String fileRealname);

        /// <summary>
        /// 保存文件信息
        /// </summary>
        /// <param name="fileRealname"></param>
        /// <returns></returns>
        FileImgResViewModel SaveFileInfo(FileUploadViewModel  fileUploadViewModel);

        /// <summary>
        /// 保存图片文件信息
        /// </summary>
        /// <param name="fileRealname"></param>
        /// <returns></returns>
        int SaveImageFileInfo(FileImageUploadViewModel fileUploadViewModel);


        /// <summary>
        /// 导入白名单数据到数据库
        /// </summary>
        /// <param name="fileUploadViewModel"></param>
        /// <returns></returns>
        int InputWhiteListIntoDataBase(String FilePath,String FileName);
        /// <summary>
        /// 员工信息导入
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        int InputWhiteListIntoDataBase_facultystaffInfo(string FilePath, string FileName);
        int InputStudentInfoTimeIntervalIntoDataBase(string filePath, string randomname);
        List<FIleinfoMiddle> GetFileInfoBy(string idnumber);
        void deleteDayandNightInfoByFile(DayAndNightDeleteByFIlesViewModel dayAndNightDeleteByFIlesViewModel);


        DayAndNightStudentImportResModel InputStudentInfoTimeIntervalIntoDataBaseValide(string filePath, string randomname, string Idnumber);


        void deletebyfilephyid(string phyname);
    }
}
