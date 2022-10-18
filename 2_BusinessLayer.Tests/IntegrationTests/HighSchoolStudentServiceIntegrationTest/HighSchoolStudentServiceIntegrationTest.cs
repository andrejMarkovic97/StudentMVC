using _2_BusinessLayer.StudentServices;
using _3_DataAccess;
using _3_DataAccess.Repository;
using _4_BusinessObjectModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _2_BusinessLayer.Tests.IntegrationTests.HighSchoolStudentServiceIntegrationTest
{
    public class HighSchoolStudentServiceIntegrationTest
    {
        private readonly UserDBContext _db;
        private readonly HighSchoolStudentRepository _repo;
        private readonly HighSchoolStudentService _sut;
        public HighSchoolStudentServiceIntegrationTest()
        {
            _db = new UserDBContext();
            _repo = new HighSchoolStudentRepository(_db);
            _sut = new HighSchoolStudentService(_repo);
        }

        [Fact]
        public void Insert_And_Delete_Should_Work_If_Student_Valid()
        {

            //Arrange
            var list = _sut.GetAll();
            var listSize = list.Count();
            var insertStudent = DummyStudents()[0];
            var expected = true;

            //Act
            _sut.Add(insertStudent);
            bool actual = false;

            //Assert
            var newList = _sut.GetAll();
            var newListSize = newList.Count();

            if (newList.FirstOrDefault(r => r.UserID == insertStudent.UserID) != null && newListSize == listSize + 1)
            {

                _sut.Delete(insertStudent.UserID);

                if (_sut.GetAll().FirstOrDefault(cs => cs.UserID == insertStudent.UserID) == null)
                {
                    actual = true;
                }


            }

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Edit_Should_Work_If_Student_Valid()
        {
            //Arrange
            var list = _sut.GetAll();

            var student = DummyStudents()[0];
            bool expected = true;
            //Act
            bool actual = false;
            _sut.Add(student);

            student.FirstName = "TestFirstName";
            student.SchoolName = "TestSchool";
            if (_sut.GetAll().FirstOrDefault(s => s.UserID == student.UserID) != null && _sut.GetAll().Count() == list.Count() + 1)
            {
                _sut.Edit(student);
                if (_sut.GetAll().FirstOrDefault(s => s.UserID == student.UserID && s.FirstName == student.FirstName && s.SchoolName == student.SchoolName) != null)
                {
                    actual = true;
                }
                _sut.Delete(student.UserID);
            }

            //Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Get_Should_Return_Student_If_Student_Valid()
        {
            //Arrange
            var student = DummyStudents()[0];
            bool expected = true;

            //Act
            _sut.Add(student);
            bool actual = false;
            if (_sut.Get(student.UserID) == student)
            {
                actual = true;
            }
            _sut.Delete(student.UserID);

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
            var insertStudent = DummyStudents()[0];
            _sut.Add(insertStudent);
            var list = _sut.GetAll();
            string filter = insertStudent.FirstName;

            //Act
            bool actual = false;
            var filteredList = _sut.Search(filter);
            if (filteredList.FindAll(s => s.FirstName.Contains(filter)).Count() > 0 && filteredList.Contains(insertStudent))
            {
                actual = true;
            }
            _sut.Delete(insertStudent.UserID);

            //Assert
            Assert.Equal(expected, actual);



        }
        [Fact]
        public void GetUserByEmail_Should_Return_User_If_User_Valid()
        {
            //Arrange
            var expected = DummyStudents()[0];
            _sut.Add(expected);


            var actual = _sut.GetUserByEmail(expected.Email);
            _sut.Delete(expected.UserID);

            Assert.Equal(expected, actual);


        }
        private List<HighSchoolStudent> DummyStudents()
        {
            List<HighSchoolStudent> list = new List<HighSchoolStudent>();

            var cs1 = new HighSchoolStudent
            {
                UserID = Guid.NewGuid(),
                FirstName = "Andrej",
                LastName = "Markovic",
                BirthDate = DateTime.Parse("01/01/1997"),
                Email = "markovic@gmail.com",
                Password = "123",
                PhoneNumber = "123",
                Adress = "Vojvode Stepe",
                EnrollmentDate = DateTime.Parse("01/01/2010"),
                SchoolName = "Vuk Karadzic",
                UserRoles = new List<UserRole>()

            };
            UserRole ur1 = new UserRole
            {
                UserID = cs1.UserID,
                RoleID = Guid.Parse("BB49E8A7-29EF-4C35-895F-D2FD87E4E4F0")
            };
            cs1.UserRoles.Add(ur1);

            var cs2 = new HighSchoolStudent
            {
                UserID = Guid.NewGuid(),
                FirstName = "Nikola",
                LastName = "Markovic",
                BirthDate = DateTime.Parse("01/01/1997"),
                Email = "Nikola@gmail.com",
                Password = "123",
                PhoneNumber = "123",
                Adress = "Vojvode Stepe",
                EnrollmentDate = DateTime.Parse("09/09/2011"),
                SchoolName = "Sveti Sava",
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
