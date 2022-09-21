using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _4_BusinessObjectModel.Models
{
    [Table("t_user")]

    public class CollegeStudent : User
    {
        public CollegeStudent()
        {

        }
        [Column("institution_name")]
        public string InstitutionName { get; set; }

        [Column("generation")]
        public int Generation { get; set; }

        public override string ToString()
        {
            return base.ToString() + 
                $",\nInstitution name :{InstitutionName},\nGeneration : {Generation}";
        }
    }
}