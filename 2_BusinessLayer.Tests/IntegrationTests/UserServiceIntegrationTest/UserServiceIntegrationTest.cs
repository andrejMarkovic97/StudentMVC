using _2_BusinessLayer.StudentServices;
using _3_DataAccess;
using _3_DataAccess.UserRepository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _2_BusinessLayer.Tests.IntegrationTests.UserServiceIntegrationTest
{
    public class UserServiceIntegrationTest
    {
        private readonly UserRepository _repo;
        private readonly UserDBContext _db;
        private readonly UserService<User> _sut;


        public UserServiceIntegrationTest()
        {
            _db = new UserDBContext();
            _repo = new UserRepository(_db);
            _sut = new UserService<User>(_repo);
        }

        [Fact]
        public void GetUserByCredentials_Should_Return_User_If_User_Valid()
        {
            //Arrange
            var expected = DummyStudent();
            _sut.Add(expected);

            var actual = _sut.GetUserByCredentials(expected.Email, expected.Password);
            _sut.Delete(expected.UserID);

            Assert.Equal(expected, actual);

            
        }

       
        private User DummyStudent()
        {
            

            var user = new User
            {
                UserID = Guid.NewGuid(),
                FirstName = "Marko",
                LastName = "Markovic",
                BirthDate = DateTime.Parse("01/01/1997"),
                Email = "test@gmail.com",
                Password = "123",
                PhoneNumber = "123",
                Adress = "Vojvode Stepe",
                
                UserRoles = new List<UserRole>()

            };
            UserRole ur1 = new UserRole
            {
                UserID = user.UserID,
                RoleID = Guid.Parse("BB49E8A7-29EF-4C35-895F-D2FD87E4E4F0")
            };
            user.UserRoles.Add(ur1);


            return user;


        }
    }
}

