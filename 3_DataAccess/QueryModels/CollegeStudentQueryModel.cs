using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3_DataAccess.QueryModels
{
    public class CollegeStudentQueryModel : UserQueryModel
    {
        public CollegeStudentQueryModel()
        {

        }
        public string InstitutionName { get; set; }


        public int Generation { get; set; }
    }
}