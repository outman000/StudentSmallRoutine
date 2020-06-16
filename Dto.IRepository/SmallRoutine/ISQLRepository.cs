using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.RequestViewModel;

namespace Dto.IRepository.SmallRoutine
{
    public interface ISQLRepository
    {
        //根据 学生 班级信息 查询对应的 班主任、教务主任、校医等 信息（unionid,openid等）
        List<ExpectBindMsgModel> GetJZGByClassCode(string ClassCode, string dept);

        //根据unionid 获取 关注服务号对应的 openid
        string GetOpenidByUnionid(string unionid);

        //根据 教职工 岗位信息 查询对应的 教务主任或总务主任、校医等 信息（unionid,openid等）
        List<ExpectBindMsgModel> GetJZGByStaffCode(string StaffCode, string dept);
    }
}
