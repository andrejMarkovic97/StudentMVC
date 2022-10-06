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

namespace _3_DataAccessLayer.Tests.RoleRepositoryTest
{
    public class RoleRepositoryTest
    {
        private readonly Mock<IGenericRepository<Role>> _sut;
        private readonly Mock<UserDBContext> _dbMock = new Mock<UserDBContext>();

        public RoleRepositoryTest()
        {

            _sut = new Mock<IGenericRepository<Role>>();
        }

        [Fact]
        public void Should_Add_Role_If_Role_Exists()
        {
            //Arrange
            var UserID = Guid.NewGuid();
            var role = DummyRoles()[0];
            _sut.Setup(s => s.Add(role)).Verifiable();

            //Act
            _sut.Object.Add(role);

            //Assert
            _sut.Verify(m => m.Add(It.Is<Role>(r => r.RoleID == role.RoleID)));


        }

        [Fact]
        public void Should_Delete_Role_If_Role_Exists()
        {
            var roleID = DummyRoles()[0].RoleID;
            _sut.Setup(s => s.Delete(roleID)).Verifiable();

            _sut.Object.Delete(roleID);

            _sut.Verify(s => s.Delete(roleID));
        }

        [Fact]

        public void Edit_If_Entity_Exists()
        {
            var entity = DummyRoles()[0];
            _sut.Setup(s => s.Edit(entity)).Verifiable();



            _sut.Object.Edit(entity);

            _sut.Verify(s => s.Edit(It.Is<Role>(e => e.RoleID == entity.RoleID)));


        }

        [Fact]

        public void GetAll_If_Entites_Exist()
        {
            var expectedList = DummyRoles();
            _sut.Setup(s => s.GetAll()).Returns(expectedList);

            var actualList = _sut.Object.GetAll();

            Assert.Equal(expectedList, actualList);

        }

        [Fact]
        public void Get_If_Entity_Exist()
        {
            var expected = DummyRoles()[0];
            _sut.Setup(s => s.Get(expected.RoleID)).Returns(expected);

            var actual = _sut.Object.Get(expected.RoleID);

            Assert.Equal(expected, actual);
        }

        [Fact]

       
        private List<Role> DummyRoles()
        {
            List<Role> list = new List<Role>();
            Role role1 = new Role()
            {
                RoleID = Guid.NewGuid(),
                RoleName = "Janitor",
                UserRoles = new List<UserRole>()
            };
            UserRole ur1 = new UserRole()
            {
                UserID = Guid.NewGuid(),
                RoleID = role1.RoleID
            };
            role1.UserRoles.Add(ur1);

            Role role2 = new Role()
            {
                RoleID = Guid.NewGuid(),
                RoleName = "Tester",
                UserRoles = new List<UserRole>()
            };
            UserRole ur2 = new UserRole()
            {
                UserID = Guid.NewGuid(),
                RoleID = role1.RoleID
            };
            role1.UserRoles.Add(ur1);
            list.Add(role1);
            list.Add(role2);
            return list;
        }
    }
}
