using _3_DataAccess.QueryModels;
using _3_DataAccess.Repository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3_DataAccess.QueryModelRepository
{
    public class CollegeStudentQueryModelRepository : IGenericRepository<CollegeStudentQueryModel>
    {
        private readonly UserDBContext db;

        public CollegeStudentQueryModelRepository(UserDBContext db)
        {
            this.db = db;
        }

        public void Add(CollegeStudentQueryModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Edit(CollegeStudentQueryModel entity)
        {
            throw new NotImplementedException();
        }

        public CollegeStudentQueryModel Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<CollegeStudentQueryModel> GetAll()
        {
            using (db)
            {
                var query = @"SELECT   user_id AS UserID,
                              first_name as FirstName,
                              last_name as LastName,
                              birth_date as BirthDate,
                              institution_name as InstitutionName,
                              generation as Generation 
                                from t_user
                    where institution_name is not null and generation is not null";

                var collegeStudentQueryModelList = db.Database.SqlQuery<CollegeStudentQueryModel>(query).ToList();

                foreach (var cs in collegeStudentQueryModelList)
                {
                   cs.UserRoles = db.UserRoles.Include("Role").Where(ur => ur.UserID == cs.UserID).ToList();
                }

                return collegeStudentQueryModelList;
            }

        }

        public CollegeStudentQueryModel GetUserByCredentials(string email, string password)
        {
            throw new NotImplementedException();
        }

        public List<CollegeStudentQueryModel> Search(string filter)
        {
            throw new NotImplementedException();
        }
    }
}