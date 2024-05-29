namespace SportsLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CauThu")]
    public partial class CauThu
    {
        [Key]
        public int MaCauThu { get; set; }

        [Required]
        [StringLength(100)]
        public string TenCauThu { get; set; }

        [StringLength(255)]
        public string Avatar { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        public int? ChieuCao { get; set; }

        [StringLength(50)]
        public string QuocTich { get; set; }

        [StringLength(50)]
        public string ViTriThiDau { get; set; }
    }
}
