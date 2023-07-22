using System;
using System.Collections.Generic;

namespace DMAWS_T2203E_ThangDo.Entities;

public partial class Project
{
    public int ProjectId { get; set; }

    public string? ProjectName { get; set; }

    public DateTime? ProjectStartDate { get; set; }

    public DateTime? ProjectEndDate { get; set; }
}
