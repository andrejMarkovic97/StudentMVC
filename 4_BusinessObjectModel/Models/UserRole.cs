using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _4_BusinessObjectModel.Models
{
    [Table("t_user_roles")]
    public class UserRole
    {
        public UserRole()
        {
                
        }
        [Key]
        [Column("user_id")]
        public Guid UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }

        [Column("role_id")]
        public Guid RoleID { get; set; }

        [ForeignKey("RoleID")]
        public Role Role { get; set; }


    }
}