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

    public class Role 
    {
        public Role()
        {
                
        }

        public Guid RoleID { get ; set; }
       
        public string RoleName { get; set; }
        public List<UserRole> UserRoles { get; set; }

    }
}