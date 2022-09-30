using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_PresentationLayer.ViewModels
{
    public class CollegeStudentViewModel : UserViewModel
    {
        public string InstitutionName { get; set; }


        public int Generation { get; set; }


        public override string ToString()
        {
            return base.ToString() +
                $",\nInstitution name :{InstitutionName},\nGeneration : {Generation}";
        }
    }
}