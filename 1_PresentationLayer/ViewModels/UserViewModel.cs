using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1_PresentationLayer.ViewModels
{
    public class UserViewModel:GenericViewModel
    {
        public UserViewModel()
        {

        }
        public Guid UserID { get; set; }


        [EmailAddress]
        public string Email { get; set; }


        [DataType(DataType.Password)]

        public string Password { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }


        public string PhoneNumber { get; set; }


        public string Adress { get; set; }


        public List<UserRole> UserRoles { get; set; }
    }
}