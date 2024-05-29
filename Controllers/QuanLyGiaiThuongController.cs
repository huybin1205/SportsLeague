using SportsLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsLeague.Controllers
{
    public class QuanLyGiaiThuongController : Controller
    {
        // GET: QuanLyGiaiThuong
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
        public ActionResult DangKy(QuanLyGiaiThuong quanLyGiaiThuong)
        {
            try
            {
                using (_db = new SportLeagueContext())
                {
                    // Thêm xuống database
                    _db.QuanLyGiaiThuongs.Add(quanLyGiaiThuong);
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
}