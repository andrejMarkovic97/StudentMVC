using _3_DataAccess.GenericRepository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3_DataAccess.LoginRepository
{
    public class LoginRepository : GenericRepository<Login>
    {
        public LoginRepository(UserDBContext db) : base(db)
        {
        }

        public override Login Get(Guid id)
        {
            return db.Logins.AsNoTracking().FirstOrDefault(l => l.UserID == id);
        }
    }
}