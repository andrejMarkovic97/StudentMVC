using _2_BusinessLayer.GenericService;
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
        private readonly Mock<IGenericService<Role>> _sut;
       
        public RoleServiceTest()
        {
            _sut = new Mock<IGenericService<Role>>(); 
        }
        [Fact]
        public void Add_When_Entity_Exists()
        {
            //Arrange
            var entity = DummyRoles()[0];
            _sut.Setup(gr => gr.Add(entity)).Verifiable();

            //Act
            _sut.Object.Add(entity);

            //Assert
            _sut.Verify(m => m.Add(It.Is<Role>(cs => cs.RoleID == entity.RoleID)));
        }
        [Fact]
        public void Delete_When_Entity_Exists()
        {
            Guid roleID = DummyRoles()[0].RoleID;
            _sut.Setup(gr => gr.Delete(roleID)).Verifiable();

            _sut.Object.Delete(roleID);

            _sut.Verify(gr => gr.Delete(roleID));
        }

        [Fact]
        public void Edit_When_Entity_Exists()
        {
            var role = DummyRoles()[0];
            _sut.Setup(gr => gr.Edit(role)).Verifiable();

            _sut.Object.Edit(role);

            _sut.Verify(gr => gr.Edit(role));
        }

        [Fact]

        public void Get_ReturnEntity_WhenEntityExist()
        {
            //Arrange
            var expected = DummyRoles()[0];
            _sut.Setup(gr => gr.Get(expected.RoleID)).Returns(expected);

            //Act
            var actual = _sut.Object.Get(expected.RoleID);

            //Assert
            Assert.Equal(actual, expected);
           
        }
        [Fact]
        public void GetAll_ShouldReturnList_WhenListExists()
        {
            //Arrange
            var expectedList = DummyRoles();
            _sut.Setup(s => s.GetAll()).Returns(expectedList);

            //Act
            var actualList = _sut.Object.GetAll();

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
