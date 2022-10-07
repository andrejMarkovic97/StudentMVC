using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _3_DataAccess.QueryModels
{
    public class HighSchoolStudentQueryModel : UserQueryModel
    {
        public HighSchoolStudentQueryModel()
        {

        }
        public string SchoolName { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EnrollmentDate { get; set; }
    }
}