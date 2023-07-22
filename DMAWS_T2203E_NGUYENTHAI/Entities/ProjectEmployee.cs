using System;
using System.Collections.Generic;

namespace DMAWS_T2203E_ThangDo.Entities;

public partial class ProjectEmployee
{
    public int? EmployeeId { get; set; }

    public int? ProjectId { get; set; }

    public string? Tasks { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Project? Project { get; set; }
}
