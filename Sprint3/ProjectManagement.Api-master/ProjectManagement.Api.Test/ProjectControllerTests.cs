using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using ProjectManagement.Api.Controllers;
using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using System;
using Xunit;
using Xunit.Abstractions;

namespace ProjectManagement.Api.Test
{
    public class ProjectControllerTests : DisposableAppTestBase<ProjectManagement.Api.Startup>
    {
        private const string BaseAddress = "http://localhost/api/ProjectManagement";
        private static readonly WebApplicationFactoryClientOptions HttpClientOptions =
            new WebApplicationFactoryClientOptions() { BaseAddress = new Uri(BaseAddress) };
        private FakeRepository<Project> fakeProject;
        Mock<IBaseRepository<Project>> mockProject;

        //public ProjectControllerTests(SutFactory sutFactory,ITestOutputHelper testOutput):base(sutFactory,testOutput)
        //{

        //}

        protected override void ConfigureTestServices(IServiceCollection services, ITestOutputHelper testOutput)
        {
            base.ConfigureTestServices(services, testOutput);
            //services.AddSingleton<FakeProjectRepository>(_fakeProjectRepository);
        }

        public ProjectControllerTests()
        {
            mockProject = new Mock<IBaseRepository<Project>>();
            var testProject1 = new Project
            {
                ID = 10,
                Name = "Project1",
                CreatedOn = DateTime.Now,
                Detail = "This is project1"
            };
            mockProject.Object.Add(testProject1);
        }

        [Fact]
        public void GetProject_Test_ReturnSuccess()
        {
            fakeProject = new FakeRepository<Project>();
            var testProject1 = new Project
            {
                Name = "Project1",
                CreatedOn = DateTime.Now,
                Detail = "This is project1"
            };
            var testProject2 = new Project
            {
                Name = "Project2",
                CreatedOn = DateTime.Now,
                Detail = "This is project2"
            };
            fakeProject.Add(testProject1);
            fakeProject.Add(testProject2);

            mockProject.Setup(m => m.Get()).Returns(fakeProject);
            ProjectController projectController = new ProjectController(mockProject.Object);
            var result = projectController.Get();
            Assert.NotNull(result);
        }
        [Fact]
        public void Get_Project_ById_Test_Return_Success()
        {
            var testProject1 = new Project
            {
                ID = 1,
                Name = "Project1",
                CreatedOn = DateTime.Now,
                Detail = "This is project1"
            };

            mockProject.Setup(m => m.Get(1)).Returns(testProject1);
            ProjectController projectController = new ProjectController(mockProject.Object);
            var result = projectController.Get(1);
            Assert.NotNull(result);
        }

    }
}
