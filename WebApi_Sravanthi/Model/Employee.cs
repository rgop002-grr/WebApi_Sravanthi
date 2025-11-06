using System;
using System.Collections.Generic;

namespace WebApi_Sravanthi.Model;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? EmpName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? Id { get; set; }

    public virtual Role? IdNavigation { get; set; }
}
