namespace SportsLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichThiDau")]
    public partial class LichThiDau
    {
        [Key]
        public int MaLichThiDau { get; set; }

        public int? MaGiaiDau { get; set; }

        public DateTime? NgayThiDau { get; set; }

        [StringLength(50)]
        public string VongThiDau { get; set; }

        [StringLength(100)]
        public string SanThiDau { get; set; }

        public int? MaCLBChuNha { get; set; }

        public int? MaCLBKhach { get; set; }

        public int? TiSoCLBChuNha { get; set; }

        public int? TiSoCLBKhach { get; set; }

        public int? SoCuSut { get; set; }

        public int? SutTrungDich { get; set; }

        public int? SoLuongPenalties { get; set; }

        public int? SoLuongDaPhat { get; set; }

        public int? SoLuongPhatGoc { get; set; }

        public int? SoLuongPhamLoi { get; set; }

        public int? SoLuongVietVi { get; set; }

        public int? SoTheVang { get; set; }

        public int? SoTheDo { get; set; }

        [StringLength(10)]
        public string BuGio { get; set; }

        [StringLength(255)]
        public string KetQuaLuanLuu { get; set; }

        public virtual DoiBong DoiBong { get; set; }

        public virtual QuanLyGiaiDau QuanLyGiaiDau { get; set; }
    }
}
