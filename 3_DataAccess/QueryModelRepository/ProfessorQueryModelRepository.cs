using _3_DataAccess.QueryModels;
using _3_DataAccess.Repository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3_DataAccess.QueryModelRepository
{
    public class ProfessorQueryModelRepository : IGenericRepository<ProfessorQueryModel>
    {
        private readonly UserDBContext db;

        public ProfessorQueryModelRepository(UserDBContext db)
        {
            this.db = db;
        }

        public void Add(ProfessorQueryModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Edit(ProfessorQueryModel entity)
        {
            throw new NotImplementedException();
        }

        public ProfessorQueryModel Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ProfessorQueryModel> GetAll()
        {
            
            using (db)
            {
                var query = @"SELECT   user_id AS UserID,
                              first_name as FirstName,
                              last_name as LastName,
                              birth_date as BirthDate,
                              cabinet as Cabinet,
                              subject as Subject 
                                    from t_user
                              where cabinet is not null and  subject is not null";

                var professorQueryModelList = db.Database.SqlQuery<ProfessorQueryModel>(query).ToList();

                foreach (var prof in professorQueryModelList)
                {
                    prof.UserRoles = db.UserRoles.Include("Role").Where(ur => ur.UserID == prof.UserID).ToList();
                }

                return professorQueryModelList;
            }

        }

        public ProfessorQueryModel GetUserByCredentials(string email, string password)
        {
            throw new NotImplementedException();
        }

        public List<ProfessorQueryModel> Search(string filter)
        {
            throw new NotImplementedException();
        }
    }
}