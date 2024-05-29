using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsLeague.Models
{
    public class BangXepHang
    {
        public int STT { get; set; }
        public string Logo { get; set; }
        public string TenDoiBong { get; set; }
        public int MaDoiBong { get; set; }
        public int SoTranDaThiDau { get; set; }
        public int Thang { get; set; }
        public int Thua { get; set; }
        public int Hoa { get; set; }
        public int BanThang { get; set; }
        public int SoBanThua { get; set; }
        public int HeSo { get; set; }
        public int Diem { get; set; }
        public double TiLeThang { 
            get {
                return Math.Round(this.Thang / (double)(this.Thang + this.Hoa + this.Thua) * 100, 0);
            }
        }
    }
}