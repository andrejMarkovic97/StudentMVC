using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1_PresentationLayer.ViewModels
{
    public class HighSchoolStudentViewModel : UserViewModel
    {
        public string SchoolName { get; set; }


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