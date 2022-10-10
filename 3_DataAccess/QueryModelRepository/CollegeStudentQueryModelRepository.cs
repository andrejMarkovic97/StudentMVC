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
                var query = @"SELECT u.user_id AS UserID,
                             u.first_name as FirstName,
                            u.last_name as LastName,
                            u.birth_date as BirthDate,
                            u.institution_name as InstitutionName,
                            u.generation as Generation
                            from t_user u
                            inner join t_user_roles ur on u.user_id = ur.user_id
                            inner join t_roles r on ur.role_id = r.role_id
                            where r.role_name='CollegeStudent'";


                var collegeStudentQueryModelList = db.Database.SqlQuery<CollegeStudentQueryModel>(query).ToList();

                

                return collegeStudentQueryModelList;
            }

        }

        public CollegeStudentQueryModel GetUserByCredentials(string email, string password)
        {
            throw new NotImplementedException();
        }

        public CollegeStudentQueryModel GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public List<CollegeStudentQueryModel> Search(string filter)
        {
            return GetAll().FindAll(x => x.FirstName.ToLower() == filter || x.LastName.ToLower() == filter || x.BirthDate.ToString() == filter
            || x.InstitutionName.ToLower() == filter || x.Generation.ToString() == filter);
        }
    }
}