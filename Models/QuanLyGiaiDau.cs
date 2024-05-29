namespace SportsLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuanLyGiaiDau")]
    public partial class QuanLyGiaiDau
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuanLyGiaiDau()
        {
            LichThiDaus = new HashSet<LichThiDau>();
            QuanLyGiaiThuongs = new HashSet<QuanLyGiaiThuong>();
        }

        [Key]
        public int MaGiaiDau { get; set; }

        [Required]
        [StringLength(255)]
        public string TenGiaiDau { get; set; }

        public int? NamThucHien { get; set; }

        [StringLength(100)]
        public string DonViToChuc { get; set; }

        public int? SoLuongDoiThamGia { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichThiDau> LichThiDaus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuanLyGiaiThuong> QuanLyGiaiThuongs { get; set; }
    }

    public class QuanLyGiaiDauView
    {
        public int MaGiaiDau { get; set; }

        public string TenGiaiDau { get; set; }

        public int? NamThucHien { get; set; }

        public string DonViToChuc { get; set; }

        public int? SoLuongDoiThamGia { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string ThoiGianToChuc
        {
            get
            {
                return (this.NgayBatDau.HasValue ? this.NgayBatDau.Value.ToString("dd/MM/yyyy") : "") + "-" + (this.NgayKetThuc.HasValue ? this.NgayKetThuc.Value.ToString("dd/MM/yyyy") : "");
            }
        }
    }
}
