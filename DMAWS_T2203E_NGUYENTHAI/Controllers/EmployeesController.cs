using Microsoft.AspNetCore.Mvc;
using DMAWS_T2203E_ThangDo.Entities;

namespace DMAWS_T2203E_ThangDo.Controllers
{
    [Route("api/ employees")]
    [ApiController]
    public class EmployeesController : Controller
    {

        private readonly ExamDmawsContext _context;
        public EmployeesController(ExamDmawsContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult index()
        {
            var employees = _context.Employees.ToList<Employee>();
    
            return Ok(employees);
        }

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult get(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Created($"/get-by-id?id={employee.EmployeeId}", employee);
        }

        [HttpPut]
        public IActionResult update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult delete(int id)
        {
            var delete = _context.Employees.Find(id);
            if (delete == null)
                return NotFound();
            _context.Employees.Remove(delete);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
