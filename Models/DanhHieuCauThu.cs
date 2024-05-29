using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SportsLeague.Models
{
    [Table("DanhHieuCauThu")]
    public class DanhHieuCauThu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? MaDanhHieuCauThu { get; set; }
        public int? MaLichThiDau { get; set; }
        public int? MaCauThu { get; set; }
        public int? MaLoaiGiaiThuong { get; set; }
        public int? SoLuong { get; set; }
    }

    public class DanhHieuCauThuView
    {
        public string Avatar { get; set; }
        public string TenCauThu { get; set; }
        public string TenDoiBong { get; set; }
        public string Logo { get; set; }
        public string TenLoaiGiaiThuong { get; set; }
        public int? MaLoaiGiaiThuong { get; set; }
        public int? TongSoLuong { get; set; }
    }
}