using WebApi_Sravanthi.DataAccessLayer;
using WebApi_Sravanthi.Model;
using WebApi_Sravanthi.ServiceLayer.DTOs;

namespace WebApi_Sravanthi.ServiceLayer
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _repo;

        public EmployeeService(EmployeeRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            var employees = _repo.GetAll();

            return employees.Select(e => new EmployeeDTO
            {
                EmpId = e.EmpId,
                EmpName = e.EmpName,
                Email = e.Email,
                Id = e.Id
            }).ToList();
        }

        public void AddEmployee(EmployeeDTO empDto)
        {
            var emp = new Employee
            {
                EmpName = empDto.EmpName,
                Email = empDto.Email,
                Password = empDto.Password,
                Id = empDto.Id
            };

            _repo.Add(emp);
        }

        public void UpdateEmployee(Employee emp)
        {
            _repo.Update(emp);
        }

        public void DeleteEmployee(int id)
        {
            _repo.Delete(id);
        }

        public EmployeeDTO? GetEmployeeById(int id)
        {
            var e = _repo.GetById(id);
            if (e == null) return null;

            return new EmployeeDTO
            {
                EmpId = e.EmpId,
                EmpName = e.EmpName,
                Email = e.Email,
                Id = e.Id
            };
        }
    }
}
