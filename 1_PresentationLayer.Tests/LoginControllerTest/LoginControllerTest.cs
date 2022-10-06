using _1_PresentationLayer.ApplicationService.UserAppService;
using _1_PresentationLayer.Controllers;
using _1_PresentationLayer.ViewModels;
using _4_BusinessObjectModel.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _1_PresentationLayer.Tests.LoginControllerTest
{
    public class LoginControllerTest
    {
        private readonly LoginController _sut;
        private readonly Mock<IUserAppService<UserViewModel, User>> _appServiceMock = new Mock<IUserAppService<UserViewModel, User>>();

        public LoginControllerTest()
        {
            _sut = new LoginController(_appServiceMock.Object);
        }

        public void Login_If_User_Exists()
        {
            //Arrange
            var userLoggingIn = new UserViewModel()
            {
                
                Email = "test@gmail.com",
                Password = "123"

            };

            var expectedUser = new UserViewModel()
            {
                UserID = Guid.NewGuid(),
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Email = "test@gmail.com",
                PhoneNumber = "TestPhone",
                Adress = "TestAdress",
                BirthDate = DateTime.Parse("01/01/1990"),
                Password = "123",
                UserRoles = new List<UserRole>()
            };
            Role role = new Role()
            {
                RoleID = Guid.NewGuid(),
                RoleName = "TestRole",
                UserRoles = new List<UserRole>()
            };
            UserRole ur = new UserRole()
            {
                Role = role,
                RoleID = role.RoleID,
                
                UserID = expectedUser.UserID

            };
            role.UserRoles.Add(ur);
            expectedUser.UserRoles.Add(ur);

            //Act
            _appServiceMock.Setup(m => m.GetUserByCredentials(userLoggingIn.Email, userLoggingIn.Password)).Returns(expectedUser);
            var result = _sut.Login(userLoggingIn);

            //Act
            var actualUser = _sut.Login(userLoggingIn);
            var 

            
        }
    }
}
