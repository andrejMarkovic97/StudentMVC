using _2_BusinessLayer.RoleServices;
using _3_DataAccess.Repository;
using _4_BusinessObjectModel.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _2_BusinessLayer.Tests.RoleServiceTest
{
    public class RoleServiceTest
    {
        private readonly RoleService _sut;
        private readonly Mock<IGenericRepository<Role>> _genericRepoMock = new Mock<IGenericRepository<Role>>();
        public RoleServiceTest()
        {
            _sut = new RoleService(_genericRepoMock.Object);
        }
        [Fact]
        public void Add_When_Role_Exists()
        {
            //Arrange
            var role = DummyRoles()[0];
            _genericRepoMock.Setup(gr => gr.Add(role));

            //Act
            _sut.Add(role);

            //Assert
            _genericRepoMock.Verify(m => m.Add(It.Is<Role>(r=> r.RoleID == role.RoleID)));
        }
        [Fact]
        public void Delete_When_Role_Exists()
        {
            Guid roleID = DummyRoles()[0].RoleID;
            _genericRepoMock.Setup(gr => gr.Delete(roleID));

            _sut.Delete(roleID);

            _genericRepoMock.Verify(gr => gr.Delete(roleID));
        }

        [Fact]
        public void Edit_When_Role_Exists()
        {
            var role = DummyRoles()[0];
            _genericRepoMock.Setup(gr => gr.Edit(role));

            _sut.Edit(role);

            _genericRepoMock.Verify(gr => gr.Edit(role));
        }

        [Fact]

        public void Get_ReturnRole_WhenRoleExist()
        {
            //Arrange
            var expectedRole = DummyRoles()[1];
            var roleID = expectedRole.RoleID;
            _genericRepoMock.Setup(gr => gr.Get(roleID)).Returns(expectedRole);

            //Act
            var actualRole = _sut.Get(roleID);

            //Assert
            Assert.Equal(expectedRole.RoleID, actualRole.RoleID);
        }
        [Fact]
        public void GetAll_ShouldReturnList_WhenListExists()
        {
            //Arrange
            var expectedList = DummyRoles();
            _genericRepoMock.Setup(gr => gr.GetAll()).Returns(expectedList);

            //Act
            var actualList = _sut.GetAll();

            //Assert
            Assert.Equal(expectedList, actualList);

        }

       
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
