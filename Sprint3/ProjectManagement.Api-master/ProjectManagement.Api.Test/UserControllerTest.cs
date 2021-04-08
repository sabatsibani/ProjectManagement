using Moq;
using ProjectManagement.Api.Controllers;
using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using Xunit;

namespace ProjectManagement.Api.Test
{
    public class UserControllerTest
    {
        private FakeRepository<User> fakeUserRepository;
        Mock<IBaseRepository<User>> mockUser;

        public UserControllerTest()
        {
            mockUser = new Mock<IBaseRepository<User>>();
        }

        [Fact]
        public void Get_All_Users_Test()
        {
            fakeUserRepository = new FakeRepository<User>();
            User testUser1 = new User
            {
                ID = 3,
                FirstName = "Mark",
                LastName = "Seeman",
                Username = "mark.seeman",
            };
            fakeUserRepository.Add(testUser1);
            User testUser2 = new User
            {
                ID = 4,
                FirstName = "Bob",
                LastName = "Martin",
                Username = "bob.martin",
            };
            fakeUserRepository.Add(testUser2);

            mockUser.Setup(m => m.Get()).Returns(fakeUserRepository);
            UserController userController = new UserController(mockUser.Object);
            var result = userController.Get();
            Assert.NotNull(result);
        }
        [Fact]
        public void Get_User_ById_Test()
        {
            var testUser1 = new User
            {
                ID = 4,
                FirstName = "Bob",
                LastName = "Martin",
                Username = "bob.martin",
            };

            mockUser.Setup(m => m.Get(1)).Returns(testUser1);
            UserController userController = new UserController(mockUser.Object);
            var result = userController.Get(4);
            Assert.NotNull(result);
        }
    }
}
