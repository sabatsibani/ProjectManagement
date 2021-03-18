using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Api.Controllers
{
    [ApiController]
    [Route("api/Project")]
    public class ProjectController : BaseController<Project>
    {
        private static List<Project> projects = new List<Project>()
        {
            new Project
            {
                ID=1,
                Name= "TestProject1",
                Detail="This is Test Project 1",
                CreatedOn= System.DateTime.Now, 
            },
             new Project
            {
                ID=2,
                Name= "TestProject2",
                Detail="This is Test Project 2",
                CreatedOn= System.DateTime.Now,

            },
              new Project
            {
                ID=3,
                Name= "TestProject3",
                Detail="This is Test Project 3",
                CreatedOn= System.DateTime.Now,

            },
               new Project
            {
                ID=4,
                Name= "TestProject4",
                Detail="This is Test Project 4",
                CreatedOn= System.DateTime.Now,

            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Project>> GetAllProjects()
        {
            return projects;
        }

        [HttpGet("{id}")]
        public ActionResult<Project> GetProjectById(int id)
        {
            var project = projects.Find(p => p.ID == id);
            if (project == null)
            {
                return NotFound();
            }
            return project;
        }

        [HttpPost]
        public ActionResult CreateProject([FromBody] Project project)
        {
            if (projects.Exists(p => p.ID == project.ID))
            {
                return Conflict();
            }
            projects.Add(project);
            return CreatedAtAction(nameof(Get), new { id = project.ID }, projects);
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Project>> DeleteProject(int id)
        {
            var project = projects.Where(p => p.ID == id);
            if (project == null)
            {
                return NotFound();
            }
            projects = projects.Except(project).ToList();
            return projects;
        }

        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Project>> UpdateProject(int id, [FromBody] Project project)
        {
            if (id != project.ID)
            {
                return BadRequest();
            }
            var existingProject = projects.Where(p => p.ID == id);
            projects = projects.Except(existingProject).ToList();
            projects.Add(project);
            return projects;
        }
    }
}
