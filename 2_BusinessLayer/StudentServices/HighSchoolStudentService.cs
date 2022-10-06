using _2_BusinessLayer.GenericService;
using _3_DataAccess.Repository;
using _4_BusinessObjectModel;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace _2_BusinessLayer.StudentServices
{
    public class HighSchoolStudentService : UserService<HighSchoolStudent>
    {

        public HighSchoolStudentService(IGenericRepository<HighSchoolStudent> genericRepository) : base(genericRepository)
        {
        }


        //public override List<HighSchoolStudent> Search(string filter)
        //{
        //    filter = filter.ToLower();

        //    return genericRepository.Search(filter);



        //}
     
       

      
    }
}