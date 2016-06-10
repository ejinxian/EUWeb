﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EU.Models
{
    /// <summary>
    /// 用户角色关系
    /// </summary>
    public class UserRoleRelation
    {
        [Key]
        public int RelationID { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [Required()]
        public int UserID { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        [Required()]
        public int RoelID { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public virtual Role Role { get; set; }
    }
}
