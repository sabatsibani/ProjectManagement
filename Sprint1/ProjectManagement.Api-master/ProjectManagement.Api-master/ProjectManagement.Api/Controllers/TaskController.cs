using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Api.Controllers
{
    [ApiController]
    [Route("api/Task")]
    public class TaskController : BaseController<Task>
    {
        private static List<Task> tasks = new List<Task>();
        [HttpGet]
        public ActionResult<IEnumerable<Task>> GetAllTasks()
        {
            return tasks;
        }

        [HttpGet("{id}")]
        public ActionResult<Task> GetTaskById(int id)
        {
            var task = tasks.Find(p => p.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return task;
        }

        [HttpPost]
        public ActionResult CreateTask([FromBody] Task task)
        {
            if (tasks.Exists(p => p.Id == task.Id))
            {
                return Conflict();
            }
            tasks.Add(task);
            return CreatedAtAction(nameof(Get), new { id = task.Id }, tasks);
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Task>> DeleteTask(int id)
        {
            var task = tasks.Where(p => p.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            tasks = tasks.Except(task).ToList();
            return tasks;
        }

        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Task>> UpdateTask(int id, [FromBody] Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }
            var existingTask = tasks.Where(p => p.Id == id);
            tasks = tasks.Except(existingTask).ToList();
            tasks.Add(task);
            return tasks;
        }
    }
}
