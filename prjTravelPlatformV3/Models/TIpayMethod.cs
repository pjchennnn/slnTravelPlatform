﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace prjTravelPlatformV3.Models;

public partial class TIpayMethod
{
    public int FPayId { get; set; }

    public string FPayment { get; set; }

    public virtual ICollection<TIorder> TIorders { get; set; } = new List<TIorder>();
}