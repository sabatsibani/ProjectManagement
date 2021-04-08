using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Api.Controllers
{
    [ApiController]
    [Route("api/Task")]
    public class TaskController : BaseController<Task>
    {
        private static List<Entities.Task> tasksList = new List<Entities.Task>();
        public TaskController(IBaseRepository<Entities.Task> baseRepository) : base(baseRepository)
        {

        }
        [HttpGet]
        public ActionResult<IEnumerable<Entities.Task>> GetAllTasks()
        {
            return tasksList;
        }

        [HttpGet("{id}")]
        public ActionResult<Entities.Task> GetTaskById(int id)
        {
            var task = tasksList.Find(p => p.ID == id);
            if (task == null)
            {
                return NotFound();
            }
            return task;
        }

        [HttpPost]
        public ActionResult CreateTask([FromBody] Entities.Task task)
        {
            if (tasksList.Exists(p => p.ID == task.ID))
            {
                return Conflict();
            }
            tasksList.Add(task);
            return CreatedAtAction(nameof(Get), new { id = task.ID }, tasksList);
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Entities.Task>> DeleteTask(int id)
        {
            var task = tasksList.Where(p => p.ID == id);
            if (task == null)
            {
                return NotFound();
            }
            tasksList = tasksList.Except(task).ToList();
            return tasksList;
        }

        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Entities.Task>> UpdateTask(int id, [FromBody] Entities.Task task)
        {
            if (id != task.ID)
            {
                return BadRequest();
            }
            var existingTask = tasksList.Where(p => p.ID == id);
            tasksList = tasksList.Except(existingTask).ToList();
            tasksList.Add(task);
            return tasksList;
        }
    }
}
