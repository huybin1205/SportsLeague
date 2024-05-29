using SportsLeague.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsLeague.Controllers
{
    public class QLGiaidauController : Controller
    {
        // GET: QLGiaidau
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
        //public ActionResult Login()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Login(string tenDangNhap, string matKhau)
        //{
        //    using (_db = new SportLeagueContext())
        //    {
        //        // Tìm người dùng với tên đăng nhập
        //        // FirstOrDefault hàm này trả về NguoiDung nếu tìm thấy, không tìm thấy trả về null
        //        var user = _db.NguoiDungs.FirstOrDefault(x => x.TenDangNhap == tenDangNhap);
        //        if (user != null && BCrypt.Net.BCrypt.Verify(matKhau, user.MatKhau))
        //        {
        //            Session["UserLogin"] = user;
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }
        //    return View();
        //}
        public ActionResult QL()
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            return View();
        }

        //public ActionResult Detail(int maGiaiDau)
        //{
        //    var model = new QuanLyGiaiDau();
        //    using (_db = new SportLeagueContext())
        //    {
        //        model = _db.QuanLyGiaiDaus.FirstOrDefault(x => x.MaGiaiDau == maGiaiDau);
        //        if (model == null)
        //            model = new QuanLyGiaiDau();
        //    }
        //    return View(model);
        //}
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
                var list = from p in _db.QuanLyGiaiDaus

                           select new QuanLyGiaiDauView
                           {
                               MaGiaiDau = p.MaGiaiDau,
                               TenGiaiDau = p.TenGiaiDau,
                               NamThucHien = p.NamThucHien,
                               DonViToChuc = p.DonViToChuc,
                               SoLuongDoiThamGia = p.SoLuongDoiThamGia,
                               NgayBatDau = p.NgayBatDau,
                               NgayKetThuc = p.NgayKetThuc
                           };
                return Json(new { data = list.ToList() }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult QL(QuanLyGiaiDau quanLyGiaiDau)
        {
            try
            {
                using (_db = new SportLeagueContext())
                {
                    // Thêm xuống database
                    _db.QuanLyGiaiDaus.Add(quanLyGiaiDau);
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
        public ActionResult DanhSachQL()
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {
                List<QuanLyGiaiDau> ketQua = _db.QuanLyGiaiDaus.ToList();
                return View(ketQua);
            }

        }
        public ActionResult CapNhat(int maGiaiDau)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {
                var DSModel = _db.QuanLyGiaiDaus.Find(maGiaiDau);

                ViewBag.DSDoiBong = _db.DoiBongs.ToList();


                return View(DSModel);
            }
        }
        [HttpPost]
        public ActionResult CapNhat(QuanLyGiaiDau model)
        {
            try
            {
                using (_db = new SportLeagueContext())
                {
                    var giaiDau = _db.QuanLyGiaiDaus.Find(model.MaGiaiDau);
                    giaiDau.TenGiaiDau = model.TenGiaiDau;
                    giaiDau.NamThucHien = model.NamThucHien;
                    giaiDau.DonViToChuc = model.DonViToChuc;
                    giaiDau.SoLuongDoiThamGia = model.SoLuongDoiThamGia;
                    giaiDau.NgayBatDau=model.NgayBatDau;
                    giaiDau.NgayKetThuc=model.NgayKetThuc;
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

        public ActionResult Xoa(int maGiaiDau)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {
                var lichThiDaus = _db.LichThiDaus.Where(x=>x.MaGiaiDau == maGiaiDau).ToList();
                foreach (var lichThiDau in lichThiDaus)
                    _db.LichThiDaus.Remove(lichThiDau);

                var quanLyCLBVaGiaiDaus = _db.QuanLyCLBVaGiaiDaus.Where(x => x.MaGiaiDau == maGiaiDau).ToList();
                foreach (var quanLyCLBVaGiaiDau in quanLyCLBVaGiaiDaus)
                    _db.QuanLyCLBVaGiaiDaus.Remove(quanLyCLBVaGiaiDau);

                var model = _db.QuanLyGiaiDaus.Find(maGiaiDau);
                _db.QuanLyGiaiDaus.Remove(model);

                _db.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        public ActionResult XuatPosterGiaiDau(int maGiaiDau)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {
                //tim ma gia dau trong bang ql giai dau
                var model = _db.QuanLyGiaiDaus.Find(maGiaiDau);

                var doiBongs = (from quanLyCLBVaGiaiDau in _db.QuanLyCLBVaGiaiDaus

                                // equals là =
                                join doiBong in _db.DoiBongs on quanLyCLBVaGiaiDau.MaCLB equals doiBong.MaDoiBong

                                join giaiDau in _db.QuanLyGiaiDaus on quanLyCLBVaGiaiDau.MaGiaiDau equals giaiDau.MaGiaiDau

                                where quanLyCLBVaGiaiDau.MaGiaiDau == maGiaiDau
                                select new DoiBongViewModel()
                                {
                                    MaDoiBong = doiBong.MaDoiBong,
                                    Logo = doiBong.Logo,
                                    TenDoiBong = doiBong.TenDoiBong,
                                    NguoiQuanLyCLB = doiBong.NguoiQuanLyCLB
                                }).ToList();
                ViewBag.DoiBongs = doiBongs;
                ViewBag.SoLuongDoiBongThamGia = doiBongs.Count();
                return View(model);
            }
        }

        public ActionResult TaoLichThiDauTheoBang(int maGiaiDau, int soLuongBang)
        {
            using (_db = new SportLeagueContext())
            {
                using (DbContextTransaction transaction = _db.Database.BeginTransaction())
                {
                    try
                    {
                        var bangDaus = _db.BangDaus.Where(x=>x.MaGiaiDau == maGiaiDau).ToList();
                        foreach (var bangDau in bangDaus)
                        {
                            var bangDauVaDoiBongs = _db.BangDauVaDoiBongs.Where(x=>x.MaBangDau == bangDau.MaBangDau).ToList();
                            foreach (var bangDauVaDoiBong in bangDauVaDoiBongs)
                            {
                                _db.BangDauVaDoiBongs.Remove(bangDauVaDoiBong);
                            }
                            _db.BangDaus.Remove(bangDau);
                        }
                        _db.SaveChanges();

                        var doiBongs = (from quanLyCLBVaGiaiDau in _db.QuanLyCLBVaGiaiDaus
                                        where quanLyCLBVaGiaiDau.MaGiaiDau == maGiaiDau
                                        select quanLyCLBVaGiaiDau).ToList();
                        if (soLuongBang > doiBongs.Count())
                            throw new Exception("Số lượng bảng không hợp lệ");

                        Random random = new Random();
                        doiBongs = doiBongs.OrderBy(x => random.Next()).ToList();

                        List<BangDau> bangs = new List<BangDau>();
                        for (int i = 0; i < soLuongBang; i++)
                        {
                            BangDau bangDau = new BangDau();
                            bangDau.MaGiaiDau = maGiaiDau;
                            bangDau.TenBangDau = $"Bảng {i + 1}";
                            _db.BangDaus.Add(bangDau);
                            bangs.Add(bangDau);
                        }
                        _db.SaveChanges();

                        // Phân chia đội bóng vào các bảng
                        for (int i = 0; i < doiBongs.Count; i++)
                        {
                            BangDauVaDoiBong bangDauVaDoiBong = new BangDauVaDoiBong()
                            {
                                MaBangDau = bangs[i % soLuongBang].MaBangDau,
                                MaDoiBong = doiBongs[i].MaCLB
                            };

                            _db.BangDauVaDoiBongs.Add(bangDauVaDoiBong);
                        }
                        _db.SaveChanges();

                        transaction.Commit();

                        return Json(new
                        {
                            result = true,
                            message = "Tạo bảng thành công"
                        }, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return Json(new
                        {
                            result = false,
                            message = "Tạo không thành công"
                        });
                    }
                }
            }
        }

    }

}