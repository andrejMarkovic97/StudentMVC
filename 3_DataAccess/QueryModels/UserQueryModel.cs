using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _3_DataAccess.QueryModels
{
    public class UserQueryModel
    {

        public UserQueryModel()
        {

        }
        public Guid UserID { get; set; }


      


        public string FirstName { get; set; }


        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }




        
    }
}