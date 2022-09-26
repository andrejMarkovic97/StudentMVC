using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _4_BusinessObjectModel.Models
{
   
    public class CollegeStudent : User
    {
        public CollegeStudent()
        {

        }
        
        public string InstitutionName { get; set; }

        
        public int Generation { get; set; }


        public override string ToString()
        {
            return base.ToString() + 
                $",\nInstitution name :{InstitutionName},\nGeneration : {Generation}";
        }
    }
}