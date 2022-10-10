using _1_PresentationLayer.ViewModels.QueryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_PresentationLayer.ViewModels.QueryViewModels
{
    public class CollegeStudentQueryViewModel : UserQueryViewModel
    {
        public CollegeStudentQueryViewModel()
        {

        }
        public string InstitutionName { get; set; }


        public int Generation { get; set; }
    }
}