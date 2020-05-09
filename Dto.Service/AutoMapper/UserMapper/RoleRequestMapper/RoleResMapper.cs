using AutoMapper;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.UserViewModel.MiddleModel;
using ViewModel.UserViewModel.RequsetModel;

namespace Dto.Service.AutoMapper.UserMapper.RoleRequestMapper
{
    public class RoleResMapper : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public RoleResMapper()
        {

            CreateMap<UserRoleAddViewModel, Station_Info>();
            CreateMap<UserRoleUpdateViewModel, Station_Info>();
            CreateMap<Station_Info, UserRoleSearChMiddles>();

        }
    }
}
