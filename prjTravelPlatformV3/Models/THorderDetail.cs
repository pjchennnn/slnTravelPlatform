﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace prjTravelPlatformV3.Models;

public partial class THorderDetail
{
    public int FHotelOrderDetailId { get; set; }

    public string FHotelOrderId { get; set; }

    public int FRoomId { get; set; }

    public virtual THorder FHotelOrder { get; set; }

    public virtual THroom FRoom { get; set; }
}