using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SportsLeague.Models
{
    [Table("QuanLyDoiBongVaCauThu")]
    public class QuanLyDoiBongVaCauThu
    {
        [Key, Column(Order = 0)]
        public int MaDoiBong { get; set; }
        
        [Key, Column(Order = 1)]
        public int MaCauThu { get; set; }

        public int SoAo { get; set; }
    }
}