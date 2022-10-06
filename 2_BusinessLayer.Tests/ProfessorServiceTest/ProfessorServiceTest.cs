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
        private readonly ProfessorService _sut;
        private readonly Mock<IGenericRepository<Professor>> _genericRepoMock = new Mock<IGenericRepository<Professor>>();
        public ProfessorServiceTest()
        {
            _sut = new ProfessorService(_genericRepoMock.Object);
        }
        [Fact]
        public void Add_When_Professor_Exists()
        {
            //Arrange
            var professor = DummyProfessors()[0];
            _genericRepoMock.Setup(gr => gr.Add(professor));

            //Act
            _sut.Add(professor);

            //Assert
            _genericRepoMock.Verify(m => m.Add(It.Is<Professor>(prof => prof.UserID == professor.UserID)));
        }
        [Fact]
        public void Delete_When_Professor_Exists()
        {
            Guid professorID = DummyProfessors()[0].UserID;
            _genericRepoMock.Setup(gr => gr.Delete(professorID));

            _sut.Delete(professorID);

            _genericRepoMock.Verify(gr => gr.Delete(professorID));
        }

        [Fact]
        public void Edit_When_Professor_Exists()
        {
            var professor = DummyProfessors()[0];
            _genericRepoMock.Setup(gr => gr.Edit(professor));

            _sut.Edit(professor);

            _genericRepoMock.Verify(gr => gr.Edit(professor));
        }

        [Fact]

        public void Get_ReturnProfessor_WhenProfessorExist()
        {
            //Arrange
            var professor = DummyProfessors()[0];
            Guid professorID = professor.UserID;
            _genericRepoMock.Setup(gr => gr.Get(professorID)).Returns(professor);

            //Act
            var prof = _sut.Get(professorID);

            //Assert
            Assert.Equal(prof.UserID, professor.UserID);
            Assert.Equal(prof.FirstName, professor.FirstName);
        }
        [Fact]
        public void GetAll_ShouldReturnList_WhenListExists()
        {
            //Arrange
            var expectedList = DummyProfessors();
            _genericRepoMock.Setup(gr => gr.GetAll()).Returns(expectedList);

            //Act
            var actualList = _sut.GetAll();

            //Assert
            Assert.Equal(expectedList, actualList);

        }

        [Fact]

        public void GetUserByCredentials_If_EmailAndPassword_Exist()
        {
            string email = "test@gmail.com";
            string password = "123";
            var expected = DummyProfessors()[1];
            _genericRepoMock.Setup(gr => gr.GetUserByCredentials(email, password)).Returns(expected);

            var actual = _sut.GetUserByCredentials(email, password);

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

