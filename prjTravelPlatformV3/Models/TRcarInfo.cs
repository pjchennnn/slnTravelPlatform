﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace prjTravelPlatformV3.Models;

public partial class TRcarInfo
{
    public int FCarId { get; set; }

    public string FLicensePlateNum { get; set; }

    public int? FModelId { get; set; }

    public bool? FRentStatus { get; set; }

    public int? FCompanyId { get; set; }

    public int? FLocationId { get; set; }

    public virtual TCcompanyInfo FCompany { get; set; }

    public virtual TRservicePoint FLocation { get; set; }

    public virtual TRcarModel FModel { get; set; }

    public virtual ICollection<TRcarRentOrderDetail> TRcarRentOrderDetails { get; set; } = new List<TRcarRentOrderDetail>();
}