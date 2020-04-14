using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine;
using ViewModel.SmallRoutine.ResponseViewModel;

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
    }
}
