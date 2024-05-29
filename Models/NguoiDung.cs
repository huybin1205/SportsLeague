namespace SportsLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            PhanQuyenNguoiDungs = new HashSet<PhanQuyenNguoiDung>();
        }

        [Key]
        public int MaNguoiDung { get; set; }

        [Required]
        [StringLength(255)]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(255)]
        public string MatKhau { get; set; }

        [StringLength(50)]
        public string Ho { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(15)]
        public string SoDienThoai { get; set; }
        public string Avatar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanQuyenNguoiDung> PhanQuyenNguoiDungs { get; set; }
    }
}
