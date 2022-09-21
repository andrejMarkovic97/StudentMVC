using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace _4_BusinessObjectModel.Models
{
    [Table("t_roles")]
    public class Role  
    {
        public Role()
        {

        }
        [Key]
        [Column("role_id")]
        public Guid RoleID{ get; set; }
        [Column("role_name")]
        public string RoleName { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

    }
}