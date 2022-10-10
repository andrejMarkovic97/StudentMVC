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
                var query = @"SELECT u.user_id AS UserID,
                             u.first_name as FirstName,
                            u.last_name as LastName,
                            u.birth_date as BirthDate,
                            u.subject as Subject,
                            u.cabinet as Cabinet
                            from t_user u
                            inner join t_user_roles ur on u.user_id = ur.user_id
                            inner join t_roles r on ur.role_id = r.role_id
                            where r.role_name='Professor'";

                var professorQueryModelList = db.Database.SqlQuery<ProfessorQueryModel>(query).ToList();

                

                return professorQueryModelList;
            }

        }

        public ProfessorQueryModel GetUserByCredentials(string email, string password)
        {
            throw new NotImplementedException();
        }

        public ProfessorQueryModel GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public List<ProfessorQueryModel> Search(string filter)
        {
            throw new NotImplementedException();
        }
    }
}