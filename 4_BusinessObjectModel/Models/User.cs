using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _4_BusinessObjectModel.Models
{
    [Table("t_user")]
    public class User 
    {
        public User()
        {
                
        }
        [Key]
        [Column("user_id")]
        public Guid UserID { get; set; }
        [Required]
        [EmailAddress]
        [Column("email")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Column("password")]
        public string Password { get; set; }


        public List<UserRole> UserRoles { get; set; }

        public override string ToString()
        {
            return $"{UserID},{Email},{Password},{UserRoles.ToString()}";
        }
    }
}