using SportsLeague.Constants;
using SportsLeague.Models;
using SportsLeague.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsLeague.Controllers
{
    public class HomeController : Controller
    {
        private SportLeagueContext _dbContext;
        public ActionResult Index()
        {
            using (_dbContext = new SportLeagueContext())
            {
                if (Session["UserLogin"] != null)
                {
                    var user = Session["UserLogin"] as SportsLeague.Models.NguoiDung;
                    var phanQuyen = _dbContext.PhanQuyenNguoiDungs.FirstOrDefault(x => x.MaNguoiDung == user.MaNguoiDung);
                    if (phanQuyen != null)
                    {
                        if(phanQuyen.VaiTro.TenVaiTro != "Admin")
                        {
                            return RedirectToAction("CapNhat", "DoiBong", new { maDoiBong = phanQuyen.MaDoiBong, IsTeam = 1 });
                        }
                    }
                }

                var giaiDaus = _dbContext.QuanLyGiaiDaus.ToList();
                ViewBag.GiaiDau = giaiDaus.Count();
                ViewBag.DoiBong = _dbContext.DoiBongs.Count();
                ViewBag.CauThu = _dbContext.CauThus.Count();
                ViewBag.LichThiDau = _dbContext.LichThiDaus.Count();


                List<DoiBong> doiBongs = new List<DoiBong>();
                List<BangXepHang> TiLeThangs = new List<BangXepHang>();
                // Lặp qua từng giải đấu
                foreach (var giaiDau in giaiDaus)
                {
                    // Lấy ra đội bóng dẫn đầu
                    var bxh = LayBXH(giaiDau.MaGiaiDau).FirstOrDefault();
                    DoiBong doiBong = new DoiBong();
                    doiBong.Logo = bxh.Logo;
                    doiBong.TenDoiBong = bxh.TenDoiBong + " - " + giaiDau.TenGiaiDau + " - " + giaiDau.NamThucHien + " - " + giaiDau.DonViToChuc;
                    doiBong.NguoiQuanLyCLB = _dbContext.DoiBongs.FirstOrDefault(x => x.MaDoiBong == bxh.MaDoiBong)?.NguoiQuanLyCLB;
                    doiBongs.Add(doiBong);

                    // Lấy ra danh sách tỉ lệ thắng của các đội đứng đầu
                    TiLeThangs.Add(bxh);
                }

                // Lấy ra danh sách vua phá lưới của các giải
                var danhHieuCauThus = LayDanhHieu(ApplicationConstants.MA_LOAI_GIAI_THUONG_SO_BAN_THANG);

                // Hiển thị đội bóng dẫn đầu
                var doiBongDauTien = doiBongs.FirstOrDefault();
                doiBongs.RemoveAt(0);

                // Gắn ViewBag
                ViewBag.GiaiDaus = giaiDaus;
                ViewBag.DoiBongDauTien = doiBongDauTien;
                ViewBag.DoiBongs = doiBongs;
                // Lấy ra danh sách tỉ lệ thắng và sắp xếp giảm dần theo tỉ lệ thắng
                var tiLeThangs = TiLeThangs.Where(x => x != null).OrderByDescending(x => x.TiLeThang).Take(5).ToList();
                ViewBag.TiLeThangs = tiLeThangs;
                // Lấy ra danh sách danh hiệu của cầu thủ và sắp xếp giảm dần theo tổng số lượng
                ViewBag.DanhHieuCauThus = danhHieuCauThus.Where(x => x != null).OrderByDescending(x => x.TongSoLuong).Take(4).ToList();

            }
            return View();
        }

        public List<BangXepHang> LayBXH(int maGiaiDau)
        {
            using (SportLeagueContext _db = new SportLeagueContext())
            {
                // Lấy ra lịch thi đấu với cái giải đấu truyền vào 
                var lichThiDaus = _db.LichThiDaus.Where(x=>x.MaGiaiDau == maGiaiDau).ToList();

                // Lấy ra mã đội bóng có trong giải đấu
                var doiBongThiDauIDs = lichThiDaus.Where(x => x.MaGiaiDau == maGiaiDau)
                    .Select(x => x.MaCLBKhach).Distinct().ToList();

                var bxhs = new List<BangXepHang>();

                // Lặp qua từng lịch thi đấu
                foreach (var lichThiDau in lichThiDaus)
                {
                    // Lặp qua từng đội bóng
                    foreach (var doiBongThiDauID in doiBongThiDauIDs)
                    {
                        // Trường hợp: Đội chủ nhà
                        if (lichThiDau.MaCLBChuNha == doiBongThiDauID)
                        {
                            if (bxhs.Any(x => x.MaDoiBong == doiBongThiDauID)) // Đã tồn tài
                            {
                                BangXepHang bangXepHang = bxhs.FirstOrDefault(x => x.MaDoiBong == doiBongThiDauID);
                                bangXepHang.SoTranDaThiDau += 1;
                                if (lichThiDau.TiSoCLBChuNha > lichThiDau.TiSoCLBKhach)
                                {
                                    bangXepHang.Thang += 1;
                                }

                                if (lichThiDau.TiSoCLBChuNha < lichThiDau.TiSoCLBKhach)
                                {
                                    bangXepHang.Thua += 1;
                                }

                                if (lichThiDau.TiSoCLBChuNha == lichThiDau.TiSoCLBKhach)
                                {
                                    bangXepHang.Hoa += 1;
                                }

                                bangXepHang.BanThang += lichThiDau.TiSoCLBChuNha ?? 0;
                                bangXepHang.SoBanThua += lichThiDau.TiSoCLBKhach ?? 0;
                                bangXepHang.HeSo = bangXepHang.BanThang - bangXepHang.SoBanThua;
                                bangXepHang.Diem = bangXepHang.Thang * 3 + bangXepHang.Hoa * 1;
                            }
                            else // Chưa tồn tại
                            {
                                DoiBong doibong = _db.DoiBongs.FirstOrDefault(x => x.MaDoiBong == lichThiDau.MaCLBChuNha);
                                BangXepHang bangXepHang = new BangXepHang();
                                bangXepHang.Logo = doibong.Logo;
                                bangXepHang.TenDoiBong = doibong.TenDoiBong;
                                bangXepHang.SoTranDaThiDau = 1;
                                bangXepHang.MaDoiBong = doibong.MaDoiBong;

                                if (lichThiDau.TiSoCLBChuNha > lichThiDau.TiSoCLBKhach)
                                {
                                    bangXepHang.Thang += 1;
                                }

                                if (lichThiDau.TiSoCLBChuNha < lichThiDau.TiSoCLBKhach)
                                {
                                    bangXepHang.Thua += 1;
                                }

                                if (lichThiDau.TiSoCLBChuNha == lichThiDau.TiSoCLBKhach)
                                {
                                    bangXepHang.Hoa += 1;
                                }
                                bangXepHang.BanThang = lichThiDau.TiSoCLBChuNha ?? 0;
                                bangXepHang.SoBanThua = lichThiDau.TiSoCLBKhach ?? 0;
                                bangXepHang.HeSo = bangXepHang.BanThang - bangXepHang.SoBanThua;
                                bangXepHang.Diem = bangXepHang.Thang * 3 + bangXepHang.Hoa * 1;

                                bxhs.Add(bangXepHang);
                            }
                        }

                        if (lichThiDau.MaCLBKhach == doiBongThiDauID)
                        {
                            if (bxhs.Any(x => x.MaDoiBong == doiBongThiDauID)) // Đã tồn tài
                            {
                                // Tìm ra thằng cũ
                                BangXepHang bangXepHang = bxhs.FirstOrDefault(x => x.MaDoiBong == doiBongThiDauID);
                                bangXepHang.SoTranDaThiDau += 1;
                                if (lichThiDau.TiSoCLBKhach > lichThiDau.TiSoCLBChuNha)
                                {
                                    bangXepHang.Thang += 1;
                                }

                                if (lichThiDau.TiSoCLBKhach < lichThiDau.TiSoCLBChuNha)
                                {
                                    bangXepHang.Thua += 1;
                                }

                                if (lichThiDau.TiSoCLBKhach == lichThiDau.TiSoCLBChuNha)
                                {
                                    bangXepHang.Hoa += 1;
                                }

                                bangXepHang.BanThang += lichThiDau.TiSoCLBKhach ?? 0;
                                bangXepHang.SoBanThua += lichThiDau.TiSoCLBChuNha ?? 0;
                                bangXepHang.HeSo = bangXepHang.BanThang - bangXepHang.SoBanThua;
                                bangXepHang.Diem = bangXepHang.Thang * 3 + bangXepHang.Hoa * 1;
                            }
                            else // Chưa tồn tại
                            {
                                DoiBong doibong = _db.DoiBongs.FirstOrDefault(x => x.MaDoiBong == lichThiDau.MaCLBKhach);
                                // Tạo mới
                                BangXepHang bangXepHang = new BangXepHang();
                                bangXepHang.Logo = doibong.Logo;
                                bangXepHang.TenDoiBong = doibong.TenDoiBong;
                                bangXepHang.SoTranDaThiDau = 1;
                                bangXepHang.MaDoiBong = doibong.MaDoiBong;

                                if (lichThiDau.TiSoCLBKhach > lichThiDau.TiSoCLBChuNha)
                                {
                                    bangXepHang.Thang += 1;
                                    //bangXepHang.Thang = bangXepHang.Thang + 1;
                                }

                                if (lichThiDau.TiSoCLBKhach < lichThiDau.TiSoCLBChuNha)
                                {
                                    bangXepHang.Thua += 1;
                                }

                                if (lichThiDau.TiSoCLBKhach == lichThiDau.TiSoCLBChuNha)
                                {
                                    bangXepHang.Hoa += 1;
                                }
                                bangXepHang.BanThang = lichThiDau.TiSoCLBKhach ?? 0;
                                bangXepHang.SoBanThua = lichThiDau.TiSoCLBChuNha ?? 0;
                                bangXepHang.HeSo = bangXepHang.BanThang - bangXepHang.SoBanThua;
                                bangXepHang.Diem = bangXepHang.Thang * 3 + bangXepHang.Hoa * 1;

                                bxhs.Add(bangXepHang);
                            }
                        }
                    }
                }

                // Sắp xếp giảm dần (OrderByDescending) theo điểm
                bxhs = bxhs.OrderByDescending(x => x.Diem).ToList();
                int STT = 1;
                
                foreach (var bxh in bxhs)
                {
                    bxh.STT = STT;
                    STT++;
                }


                return bxhs;
            }
        }

        public List<DanhHieuCauThuView> LayDanhHieu(int maLoaiGiaiThuong)
        {
            using (SportLeagueContext _db = new SportLeagueContext())
            {
                var data = (from danhHieu in _db.DanhHieuCauThus

                            join lichDau in _db.LichThiDaus
                            on danhHieu.MaLichThiDau equals lichDau.MaLichThiDau

                            join cauThu in _db.CauThus
                            on danhHieu.MaCauThu equals cauThu.MaCauThu

                            join doiBongVaCauThu in _db.QuanLyDoiBongVaCauThus
                            on cauThu.MaCauThu equals doiBongVaCauThu.MaCauThu

                            join doiBong in _db.DoiBongs
                            on doiBongVaCauThu.MaDoiBong equals doiBong.MaDoiBong

                            select new
                            {
                                Avatar = cauThu.Avatar,
                                TenCauThu = cauThu.TenCauThu,
                                TenDoiBong = doiBong.TenDoiBong,
                                Logo = doiBong.Logo,
                                MaLoaiGiaiThuong = danhHieu.MaLoaiGiaiThuong,
                                SoLuong = danhHieu.SoLuong
                            }).ToList();

                var danhHieuCauThus = data.GroupBy(x => new { x.Avatar, x.TenCauThu, x.TenDoiBong, x.Logo, x.MaLoaiGiaiThuong })
                    .Select(x => new DanhHieuCauThuView
                    {
                        Avatar = x.Key.Avatar,
                        TenCauThu = x.Key.TenCauThu,
                        TenDoiBong = x.Key.TenDoiBong,
                        Logo = x.Key.Logo,
                        MaLoaiGiaiThuong = x.Key.MaLoaiGiaiThuong,
                        TongSoLuong = x.Sum(c => c.SoLuong)
                    }).Where(x=>x.MaLoaiGiaiThuong == maLoaiGiaiThuong).ToList();

                return danhHieuCauThus;
            }
        }
    }
}