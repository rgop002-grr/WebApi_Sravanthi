using Microsoft.AspNetCore.Mvc;
using WebApi_Sravanthi.Model;

namespace WebApi_Sravanthi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, EmpName = "Sravanthi" },
            new Employee { Id = 2, EmpName = "Rani" }
        };

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var emp = employees.FirstOrDefault(x => x.Id == id);
            if (emp == null) return NotFound("Employee not found");
            return Ok(emp);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Employee emp)
        {
            emp.Id = employees.Count + 1;
            employees.Add(emp);
            return Ok("Employee Added Successfully");
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] Employee emp)
        {
            var existing = employees.FirstOrDefault(x => x.Id == id);
            if (existing == null) return NotFound("Not found");

            existing.EmpName = emp.EmpName;
            return Ok("Employee Updated");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var existing = employees.FirstOrDefault(x => x.Id == id);
            if (existing == null) return NotFound("Not found");

            employees.Remove(existing);
            return Ok("Employee Deleted");
        }
    }
}


