using SportsLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Reflection;
using System.Data;
using System.IO;
using Microsoft.Ajax.Utilities;
using OfficeOpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using OfficeOpenXml.Style;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.EMMA;

namespace SportsLeague.Controllers
{
    public class LichThiDauController : Controller
    {
        // GET: LichThiDau
        private SportLeagueContext _db;


        public ActionResult CheckLogin()
        {
            if (Session != null)
            {
                var user = Session["UserLogin"] as SportsLeague.Models.NguoiDung;
                if (user == null)
                {
                    return Redirect("/NguoiDung/Login");
                }

                using (var _dbContext = new SportLeagueContext())
                {
                    var phanQuyen = _dbContext.PhanQuyenNguoiDungs.FirstOrDefault(x => x.MaNguoiDung == user.MaNguoiDung);

                    // Kiểm tra quyền của người dùng
                    if (phanQuyen != null)
                    {
                        if (phanQuyen.VaiTro.TenVaiTro != "Admin")
                        {
                            // Nếu không phải là Admin, chuyển hướng đến trang cập nhật đội bóng
                            return Redirect("/DoiBong/CapNhat?maDoiBong=" + phanQuyen.MaDoiBong + "&IsTeam=1");
                        }
                    }
                }
            }

            return null; // Đăng nhập hợp lệ, không cần chuyển hướng
        }
        public ActionResult Index()
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            return View();
        }
        public ActionResult GetData()
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {
                var list = from lichThiDau in _db.LichThiDaus

                           join giaiDau in _db.QuanLyGiaiDaus on lichThiDau.MaGiaiDau equals giaiDau.MaGiaiDau

                           join doiBongChuNha in _db.DoiBongs on lichThiDau.MaCLBChuNha equals doiBongChuNha.MaDoiBong

                           join doiBongKhach in _db.DoiBongs on lichThiDau.MaCLBKhach equals doiBongKhach.MaDoiBong

                           select new
                           {
                               MaLichThiDau=lichThiDau.MaLichThiDau,
                               TenGiaiDau = giaiDau.TenGiaiDau,
                               NgayThiDau = lichThiDau.NgayThiDau.ToString(),
                               VongThiDau = lichThiDau.VongThiDau,
                               SanThiDau = lichThiDau.SanThiDau,
                               TenDoiBongChuNha = doiBongChuNha.TenDoiBong,
                               TiSo = lichThiDau.TiSoCLBChuNha + " - " + lichThiDau.TiSoCLBKhach,
                               TenDoiBongKhach = doiBongKhach.TenDoiBong,
                           };
                return Json(new { data = list.ToList() }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetDataHome(int maGiaiDau, DateTime? ngayThiDau)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {
                var list = (from lichThiDau in _db.LichThiDaus
                            join giaiDau in _db.QuanLyGiaiDaus on lichThiDau.MaGiaiDau equals giaiDau.MaGiaiDau
                            join doiBongChuNha in _db.DoiBongs on lichThiDau.MaCLBChuNha equals doiBongChuNha.MaDoiBong
                            join doiBongKhach in _db.DoiBongs on lichThiDau.MaCLBKhach equals doiBongKhach.MaDoiBong
                            where giaiDau.MaGiaiDau == maGiaiDau
                            select new
                            {
                                MaLichThiDau = lichThiDau.MaLichThiDau,
                                TenGiaiDau = giaiDau.TenGiaiDau,
                                NgayThiDau = lichThiDau.NgayThiDau,
                                VongThiDau = lichThiDau.VongThiDau,
                                SanThiDau = lichThiDau.SanThiDau,
                                TenDoiBongChuNha = doiBongChuNha.TenDoiBong,
                                TiSo = lichThiDau.TiSoCLBChuNha + " - " + lichThiDau.TiSoCLBKhach,
                                TenDoiBongKhach = doiBongKhach.TenDoiBong,
                                LogoDoiChuNha = doiBongChuNha.Logo,
                                LogoDoiKhach = doiBongKhach.Logo
                            })
           .Where(x => x.NgayThiDau != null && DbFunctions.TruncateTime(x.NgayThiDau) == DbFunctions.TruncateTime(ngayThiDau))
           .AsEnumerable()  // Chuyển sang danh sách ở client
           .Select(x => new
           {
               x.MaLichThiDau,
               x.TenGiaiDau,
               GioThiDau = x.NgayThiDau.Value.ToString("HH:mm"),  // Format ngày và giờ
               x.VongThiDau,
               x.SanThiDau,
               x.TenDoiBongChuNha,
               x.TiSo,
               x.TenDoiBongKhach,
               x.LogoDoiChuNha,
               x.LogoDoiKhach
           })
           .ToList();
                return Json(new { data = list }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult TaoLichThiDauHangLoat(int MaGiaiDau)
        {
            try
            {
                using (_db = new SportLeagueContext())
                {
                    int vongThiDau = 1;

                    // Lấy ra danh sách đội bóng thuộc giải đấu
                    var doiBongs = _db.QuanLyCLBVaGiaiDaus.Where(x => x.MaGiaiDau == MaGiaiDau).ToList();

                    foreach (var doiBongChuNha in doiBongs)
                    {
                        foreach (var doiBongKhach in doiBongs)
                        {
                            // Đội nhà và đội khác trùng nhau
                            if (doiBongChuNha.MaCLB == doiBongKhach.MaCLB)
                                continue;

                            LichThiDau lichThiDau = new LichThiDau();
                            lichThiDau.MaGiaiDau = MaGiaiDau;
                            lichThiDau.MaCLBChuNha = doiBongChuNha.MaCLB;
                            lichThiDau.MaCLBKhach = doiBongKhach.MaCLB;
                            lichThiDau.VongThiDau = vongThiDau.ToString();
                            vongThiDau++;
                            _db.LichThiDaus.Add(lichThiDau);
                        }
                    }


                    _db.SaveChanges();
                    return Json(new
                    {
                        result = true,
                        message = "Tạo lịch thành công"
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = false,
                    message = "Tạo lịch không thành công"
                });
            }
        }

        public ActionResult TaoLichThiDau()
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {
                ViewBag.DsGiaiDau = _db.QuanLyGiaiDaus.ToList();
                ViewBag.DsDoiBong = _db.DoiBongs.ToList();
                return View();
            }

        }

        [HttpPost]
        public ActionResult TaoLichThiDau(LichThiDau model)
        {
            using (_db = new SportLeagueContext())
            {
                try
                {
                    using (_db = new SportLeagueContext())
                    {
                        if (model.MaCLBChuNha == model.MaCLBKhach)
                        {
                            // Nhảy xuống catch
                            throw new Exception();
                        }

                        // Thêm xuống database
                        _db.LichThiDaus.Add(model);
                        // Lưu
                        _db.SaveChanges();
                    }

                    // Return
                    return Json(new
                    {
                        result = true,
                        message = "Đăng ký thành công"
                    }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new
                    {
                        result = false,
                        message = "Đăng ký không thành công"
                    });
                }
            }
        }
        public ActionResult CapNhat(int maLichThiDau)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {
                var DSModel = _db.LichThiDaus.Find(maLichThiDau);
                ViewBag.DsGiaiDau = _db.QuanLyGiaiDaus.ToList();

                ViewBag.DsDoiBong = _db.DoiBongs.ToList();

                return View(DSModel);
            }
        }
        [HttpPost]

        public ActionResult CapNhat(LichThiDau model)
        {
            try
            {
                using (_db = new SportLeagueContext())

                {
                    var lichThiDau = _db.LichThiDaus.Find(model.MaLichThiDau);
                    lichThiDau.MaGiaiDau = model.MaGiaiDau;
                    lichThiDau.NgayThiDau = model.NgayThiDau;
                    lichThiDau.VongThiDau = model.VongThiDau;
                    lichThiDau.SanThiDau = model.SanThiDau;
                    lichThiDau.MaCLBChuNha = model.MaCLBChuNha;
                    lichThiDau.TiSoCLBChuNha = model.TiSoCLBChuNha;
                    lichThiDau.TiSoCLBKhach = model.TiSoCLBKhach;
                    lichThiDau.MaCLBKhach = model.MaCLBKhach;
                    lichThiDau.SoCuSut = model.SoCuSut;
                    lichThiDau.SutTrungDich = model.SutTrungDich;
                    lichThiDau.SoLuongPenalties = model.SoLuongPenalties;
                    lichThiDau.SoLuongDaPhat = model.SoLuongDaPhat;
                    lichThiDau.SoLuongPhatGoc = model.SoLuongPhatGoc;
                    lichThiDau.SoLuongPhamLoi = model.SoLuongPhamLoi;
                    lichThiDau.SoLuongVietVi = model.SoLuongVietVi;
                    lichThiDau.SoTheVang = model.SoTheVang;
                    lichThiDau.SoTheDo = model.SoTheDo;
                    lichThiDau.BuGio = model.BuGio;
                    lichThiDau.KetQuaLuanLuu = model.KetQuaLuanLuu;
                    _db.SaveChanges();
                    return Json(new
                    {
                        result = true,
                        message = "Cập nhật thành công"
                    }, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = false,
                    message = "Cập nhật không thành công"
                });
            }

        }

        public ActionResult Xoa(int maLichThiDau)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {
                var model = _db.LichThiDaus.Find(maLichThiDau);
                _db.LichThiDaus.Remove(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

        }





        public ActionResult XemBXH(int maGiaiDau)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            try
            {
                ViewBag.maGiaiDau = maGiaiDau;

                using (_db = new SportLeagueContext())
                {
                    // Lấy ra lịch thi đấu với cái giải đấu truyền vào 
                    var lichThiDaus = _db.LichThiDaus.Where(x => x.MaGiaiDau == maGiaiDau).ToList();

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


                    return View(bxhs);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public ActionResult TaoDanhHieuCauThu()
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {
                ViewBag.DsLichThiDau = _db.LichThiDaus.ToList();
                ViewBag.DsCauThu = _db.CauThus.ToList();
                ViewBag.DsLoaiGiaiThuong = _db.LoaiGiaiThuongs.ToList();
                return View();
            }

        }


        [HttpPost]
        public ActionResult TaoDanhHieuCauThu(DanhHieuCauThu model)
        {
            try
            {
                using (_db = new SportLeagueContext())
                {
                    var danhHieuCauThu = _db.DanhHieuCauThus.FirstOrDefault(x=>x.MaLichThiDau == model.MaLichThiDau && x.MaCauThu == model.MaCauThu && x.MaLoaiGiaiThuong == model.MaLoaiGiaiThuong);
                    if(danhHieuCauThu == null)
                    {
                        // Thêm xuống database
                        _db.DanhHieuCauThus.Add(model);
                    }
                    else
                    {
                        danhHieuCauThu.SoLuong += model.SoLuong;
                    }
                    
                    // Lưu
                    _db.SaveChanges();
                }

                // Return
                return Json(new
                {
                    result = true,
                    message = "Đăng ký thành công"
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = false,
                    message = "Đăng ký không thành công"
                });
            }
        }





        public ActionResult CapNhatDanhHieuCauThu(int maDanhHieuCauThu)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {
                var DSModel = _db.DanhHieuCauThus.Find(maDanhHieuCauThu);
                ViewBag.DsLichThiDau = _db.LichThiDaus.ToList();
                ViewBag.DsCauThu = _db.CauThus.ToList();
                ViewBag.DsLoaiGiaiThuong = _db.LoaiGiaiThuongs.ToList();

                return View(DSModel);
            }
        }


        [HttpPost]

        public ActionResult CapNhatDanhHieuCauThu(DanhHieuCauThu model)
        {
            try
            {
                using (_db = new SportLeagueContext())
                {
                    var danhHieuCauThu = _db.DanhHieuCauThus.Find(model.MaDanhHieuCauThu);
                    danhHieuCauThu.MaLichThiDau = model.MaLichThiDau;
                    danhHieuCauThu.MaCauThu = model.MaCauThu;
                    danhHieuCauThu.SoLuong = model.SoLuong;
                    danhHieuCauThu.MaLoaiGiaiThuong = model.MaLoaiGiaiThuong;
                    
               
                    _db.SaveChanges();
                    return Json(new
                    {
                        result = true,
                        message = "Cập nhật thành công"
                    }, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = false,
                    message = "Cập nhật không thành công"
                });
            }
           

        }

        public ActionResult XemDanhHieuCauThu(int maGiaiDau)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
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

                                       join loaiGiaiThuong in _db.LoaiGiaiThuongs
                                       on danhHieu.MaLoaiGiaiThuong equals loaiGiaiThuong.MaLoaiGiaiThuong

                                       where lichDau.MaGiaiDau == maGiaiDau
                                       select new { 
                                          Avatar = cauThu.Avatar,
                                          TenCauThu = cauThu.TenCauThu,
                                          TenDoiBong = doiBong.TenDoiBong,
                                          Logo = doiBong.Logo,
                                          SoLuong = danhHieu.SoLuong,
                                          MaLoaiGiaiThuong = danhHieu.MaLoaiGiaiThuong,
                                          TenLoaiGiaiThuong = loaiGiaiThuong.TenLoaiGiaiThuong
                                       }).ToList();

                var danhHieuCauThus = data.GroupBy(x => new { x.Avatar, x.TenCauThu, x.TenDoiBong, x.Logo, x.MaLoaiGiaiThuong, x.TenLoaiGiaiThuong })
                    .Select(x => new DanhHieuCauThuView
                    {
                        Avatar = x.Key.Avatar,
                        TenCauThu = x.Key.TenCauThu,
                        TenDoiBong = x.Key.TenDoiBong,
                        Logo = x.Key.Logo,
                        TongSoLuong = x.Sum(c=>c.SoLuong),
                        MaLoaiGiaiThuong = x.Key.MaLoaiGiaiThuong,
                        TenLoaiGiaiThuong = x.Key.TenLoaiGiaiThuong
                    }).ToList();

                ViewBag.LoaiGiaiThuongs = danhHieuCauThus
                                            .GroupBy(x => new { x.MaLoaiGiaiThuong.Value, x.TenLoaiGiaiThuong })
                                            .Select(group => group.First()) // Chọn một đại diện từ mỗi nhóm
                                            .Select(x => new LoaiGiaiThuong() { MaLoaiGiaiThuong = x.MaLoaiGiaiThuong.Value, TenLoaiGiaiThuong = x.TenLoaiGiaiThuong })
                                            .ToList();

                //ViewBag.LoaiGiaiThuongs = danhHieuCauThus.Select(x => new LoaiGiaiThuong() { MaLoaiGiaiThuong = x.MaLoaiGiaiThuong.Value, TenLoaiGiaiThuong = x.TenLoaiGiaiThuong}).Distinct().ToList();
                ViewBag.MaGiaiDau = maGiaiDau;

                return View(danhHieuCauThus);
            }

            //if (maCauThu == null)
            //{
            //    // Nếu maCauThu là null, có thể chuyển hướng hoặc xử lý một cách khác tùy vào yêu cầu của bạn.
            //    // Ví dụ: chuyển hướng về trang danh sách cầu thủ.
            //    return RedirectToAction("Index", "QuanLyDanhHieuCauThu");
            //}

            //using (_db = new SportLeagueContext())// Thay "YourDbContext" bằng tên của DbContext trong ứng dụng của bạn
            //{
            //    // Tìm cầu thủ theo maCauThu trong cơ sở dữ liệu
            //    var cauThu = _db.CauThus.FirstOrDefault(c => c.MaCauThu == maCauThu);

            //    if (cauThu == null)
            //    {
            //        // Nếu không tìm thấy cầu thủ, có thể xử lý một cách khác tùy vào yêu cầu của bạn.
            //        // Ví dụ: hiển thị thông báo lỗi.
            //        ViewBag.ErrorMessage = "Không tìm thấy thông tin cho cầu thủ có mã " + maCauThu;
            //        return View("Error"); // Tạo trang Error.cshtml để hiển thị thông báo lỗi.
            //    }

            //    // Tìm danh hiệu của cầu thủ trong cơ sở dữ liệu
            //    var danhHieuCauThu = _db.DanhHieuCauThus.Where(dh => dh.MaCauThu == maCauThu).ToList();

            //    // Truyền danh sách danh hiệu của cầu thủ đến view để hiển thị
            //    ViewBag.DanhHieuCauThu = danhHieuCauThu;

            //    // Truyền thông tin của cầu thủ đến view để hiển thị (nếu cần)
            //    ViewBag.CauThu = cauThu;

            //    return View();
            //}
        }


        public ActionResult XuatFileExcel(int maGiaiDau)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            System.Data.DataTable dt = new System.Data.DataTable();
            var fileName = string.Empty;
            using (_db = new SportLeagueContext())
            {
                var list = from lichThiDau in _db.LichThiDaus

                           join giaiDau in _db.QuanLyGiaiDaus on lichThiDau.MaGiaiDau equals giaiDau.MaGiaiDau

                           join doiBongChuNha in _db.DoiBongs on lichThiDau.MaCLBChuNha equals doiBongChuNha.MaDoiBong

                           join doiBongKhach in _db.DoiBongs on lichThiDau.MaCLBKhach equals doiBongKhach.MaDoiBong

                           where giaiDau.MaGiaiDau == maGiaiDau
                           select new
                           {
                               MaLichThiDau = lichThiDau.MaLichThiDau,
                               TenGiaiDau = giaiDau.TenGiaiDau,
                               NgayThiDau = lichThiDau.NgayThiDau.ToString(),
                               VongThiDau = lichThiDau.VongThiDau,
                               SanThiDau = lichThiDau.SanThiDau,
                               TenDoiBongChuNha = doiBongChuNha.TenDoiBong,
                               TiSo = lichThiDau.TiSoCLBChuNha + " - " + lichThiDau.TiSoCLBKhach,
                               TenDoiBongKhach = doiBongKhach.TenDoiBong,
                           };
                fileName = list.FirstOrDefault()?.TenGiaiDau;
                // Chuyển kết quả truy vấn thành DataTable
                dt.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("VongThiDau", typeof(string)),
                    new DataColumn("TenGiaiDau", typeof(string)),
                    new DataColumn("NgayThiDau", typeof(string)),
                    new DataColumn("SanThiDau", typeof(string)),
                    new DataColumn("TenDoiBongChuNha", typeof(string)),
                    new DataColumn("TiSo", typeof(string)),
                    new DataColumn("TenDoiBongKhach", typeof(string)),
                });

