using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SportsLeague.Models
{
    [Table("LoaiGiaiThuong")]
    public class LoaiGiaiThuong
    {
        [Key]
        public int MaLoaiGiaiThuong { get; set; }
        public string TenLoaiGiaiThuong { get; set; }
      
    }
}