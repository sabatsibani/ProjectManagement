using Moq;
using ProjectManagement.Api.Controllers;
using ProjectManagement.Data.Interfaces;
using System;
using Xunit;

namespace ProjectManagement.Api.Test
{
    public class TaskControllerTest
    {
        private FakeRepository<Entities.Task> fakeTaskRepository;
        Mock<IBaseRepository<Entities.Task>> mockTask;

        public TaskControllerTest()
        {
            mockTask = new Mock<IBaseRepository<Entities.Task>>();
            var testTasks1 = new Entities.Task { 
                ID = 1, 
                AssignedToUserID = 1, 
                ProjectID = 1, 
                Detail = "Test Task1", 
                CreatedOn = DateTime.Now, 
                Status = Entities.Enums.TaskStatus.New };
            mockTask.Object.Add(testTasks1);
        }

        [Fact]
        public void Get_Task_Test()
        {
            fakeTaskRepository = new FakeRepository<Entities.Task>();
            var testTasks1 = new Entities.Task { 
                ID = 1, 
                AssignedToUserID = 1, 
                ProjectID = 1, 
                Detail = "Test Task1", 
                CreatedOn = DateTime.Now, 
                Status = Entities.Enums.TaskStatus.New };
            var testTasks2 = new Entities.Task { 
                ID = 2, 
                AssignedToUserID = 1, 
                ProjectID = 1, 
                Detail = "Test Task2", 
                CreatedOn = DateTime.Now, 
                Status = Entities.Enums.TaskStatus.New };
            fakeTaskRepository.Add(testTasks1);
            fakeTaskRepository.Add(testTasks2);

            mockTask.Setup(m => m.Get()).Returns(fakeTaskRepository);
            TaskController tasksController = new TaskController(mockTask.Object);
            var result = tasksController.Get();
            Assert.NotNull(result);
        }
        [Fact]
        public void Get_Task_ById_Test()
        {
            var testTasks1 = new Entities.Task { 
                ID = 1, 
                AssignedToUserID = 1, 
                ProjectID = 1,
                Detail = "Test Task1", 
                CreatedOn = DateTime.Now, 
                Status = Entities.Enums.TaskStatus.New };

            mockTask.Setup(m => m.Get(1)).Returns(testTasks1);
            TaskController tasksController = new TaskController(mockTask.Object);
            var result = tasksController.Get(1);
            Assert.NotNull(result);
        }
    }
}
