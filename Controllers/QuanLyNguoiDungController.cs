using SportsLeague.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsLeague.Controllers
{
    public class QuanLyNguoiDungController : Controller
    {
        // GET: QuanLyNguoiDung
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
                var list = from p in _db.NguoiDungs
                           select new
                           {
                               MaNguoiDung = p.MaNguoiDung,
                               TenDangNhap = p.TenDangNhap,
                               MatKhau = p.MatKhau,
                               Ho = p.Ho,
                               Ten = p.Ten,
                               Avatar = p.Avatar,
                               NgaySinh = p.NgaySinh.ToString(),  
                               Email = p.Email,
                               SoDienThoai =p.SoDienThoai.ToString()
                              
                           };
                return Json(new { data = list.ToList() }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DangKy()
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(NguoiDung quanLyNguoiDung, HttpPostedFileBase Avatar)
        {
            try
            {
                Random r = new Random();
                string path = "-1";
                int random = r.Next();
                if (Avatar != null && Avatar.ContentLength > 0)
                {
                    string extension = Path.GetExtension(Avatar.FileName);
                    if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                    {
                        try
                        {
                            path = Path.Combine(Server.MapPath("~/Content/upload/"), random + Path.GetFileName(Avatar.FileName));
                            Avatar.SaveAs(path);
                            path = "Content/upload/" + random + Path.GetFileName(Avatar.FileName);
                            //viewbag.message = "file upload successfully";
                        }
                        catch (Exception ex)
                        {
                            path = "-1";
                        }

                    }
                }
                using (_db = new SportLeagueContext())
                {
                    quanLyNguoiDung.MatKhau = BCrypt.Net.BCrypt.HashPassword(quanLyNguoiDung.MatKhau);
                    // Thêm xuống database
                    quanLyNguoiDung.Avatar = path;
                    _db.NguoiDungs.Add(quanLyNguoiDung);
                    // Lưu
                    _db.SaveChanges();
                }

                // Return
                return RedirectToAction("DangKy");
            }
            catch (Exception ex)
            {
                return RedirectToAction("DangKy");
            }

        }
        public ActionResult CapNhat(int maNguoiDung)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {
                var DSModel = _db.NguoiDungs.Find(maNguoiDung);

                // Lấy danh sách vai trò chưa được thêm
                var vaiTroChuaThem = _db.VaiTroes.Where(vt => !vt.PhanQuyenNguoiDungs.Any(pq => pq.MaNguoiDung == maNguoiDung)).ToList();
                ViewBag.DSVaiTro = vaiTroChuaThem;

                var doiBongs = _db.DoiBongs.ToList();
                ViewBag.DoiBongs = doiBongs;

                //ViewBag.DSVaiTro = _db.VaiTroes.ToList();

                return View(DSModel);
            }
        }
        [HttpPost]
        public ActionResult CapNhat(NguoiDung model, HttpPostedFileBase Avatar)
        {
            try
            {
                using (_db = new SportLeagueContext())
                {
                    var quanLyNguoiDung = _db.NguoiDungs.Find(model.MaNguoiDung);

                    Random r = new Random();
                    string path = "-1";
                    int random = r.Next();
                    if (Avatar != null && Avatar.ContentLength > 0) // Kiểm tra xem có upload logo mới không?
                    {
                        string extension = Path.GetExtension(Avatar.FileName);
                        if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                        {
                            try
                            {
                                path = Path.Combine(Server.MapPath("~/Content/upload/"), random + Path.GetFileName(Avatar.FileName));
                                Avatar.SaveAs(path);
                                path = "Content/upload/" + random + Path.GetFileName(Avatar.FileName);
                                quanLyNguoiDung.Avatar = path;
                            }
                            catch (Exception ex)
                            {
                                path = "-1";
                            }

                        }
                    }

                    quanLyNguoiDung.TenDangNhap = model.TenDangNhap;
                    quanLyNguoiDung.MatKhau = model.MatKhau;
                    quanLyNguoiDung.Ho = model.Ho;
                    quanLyNguoiDung.Ten = model.Ten;
                    quanLyNguoiDung.NgaySinh = model.NgaySinh;
                    quanLyNguoiDung.Email = model.Email;
                    quanLyNguoiDung.SoDienThoai = model.SoDienThoai;
                   

                    _db.SaveChanges();

                    return RedirectToAction("CapNhat", new { maNguoiDung = quanLyNguoiDung.MaNguoiDung });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Xoa(int maNguoiDung)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {
                var model = _db.NguoiDungs.Find(maNguoiDung);
                _db.NguoiDungs.Remove(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
    }
}