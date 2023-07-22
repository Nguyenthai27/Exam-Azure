using System;
using System.Collections.Generic;

namespace DMAWS_T2203E_ThangDo.Entities;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public DateTime? EmployeeDob { get; set; }

    public string? EmployeeDepartment { get; set; }
}
