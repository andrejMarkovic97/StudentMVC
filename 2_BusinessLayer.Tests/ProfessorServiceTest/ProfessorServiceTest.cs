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

namespace _2_BusinessLayer.Tests.ProfessorServiceTest
{

    public class ProfessorServiceTest
    {
        private readonly Mock<IUserService<Professor>> _sut;
       
        public ProfessorServiceTest()
        {
            _sut = new Mock<IUserService<Professor>>();
        }
        [Fact]
        public void Add_When_Entity_Exists()
        {
            //Arrange
            var entity = DummyProfessors()[0];
            _sut.Setup(gr => gr.Add(entity)).Verifiable();

            //Act
            _sut.Object.Add(entity);

            //Assert
            _sut.Verify(m => m.Add(It.Is<Professor>(cs => cs.UserID == entity.UserID)));
        }
        [Fact]
        public void Delete_When_Entity_Exists()
        {
            Guid professorID = DummyProfessors()[0].UserID;
            _sut.Setup(gr => gr.Delete(professorID)).Verifiable();

            _sut.Object.Delete(professorID);

            _sut.Verify(gr => gr.Delete(professorID));
        }

        [Fact]
        public void Edit_When_Entity_Exists()
        {
            var professor = DummyProfessors()[0];
            _sut.Setup(gr => gr.Edit(professor)).Verifiable();

            _sut.Object.Edit(professor);

            _sut.Verify(gr => gr.Edit(professor));
        }

        [Fact]

        public void Get_ReturnEntity_WhenEntityExist()
        {
            //Arrange
            var expected =DummyProfessors()[0];
            _sut.Setup(gr => gr.Get(expected.UserID)).Returns(expected);

            //Act
            var actual = _sut.Object.Get(expected.UserID);

            //Assert
            Assert.Equal(actual.UserID, expected.UserID);
            Assert.Equal(actual.FirstName, expected.FirstName);
        }
        [Fact]
        public void GetAll_ShouldReturnList_WhenListExists()
        {
            //Arrange
            var expectedList = DummyProfessors();
            _sut.Setup(s => s.GetAll()).Returns(expectedList);

            //Act
            var actualList = _sut.Object.GetAll();

            //Assert
            Assert.Equal(expectedList, actualList);

        }
        [Fact]
        public void Search_If_Filter_Not_Null()
        {
            List<Professor> expectedList = new List<Professor>
            {
                DummyProfessors()[0]
            };
            string filter = DummyProfessors()[0].FirstName;

            _sut.Setup(s => s.Search(filter)).Returns(expectedList);

            //Act

            var actualList = _sut.Object.Search(filter);

            //Assert

            Assert.Equal(expectedList, actualList);
        }

        [Fact]

        public void GetUserByCredentials_If_EmailAndPassword_Exist()
        {
            var expected = DummyProfessors()[1];
            string email = expected.Email;
            string password = expected.Password;
            
            _sut.Setup(gr => gr.GetUserByCredentials(email, password)).Returns(expected);

            var actual = _sut.Object.GetUserByCredentials(email, password);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ExportData_If_Professor_Exist()
        {
            var professor = DummyProfessors()[1];
            var expected = true;


            _sut.Setup(s => s.ExportData(professor)).Returns(expected);

            var actual = _sut.Object.ExportData(professor);

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
                Cabinet="100",
                Subject="P1",
                UserRoles = new List<UserRole>()

            };
            UserRole ur1 = new UserRole
            {
                UserID = cs1.UserID,
                RoleID = Guid.NewGuid()
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
                Subject="P2",
                Cabinet="103",
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

