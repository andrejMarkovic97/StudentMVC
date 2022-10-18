using _2_BusinessLayer.StudentServices;
using _3_DataAccess;
using _3_DataAccess.StudentRepository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _2_BusinessLayer.Tests.IntegrationTests.ProfessorServiceIntegrationTest
{
    public class ProfessorServiceIntegrationTest
    {
        private readonly UserDBContext _db;
        private readonly ProfessorRepository _repo;
        private readonly ProfessorService _sut;
        public ProfessorServiceIntegrationTest()
        {
            _db = new UserDBContext();
            _repo = new ProfessorRepository(_db);
            _sut = new ProfessorService(_repo);
        }
        [Fact]
        public void Insert_And_Delete_Should_Work_If_Professor_Valid()
        {

            //Arrange
            var list = _sut.GetAll();
            var listSize = list.Count();
            var insertProfessor = DummyProfessors()[0];
            var expected = true;

            //Act
            _sut.Add(insertProfessor);
            bool actual = false;

            //Assert
            var newList = _sut.GetAll();
            var newListSize = newList.Count();

            if (newList.FirstOrDefault(r => r.UserID == insertProfessor.UserID) != null && newListSize == listSize + 1)
            {

                _sut.Delete(insertProfessor.UserID);

                if (_sut.GetAll().FirstOrDefault(cs => cs.UserID == insertProfessor.UserID) == null)
                {
                    actual = true;
                }


            }

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Edit_Should_Work_If_Professor_Valid()
        {
            //Arrange
            var list = _sut.GetAll();

            var professor = DummyProfessors()[0];
            bool expected = true;
            //Act
            bool actual = false;
            _sut.Add(professor);

            professor.FirstName = "TestFirstName";
            professor.Subject = "TestSubject";
            if (_sut.GetAll().FirstOrDefault(s => s.UserID == professor.UserID) != null && _sut.GetAll().Count() == list.Count() + 1)
            {
                _sut.Edit(professor);
                if (_sut.GetAll().FirstOrDefault(s => s.UserID == professor.UserID && s.FirstName == professor.FirstName && s.Subject == professor.Subject) != null)
                {
                    actual = true;
                }
                _sut.Delete(professor.UserID);
            }

            //Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Get_Should_Return_Professor_If_Professor_Valid()
        {
            //Arrange
            var professor = DummyProfessors()[0];
            bool expected = true;

            //Act
            _sut.Add(professor);
            bool actual = false;
            if (_sut.Get(professor.UserID) == professor)
            {
                actual = true;
            }
            _sut.Delete(professor.UserID);

            //Assert
            Assert.Equal(expected, actual);



        }

        [Fact]
        public void Get_All_Should_Return_All_If_List_Valid()
        {
            var expected = true;

            var list = _sut.GetAll();
            var actual = false;

            if (list != null)
            {
                actual = true;
            }

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Search_Should_Return_List_If_Filter_Valid()
        {
            //Arrange

            bool expected = true;
            var insertProfessor = DummyProfessors()[0];
            _sut.Add(insertProfessor);
            var list = _sut.GetAll();
            string filter = insertProfessor.FirstName;

            //Act
            bool actual = false;
            var filteredList = _sut.Search(filter);
            if (filteredList.FindAll(s => s.FirstName.Contains(filter)).Count() > 0 && filteredList.Contains(insertProfessor))
            {
                actual = true;
            }
            _sut.Delete(insertProfessor.UserID);

            //Assert
            Assert.Equal(expected, actual);



        }
        [Fact]
        public void GetUserByEmail_Should_Return_User_If_User_Valid()
        {
            //Arrange
            var expected = DummyProfessors()[0];
            _sut.Add(expected);


            var actual = _sut.GetUserByEmail(expected.Email);
            _sut.Delete(expected.UserID);

            Assert.Equal(expected, actual);


        }
        private List<Professor> DummyProfessors()
        {
            List<Professor> list = new List<Professor>();

            var cs1 = new Professor
            {
                UserID = Guid.NewGuid(),
                FirstName = "Andrej",
                LastName = "Markovic",
                BirthDate = DateTime.Parse("01/01/1997"),
                Email = "markovic@gmail.com",
                Password = "123",
                PhoneNumber = "123",
                Adress = "Vojvode Stepe",
                Cabinet = "100",
                Subject = "P1",
                UserRoles = new List<UserRole>()

            };
            UserRole ur1 = new UserRole
            {
                UserID = cs1.UserID,
                RoleID = Guid.Parse("BB49E8A7-29EF-4C35-895F-D2FD87E4E4F0")
            };
            cs1.UserRoles.Add(ur1);

            var cs2 = new Professor
            {
                UserID = Guid.NewGuid(),
                FirstName = "Nikola",
                LastName = "Markovic",
                BirthDate = DateTime.Parse("01/01/1997"),
                Email = "Nikola@gmail.com",
                Password = "123",
                PhoneNumber = "123",
                Adress = "Vojvode Stepe",
                Subject = "P2",
                Cabinet = "103",
                UserRoles = new List<UserRole>()

            };
            UserRole ur2 = new UserRole
            {
                UserID = cs1.UserID,
                RoleID = Guid.Parse("BB49E8A7-29EF-4C35-895F-D2FD87E4E4F0")
            };
            cs2.UserRoles.Add(ur2);

            list.Add(cs1);
            list.Add(cs2);
            return list;


        }
    }
}
