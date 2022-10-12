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


                var query = @"SELECT u.user_id AS UserID,
                             u.first_name as FirstName,
                            u.last_name as LastName,
                            u.birth_date as BirthDate,
                            u.enrollment_date as EnrollmentDate,
                            u.school_name as SchoolName
                            from t_user u
                            inner join t_user_roles ur on u.user_id = ur.user_id
                            inner join t_roles r on ur.role_id = r.role_id
                            where r.role_name='HighSchoolStudent'";

                var highSchoolStudentQueryModelList = db.Database.SqlQuery<HighSchoolStudentQueryModel>(query).ToList();

               

                return highSchoolStudentQueryModelList;
            }

        }

        public HighSchoolStudentQueryModel GetUserByCredentials(string email, string password)
        {
            throw new NotImplementedException();
        }

        public HighSchoolStudentQueryModel GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public List<HighSchoolStudentQueryModel> Search(string filter)
        {
            return GetAll().FindAll(x => x.FirstName.ToLower().Contains(filter) || x.LastName.ToLower().Contains(filter)
            || x.BirthDate.ToString().Contains(filter) ||x.SchoolName.ToLower().Contains(filter) || x.EnrollmentDate.ToString().Contains(filter));
        }
    }
}