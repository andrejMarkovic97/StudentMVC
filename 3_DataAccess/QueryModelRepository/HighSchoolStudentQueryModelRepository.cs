using _3_DataAccess.QueryModels;
using _3_DataAccess.Repository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3_DataAccess.QueryModelRepository
{
    public class HighSchoolStudentQueryModelRepository : IGenericRepository<HighSchoolStudentQueryModel>
    {
        private readonly UserDBContext db;

        public HighSchoolStudentQueryModelRepository(UserDBContext db) 
        {
            this.db = db;
        }

        public void Add(HighSchoolStudentQueryModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Edit(HighSchoolStudentQueryModel entity)
        {
            throw new NotImplementedException();
        }

        public HighSchoolStudentQueryModel Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<HighSchoolStudentQueryModel> GetAll()
        {

            using (db)
            {
                var query = @"SELECT user_id AS UserID,
                              first_name as FirstName,
                              last_name as LastName,
                              birth_date as BirthDate,
                              school_name as SchoolName,
                              enrollment_date as EnrollmentDate
                              from t_user
                              where school_name is not null and enrollment_date is not null";

                var highSchoolStudentQueryModelList = db.Database.SqlQuery<HighSchoolStudentQueryModel>(query).ToList();

                foreach (var hs in highSchoolStudentQueryModelList)
                {
                    var userRoles = db.UserRoles.Include("Role").Where(ur => ur.UserID == hs.UserID).ToList();
                }

                return highSchoolStudentQueryModelList;
            }

        }

        public HighSchoolStudentQueryModel GetUserByCredentials(string email, string password)
        {
            throw new NotImplementedException();
        }

        public List<HighSchoolStudentQueryModel> Search(string filter)
        {
            throw new NotImplementedException();
        }
    }
}