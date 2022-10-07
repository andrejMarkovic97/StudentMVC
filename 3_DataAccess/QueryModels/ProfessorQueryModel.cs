using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3_DataAccess.QueryModels
{
    public class ProfessorQueryModel :  UserQueryModel
    {
        public ProfessorQueryModel()
        {

        }
        public string Cabinet { get; set; }


        public string Subject { get; set; }
    }
}