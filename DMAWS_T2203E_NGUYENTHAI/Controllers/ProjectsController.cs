using DMAWS_T2203E_ThangDo.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DMAWS_T2203E_ThangDo.Controllers
{
    [Route("api/ projects")]
    [ApiController]
    public class ProjectsController : Controller
    {
        private readonly ExamDmawsContext _context;
        public ProjectsController(ExamDmawsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult index()
        {
            var projects = _context.Projects.ToList<Project>();

            return Ok(projects);
        }

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult get(int id)
        {
            var project = _context.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public IActionResult create(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            return Created($"/get-by-id?id={project.ProjectId}", project);
        }

        [HttpPut]
        public IActionResult update(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult delete(int id)
        {
            var delete = _context.Projects.Find(id);
            if (delete == null)
                return NotFound();
            _context.Projects.Remove(delete);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
