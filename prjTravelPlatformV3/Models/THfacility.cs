﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace prjTravelPlatformV3.Models;

public partial class THfacility
{
    public int FHotelFacilityId { get; set; }

    public string FHotelFacilityName { get; set; }

    public virtual ICollection<THfacilityRelation> THfacilityRelations { get; set; } = new List<THfacilityRelation>();
}