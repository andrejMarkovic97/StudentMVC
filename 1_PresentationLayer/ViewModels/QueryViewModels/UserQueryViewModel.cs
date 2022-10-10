using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1_PresentationLayer.ViewModels.QueryViewModels
{
    public class UserQueryViewModel : DetailsViewModel
    {
        public Guid UserID { get; set; }





        public string FirstName { get; set; }


        public string LastName { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }




        public List<UserRole> UserRoles { get; set; }
    }
}