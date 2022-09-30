using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1_PresentationLayer.ViewModels
{
    public class RoleViewModel : GenericViewModel
    {
        public RoleViewModel()
        {
            
        }
        public Guid RoleID { get; set; }

        public string RoleName { get; set; }

        public List<UserRole> UserRoles { get; set; }

        

       
    }
}