                foreach (var row in list)
                {
                    dt.Rows.Add(row.VongThiDau, row.TenGiaiDau, row.NgayThiDau, row.SanThiDau, row.TenDoiBongChuNha, row.TiSo, row.TenDoiBongKhach);
                }
            }

            using (var workbook = new XLWorkbook())
            {
                // Tạo một Worksheet
                var worksheet = workbook.Worksheets.Add("LichThiDau");

                // Đặt tên các cột
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = dt.Columns[i].ColumnName;
                    worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                    worksheet.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                }

                // Đổ dữ liệu vào worksheet
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = dt.Rows[i][j].ToString();
                    }
                }

                using (MemoryStream stream = new MemoryStream())
                {
                    worksheet.Columns().AdjustToContents();
                    workbook.SaveAs(stream);
                    stream.Position = 0;

                    // Tải về file Excel
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Kết quả {fileName}.xlsx");
                }
            }
        }

        public ActionResult XemMaTranGiaiDau(int maGiaiDau)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {


                var lichThiDaus = (from lichThiDau in _db.LichThiDaus

                                   join giaiDau in _db.QuanLyGiaiDaus on lichThiDau.MaGiaiDau equals giaiDau.MaGiaiDau

                                   join doiBongChuNha in _db.DoiBongs on lichThiDau.MaCLBChuNha equals doiBongChuNha.MaDoiBong

                                   join doiBongKhach in _db.DoiBongs on lichThiDau.MaCLBKhach equals doiBongKhach.MaDoiBong

                                   where lichThiDau.MaGiaiDau == maGiaiDau

                                   select new
                                   {
                                       MaLichThiDau = lichThiDau.MaLichThiDau,
                                       TenGiaiDau = giaiDau.TenGiaiDau,
                                       NgayThiDau = lichThiDau.NgayThiDau.ToString(),
                                       VongThiDau = lichThiDau.VongThiDau,
                                       SanThiDau = lichThiDau.SanThiDau,
                                       TenDoiBongChuNha = doiBongChuNha.TenDoiBong,
                                       TiSoCLBChuNha = lichThiDau.TiSoCLBChuNha,
                                       TiSoCLBKhach = lichThiDau.TiSoCLBKhach,
                                       TenDoiBongKhach = doiBongKhach.TenDoiBong,
                                   }).ToList();
                ViewBag.MaGiaiDau = maGiaiDau;
                return View(lichThiDaus);
            }
        }

        [HttpPost]
        public ActionResult XemMaTranGiaiDau(LichThiDau model)
        {
            try
            {
                using (_db = new SportLeagueContext())
                {
                    var lichThiDau = _db.LichThiDaus.Find(model.MaLichThiDau);
                    lichThiDau.TiSoCLBChuNha = model.TiSoCLBChuNha;
                    lichThiDau.TiSoCLBKhach = model.TiSoCLBKhach;


                    _db.SaveChanges();
                    return Json(new
                    {
                        result = true,
                        message = "Cập nhật thành công"
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = false,
                    message = "Cập nhật không thành công"
                });
            }
        }
    }
}