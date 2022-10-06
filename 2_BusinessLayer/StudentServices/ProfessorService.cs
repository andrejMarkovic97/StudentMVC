using _2_BusinessLayer.GenericService;
using _3_DataAccess.Repository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2_BusinessLayer.StudentServices
{
    public class ProfessorService : UserService<Professor>
    {
        public ProfessorService(IGenericRepository<Professor> professorRepository) : base(professorRepository)
        {

        }
    }
}