﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace prjTravelPlatformV3.Models;

public partial class TFclass
{
    public int FClassId { get; set; }

    public string FClass { get; set; }

    public virtual ICollection<TFflightSchedule> TFflightSchedules { get; set; } = new List<TFflightSchedule>();
}