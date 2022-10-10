using _3_DataAccess;
using _3_DataAccess.Repository;
using _4_BusinessObjectModel.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _3_DataAccessLayer.Tests.CollegeStudentRepositoryTest
{
   public  class CollegeStudentRepositoryTest
    {
        private readonly Mock<IGenericRepository<CollegeStudent>> _sut;
        

        public CollegeStudentRepositoryTest()
        {

            _sut = new Mock<IGenericRepository<CollegeStudent>>();
        }

        [Fact]
        public void Should_Add_Student_If_Student_Exists()
        {
            //Arrange
            var UserID = Guid.NewGuid();
            var student = DummyStudents()[0];
            _sut.Setup(s => s.Add(student)).Verifiable();

            //Act
            _sut.Object.Add(student);

            //Assert
            _sut.Verify(m => m.Add(It.Is<CollegeStudent>(stud => stud.UserID == student.UserID)));


        }

        [Fact]
        public void Should_Delete_Student_If_Student_Exists()
        {
            var userID = DummyStudents()[0].UserID;
            _sut.Setup(s => s.Delete(userID)).Verifiable();

            _sut.Object.Delete(userID);

            _sut.Verify(s => s.Delete(userID));
        }

        [Fact]

        public void Edit_If_Entity_Exists()
        {
            var entity = DummyStudents()[0];
            _sut.Setup(s => s.Edit(entity)).Verifiable();



            _sut.Object.Edit(entity);

            _sut.Verify(s => s.Edit(It.Is<CollegeStudent>(e => e.UserID == entity.UserID)));


        }

        [Fact]

        public void GetAll_If_Entites_Exist()
        {
            var expectedList = DummyStudents();
            _sut.Setup(s => s.GetAll()).Returns(expectedList);

            var actualList = _sut.Object.GetAll();

            Assert.Equal(expectedList, actualList);

        }

        [Fact]
        public void Get_If_Entity_Exist()
        {
            var expected = DummyStudents()[0];
            _sut.Setup(s => s.Get(expected.UserID)).Returns(expected);

            var actual = _sut.Object.Get(expected.UserID);

            Assert.Equal(expected, actual);
        }

        [Fact]

        public void GetUserByCredentials_If_User_Exists()
        {
            var expected = DummyStudents()[0];
            _sut.Setup(s => s.GetUserByCredentials(expected.Email, expected.Password)).Returns(expected);

            var actual = _sut.Object.GetUserByCredentials(expected.Email, expected.Password);

            Assert.Equal(expected, actual);


        }
        [Fact]
        public void Search_If_Filter_Exists()
        {
            List<CollegeStudent> expected = new List<CollegeStudent>();
            expected.Add(DummyStudents()[0]);
            string filter = expected[0].FirstName;

            _sut.Setup(s => s.Search(filter)).Returns(expected);

            var actual = _sut.Object.Search(filter);

            Assert.Equal(expected, actual);

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
