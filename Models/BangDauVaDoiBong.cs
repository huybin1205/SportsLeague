namespace SportsLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BangDauVaDoiBong")]
    public partial class BangDauVaDoiBong
    {
        [Key]
        public int MaBangDauVaDoiBong { get; set; }

        public int? MaBangDau { get; set; }

        public int? MaDoiBong { get; set; }
    }

    public class BangDauVaDoiBongViewModel
    {
        public int? MaGiaiDau { get; set; }
        public int? MaBangDau { get; set; }
        public string TenBangDau { get; set; }
        public int? MaDoiBong { get; set; }
        public string TenDoiBong { get; set; }
    }
}
