using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dtol.dtol
{
    public class User_Group
    {
        [Key]
        [StringLength(50)]
        public string ID { get; set; }
        /// <summary>
        /// 角色Code
        /// </summary>
        [StringLength(100)]
        public string Code { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        [StringLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// 岗位集合
        /// </summary>
        [StringLength(500)]
        public string StationNames { get; set; }
        public string CreateUser { get; set; }
        public DateTime? Creatdate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? Updatedate { get; set; }
        public string Status { get; set; }
        [StringLength(1000)]
        public string bak1 { get; set; }
        [StringLength(1000)]
        public string bak2 { get; set; }
        [StringLength(1000)]
        public string bak3 { get; set; }
        [StringLength(1000)]
        public string bak4 { get; set; }
        [StringLength(1000)]
        public string bak5 { get; set; }
        /// <summary>
        /// 岗位Code集合
        /// </summary>
        public string StationCodes { get; set; }
    }
}
