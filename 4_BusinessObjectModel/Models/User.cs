using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _4_BusinessObjectModel.Models
{
 
    
    public class User 
    {
        public User()
        {

        }
       
        public Guid UserID { get; set; }

        
        [EmailAddress]
        public  string Email { get; set; }


        [DataType(DataType.Password)]
        
        public string Password { get; set; }

        
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

    
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        
        public  string PhoneNumber { get; set; }

        
        public string Adress { get; set; }

       
        public List<UserRole> UserRoles { get; set; }
        public override string ToString()
        {
            return $"First Name : {FirstName},\nLast name : {LastName},\nBirth date: {BirthDate.ToShortDateString()},\n" +
                $"Email : {Email},\nPhone number : {PhoneNumber},\nAdress: {Adress}";
        }
    }
}