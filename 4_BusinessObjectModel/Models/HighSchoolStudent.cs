using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _4_BusinessObjectModel.Models
{
    [Table("t_user")]


    public class HighSchoolStudent : User
    {
        public HighSchoolStudent()
        {
                
        }
        [Column("school_name")]
        public string SchoolName { get; set; }

        [Required]
        [Column("enrollment_date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EnrollmentDate { get; set; }

        public override string ToString()
        {
            return base.ToString() + 
                $",\nSchool name :{SchoolName},\nEnrollment date : {EnrollmentDate}";
        }
    }
    }