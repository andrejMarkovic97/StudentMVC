using _2_BusinessLayer.StudentServices;
using _3_DataAccess.Repository;
using _4_BusinessObjectModel.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _2_BusinessLayer.Tests.CollegeStudentServiceTest
{
    public class CollegeStudentServiceTest
    {
        private readonly Mock<IUserService<CollegeStudent>> _sut;
     

        public CollegeStudentServiceTest()
        {
            _sut = new Mock<IUserService<CollegeStudent>>();
        }

        [Fact]
        public void Add_When_CollegeStudent_Exists()
        {
            //Arrange
            var student = DummyStudents()[0];
            _sut.Setup(gr => gr.Add(student)).Verifiable();

            //Act
            _sut.Object.Add(student);

            //Assert
            _sut.Verify(m => m.Add(It.Is<CollegeStudent>(cs => cs.UserID == student.UserID)));
        }
        [Fact]
        public void Delete_When_CollegeStudent_Exists()
        {
            Guid studentID = DummyStudents()[0].UserID;
            _sut.Setup(gr => gr.Delete(studentID)).Verifiable();

            _sut.Object.Delete(studentID);

            _sut.Verify(gr => gr.Delete(studentID));
        }

        [Fact]
        public void Edit_When_Entity_Exists()
        {
            var student = DummyStudents()[0];
           _sut.Setup(gr => gr.Edit(student)).Verifiable();

            _sut.Object.Edit(student);

            _sut.Verify(gr => gr.Edit(student));
        }

        [Fact]

        public void Get_ReturnCollegeStudent_WhenCSExist()
        {
            //Arrange
            var collegeStudentID = Guid.NewGuid();
            var collegeStudent = new CollegeStudent
            {
                UserID = collegeStudentID,
                FirstName = "Andrej",
                LastName = "Markovic",
                BirthDate = DateTime.Parse("01/01/1997"),
                Email = "markovic@gmail.com",
                Password = "123",
                PhoneNumber = "123",
                Adress = "Vojvode Stepe",
                InstitutionName = "FON",
                Generation = 2015

            };
            _sut.Setup(gr => gr.Get(collegeStudentID)).Returns(collegeStudent);
            
            //Act
            var cs = _sut.Object.Get(collegeStudentID);

            //Assert
            Assert.Equal(cs.UserID, collegeStudent.UserID);
            Assert.Equal(cs.FirstName, collegeStudent.FirstName);
        }
        [Fact]
        public void GetAll_ShouldReturnList_WhenListExists()
        {
            //Arrange
            List<CollegeStudent> expectedList = DummyStudents();
            _sut.Setup(s => s.GetAll()).Returns(expectedList);

            //Act
            List<CollegeStudent> actualList = _sut.Object.GetAll();

            //Assert
            Assert.Equal(expectedList, actualList);

        }
        [Fact]
        public void Search_If_Filter_Not_Null()
        {
            List<CollegeStudent> expectedList = new List<CollegeStudent>
            {
                DummyStudents()[0]
            };
            string filter = DummyStudents()[0].FirstName;

            _sut.Setup(s => s.Search(filter)).Returns(expectedList);

            //Act

            var actualList = _sut.Object.Search(filter);

            //Assert

            Assert.Equal(expectedList, actualList);
        }

        [Fact]

        public void GetUserByCredentials_If_EmailAndPassword_Exist()
        {
            string email = "test@gmail.com";
            string password = "123";
            var expected = DummyStudents()[1];
            _sut.Setup(gr => gr.GetUserByCredentials(email, password)).Returns(expected);

            var actual = _sut.Object.GetUserByCredentials(email, password);

            Assert.Equal(expected, actual);
        }

        [Fact]
       public void ExportData_If_Student_Exist()
        {
            var student = DummyStudents()[1];
            var expected = true;
           

            _sut.Setup(s => s.ExportData(student)).Returns(expected);

            var actual = _sut.Object.ExportData(student);

            Assert.Equal(expected,actual);

        }

        private List<CollegeStudent> DummyStudents()
        {
            List<CollegeStudent> list = new List<CollegeStudent>();

            var cs1 = new CollegeStudent
            {
                UserID = Guid.NewGuid(),
                FirstName = "Andrej",
                LastName = "Markovic",
                BirthDate = DateTime.Parse("01/01/1997"),
                Email = "markovic@gmail.com",
                Password = "123",
                PhoneNumber = "123",
                Adress = "Vojvode Stepe",
                Generation = 2015,
                InstitutionName = "FON",
                UserRoles = new List<UserRole>()

            };
            UserRole ur1 = new UserRole
            {
                UserID = cs1.UserID,
                RoleID = Guid.NewGuid()
            };
            cs1.UserRoles.Add(ur1);

            var cs2 = new CollegeStudent
            {
                UserID = Guid.NewGuid(),
                FirstName = "Nikola",
                LastName = "Markovic",
                BirthDate = DateTime.Parse("01/01/1997"),
                Email = "Nikola@gmail.com",
                Password = "123",
                PhoneNumber = "123",
                Adress = "Vojvode Stepe",
                Generation = 2015,
                InstitutionName = "FON",
                UserRoles = new List<UserRole>()

            };
            UserRole ur2 = new UserRole
            {
                UserID = cs1.UserID,
                RoleID = Guid.NewGuid()
            };
            cs2.UserRoles.Add(ur2);

            list.Add(cs1);
            list.Add(cs2);
            return list;


        }

        
    }
}
