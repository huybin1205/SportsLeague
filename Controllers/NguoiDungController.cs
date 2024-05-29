using SportsLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCrypt.Net;
using System.IO;

namespace SportsLeague.Controllers
{
    // Muốn truy cập vào đây thì: /NguoiDung
    public class NguoiDungController : Controller
    {
        private SportLeagueContext _db;

        // Muốn truy cập vào đây thì: /NguoiDung/Login
        public ActionResult Login() // Login: Action
        {
            // Trả về Views/NguoiDung/Login.cshtml
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
                if (user != null)
                {
                    Session["UserLogin"] = user;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Nếu đăng nhập không thành công, trả về view với thông báo lỗi
                    ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không chính xác. Vui lòng thử lại.";
                    return View();
                }
            }
            //return View();
        }

        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(NguoiDung nguoiDung, HttpPostedFileBase Avatar)
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
                    // Mã hóa mật khẩu
                    nguoiDung.MatKhau = BCrypt.Net.BCrypt.HashPassword(nguoiDung.MatKhau);
                    // Thêm xuống database
                    nguoiDung.Avatar = path;
                    _db.NguoiDungs.Add(nguoiDung);
                    // Lưu
                    _db.SaveChanges();
                }

                // Return
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult DangXuat()
        {
            Session["UserLogin"] = null;
            return RedirectToAction("Login", "NguoiDung");
        }

        public ActionResult Profile()
        {

            using (_db = new SportLeagueContext())
            {
                var user = Session["UserLogin"] as SportsLeague.Models.NguoiDung;
                if (user != null)
                {
                    return View("Profile", user);
                }
                else
                {
                    return View();
                }
            }
        }
    }
}