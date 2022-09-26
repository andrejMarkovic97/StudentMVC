using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _4_BusinessObjectModel.Models
{

    public class Professor : User
    {
        public Professor()
        {

        }
        
        public string Cabinet { get; set; }

        
        public string Subject { get; set; }

       
    }
}