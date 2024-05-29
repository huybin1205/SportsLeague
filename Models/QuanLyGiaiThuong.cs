namespace SportsLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuanLyGiaiThuong")]
    public partial class QuanLyGiaiThuong
    {
        [Key]
        public int MaGiaiThuong { get; set; }

        [Required]
        [StringLength(255)]
        public string TenGiaiThuong { get; set; }

        public int? MaGiaiDau { get; set; }

        public int? SoLuong { get; set; }

        public virtual QuanLyGiaiDau QuanLyGiaiDau { get; set; }
    }
}
