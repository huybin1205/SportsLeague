namespace SportsLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BangDau")]
    public partial class BangDau
    {
        [Key]
        public int MaBangDau { get; set; }

        [StringLength(100)]
        public string TenBangDau { get; set; }

        public int? MaGiaiDau { get; set; }
    }

    public class BangDauViewModel
    {
        public int? MaBangDau { get; set; }
        public string TenBangDau { get; set; }
        public List<DoiBong> DoiBongs { get; set; }
    }
}
