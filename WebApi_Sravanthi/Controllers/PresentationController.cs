using Microsoft.AspNetCore.Mvc;
using WebApi_Sravanthi.Model;
using WebApi_Sravanthi.ServiceLayer;
using WebApi_Sravanthi.ServiceLayer.DTOs;

namespace WebApi_Sravanthi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentationController : ControllerBase
    {
        private readonly EmployeeService _service;

        public PresentationController(EmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _service.GetEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var emp = _service.GetEmployeeById(id);
            if (emp == null)
                return NotFound();

            return Ok(emp);
        }

        [HttpPost]
        public IActionResult Create([FromBody] EmployeeDTO empDto)
        {
            _service.AddEmployee(empDto);
            return Ok("Employee added successfully");
        }

        [HttpPut]
        public IActionResult Update(Employee emp)
        {
            _service.UpdateEmployee(emp);
            return Ok("Employee updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteEmployee(id);
            return Ok("Employee deleted successfully");
        }
    }
}