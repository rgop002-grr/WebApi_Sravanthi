using System.Collections.Generic;
using System.Linq;
using WebApi_Sravanthi.DataAccessLayer;
using WebApi_Sravanthi.Model;

namespace WebApi_Sravanthi.DataAccessLayer
{
     public class EmployeeRepository
        {
            private readonly OfficeDbContext _context;

            public EmployeeRepository(OfficeDbContext context)
            {
                _context = context;
            }

            public IEnumerable<Employee> GetAll()
            {
                return _context.Employees.ToList();
            }

            public Employee GetById(int id)
            {
                return _context.Employees.FirstOrDefault(e => e.EmpId == id);
            }

            public void Add(Employee emp)
            {
                _context.Employees.Add(emp);
                _context.SaveChanges();
            }

            public void Update(Employee emp)
            {
                _context.Employees.Update(emp);
                _context.SaveChanges();
            }

            public void Delete(int id)
            {
                var emp = _context.Employees.FirstOrDefault(e => e.EmpId == id);
                if (emp != null)
                {
                    _context.Employees.Remove(emp);
                    _context.SaveChanges();
                }
            }
        }
    }