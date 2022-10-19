using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _4_BusinessObjectModel.Models
{
    public class Login
    {
        public Login()
        {
           
        }
        public User User { get; set; }
        public Guid UserID { get; set; }
        public string Email { get; set; }
        

       
        //[DataType(DataType.DateTime)]
        public DateTime LoginDate { get; set; }
    }
}