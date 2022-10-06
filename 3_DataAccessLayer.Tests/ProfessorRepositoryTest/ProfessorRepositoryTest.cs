using _3_DataAccess;
using _3_DataAccess.Repository;
using _3_DataAccess.StudentRepository;
using _4_BusinessObjectModel.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _3_DataAccessLayer.Tests.ProfessorRepositoryTest
{
    public class ProfessorRepositoryTest
    {
        private readonly Mock<IGenericRepository<Professor>> _sut;
        private readonly Mock<UserDBContext> _dbMock = new Mock<UserDBContext>();

        public ProfessorRepositoryTest()
        {

            _sut = new Mock<IGenericRepository<Professor>>();
        }

        [Fact]
        public void Should_Add_Professor_If_Professor_Exists()
        {
            //Arrange
            var UserID = Guid.NewGuid();
            Professor professor = DummyProfessors()[0];
            _sut.Setup(s => s.Add(professor)).Verifiable();

            //Act
            _sut.Object.Add(professor);

            //Assert
            _sut.Verify(m => m.Add(It.Is<Professor>(prof => prof.UserID == professor.UserID)));


        }

        [Fact]
        public void Should_Delete_Professor_If_Professor_Exists()
        {
            var userID = DummyProfessors()[0].UserID;
            _sut.Setup(s => s.Delete(userID)).Verifiable();

            _sut.Object.Delete(userID);

            _sut.Verify(s => s.Delete(userID));
        }

        [Fact]

        public void Edit_If_Entity_Exists()
        {
            var entity = DummyProfessors()[0];
            _sut.Setup(s => s.Edit(entity)).Verifiable();



            _sut.Object.Edit(entity);

            _sut.Verify(s => s.Edit(It.Is<Professor>(e => e.UserID == entity.UserID)));


        }

        [Fact]

        public void GetAll_If_Entites_Exist()
        {
            var expectedList = DummyProfessors();
            _sut.Setup(s => s.GetAll()).Returns(expectedList);

            var actualList = _sut.Object.GetAll();

            Assert.Equal(expectedList, actualList);

        }

        [Fact]
        public void Get_If_Entity_Exist()
        {
            var expected = DummyProfessors()[0];
            _sut.Setup(s => s.Get(expected.UserID)).Returns(expected);

            var actual = _sut.Object.Get(expected.UserID);

            Assert.Equal(expected, actual);
        }

        [Fact]

        public void GetUserByCredentials_If_User_Exists()
        {
            var expected = DummyProfessors()[0];
            _sut.Setup(s => s.GetUserByCredentials(expected.Email, expected.Password)).Returns(expected);

            var actual = _sut.Object.GetUserByCredentials(expected.Email, expected.Password);

            Assert.Equal(expected, actual);


        }
        [Fact]
        public void Search_If_Filter_Exists()
        {
            List<Professor> expected = new List<Professor>();
            expected.Add(DummyProfessors()[0]);
            string filter = expected[0].FirstName;

            _sut.Setup(s => s.Search(filter)).Returns(expected);

            var actual = _sut.Object.Search(filter);

            Assert.Equal(expected, actual);
        
        }

        private List<Professor> DummyProfessors()
        {
            List<Professor> list = new List<Professor>();

            var prof1 = new Professor
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
                UserID = prof1.UserID,
                RoleID = Guid.NewGuid()
            };
            prof1.UserRoles.Add(ur1);

            var prof2 = new Professor
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
                UserID = prof2.UserID,
                RoleID = Guid.NewGuid()
            };
            prof2.UserRoles.Add(ur2);

            list.Add(prof1);
            list.Add(prof2);
            return list;


        }

    }

   
}
