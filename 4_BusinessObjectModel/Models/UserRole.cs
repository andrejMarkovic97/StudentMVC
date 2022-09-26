using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _4_BusinessObjectModel.Models
{

    public class UserRole 
    {
        public UserRole()
        {

        }
      
        public Guid UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }

      
        public Guid RoleID { get; set; }

        [ForeignKey("RoleID")]
        public Role Role { get; set; }


    }
}