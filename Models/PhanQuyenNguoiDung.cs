namespace SportsLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanQuyenNguoiDung")]
    public partial class PhanQuyenNguoiDung
    {
        [Key]
        public int MaPhanQuyen { get; set; }

        public int? MaNguoiDung { get; set; }

        public int? MaVaiTro { get; set; }

        public int? MaDoiBong { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual VaiTro VaiTro { get; set; }
    }
}
