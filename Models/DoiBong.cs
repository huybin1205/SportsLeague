namespace SportsLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DoiBong")]
    public partial class DoiBong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DoiBong()
        {
            LichThiDaus = new HashSet<LichThiDau>();
        }

        [Key]
        public int MaDoiBong { get; set; }

        [Required]
        [StringLength(100)]
        public string TenDoiBong { get; set; }

        [StringLength(255)]
        public string Logo { get; set; }

        [StringLength(100)]
        public string NguoiQuanLyCLB { get; set; }

        [StringLength(50)]
        public string DoiTruong { get; set; }

        [StringLength(50)]
        public string ViTri { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichThiDau> LichThiDaus { get; set; }
    }

    public class DoiBongViewModel
    {
        public string Logo { get; set; }
        public string TenDoiBong { get; set; }
        public int MaDoiBong { get; set; }
        public string NguoiQuanLyCLB { get; set; }
    }
}
