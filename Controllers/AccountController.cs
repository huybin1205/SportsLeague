using SportsLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsLeague.Controllers
{
   
    public class AccountController : Controller
    {
        // GET: Account
        private SportLeagueContext _db;
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string tenDangNhap, string matKhau)
        {
            using (_db = new SportLeagueContext())
            {
                // Tìm người dùng với tên đăng nhập
                // FirstOrDefault hàm này trả về NguoiDung nếu tìm thấy, không tìm thấy trả về null
                var user = _db.NguoiDungs.FirstOrDefault(x => x.TenDangNhap == tenDangNhap);
                if (user != null && BCrypt.Net.BCrypt.Verify(matKhau, user.MatKhau))
                {
                    //Lưu thông tin người dùng vào session
                    Session["UserLogin"] = user;
                    return RedirectToAction("Index", "Home");
                }              
            }
            return View();
        }

        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(NguoiDung nguoiDung)
        {
            try
            {
                using (_db = new SportLeagueContext())
                {
                    // Mã hóa mật khẩu trước khi lưu vào cơ sở dữ liệu
                    nguoiDung.MatKhau = BCrypt.Net.BCrypt.HashPassword(nguoiDung.MatKhau);
                    // Thêm xuống database
                    _db.NguoiDungs.Add(nguoiDung);
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