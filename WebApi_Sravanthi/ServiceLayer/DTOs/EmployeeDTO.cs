
namespace WebApi_Sravanthi.ServiceLayer.DTOs
{
    public class EmployeeDTO
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }  // ✅ Add this
        public int? Id { get; set; }
    }
}


