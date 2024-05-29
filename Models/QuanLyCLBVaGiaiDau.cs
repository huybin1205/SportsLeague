﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SportsLeague.Models
{
    [Table("QuanLyCLBVaGiaiDau")]
    public class QuanLyCLBVaGiaiDau
    {
        [Key, Column(Order = 0)]
        public int MaGiaiDau { get; set; }
        [Key, Column(Order = 1)]
        public int MaCLB { get; set; }
    }
}