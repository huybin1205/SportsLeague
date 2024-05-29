using SportsLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsLeague.Controllers
{
    public class PhanQuyenNguoiDungController : Controller
    {
        // GET: PhanQuyenNguoiDung
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
        [HttpPost]
        public ActionResult Them(PhanQuyenNguoiDung phanQuyenNguoiDung)
        {
            try
            {
                using (_db = new SportLeagueContext())
                {
                    // Thêm xuống database
                    _db.PhanQuyenNguoiDungs.Add(phanQuyenNguoiDung);
                    // Lưu
                    _db.SaveChanges();
                }

                // Return
                return Json(new
                {
                    result = true,
                    message = "Thêm thành công"
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = false,
                    message = "Thêm không thành công"
                });
            }
        }
        public ActionResult GetData(int maNguoiDung)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {             
                var list = from p in _db.PhanQuyenNguoiDungs
                           where p.MaNguoiDung== maNguoiDung
                           join vaiTro in _db.VaiTroes on p.MaVaiTro equals vaiTro.MaVaiTro
                           join doiBong in _db.DoiBongs on p.MaDoiBong equals doiBong.MaDoiBong
                           select new
                           {
                               MaVaiTro =vaiTro.MaVaiTro,
                               TenVaiTro = vaiTro.TenVaiTro,                           
                               TenDoiBong = doiBong.TenDoiBong,
                           };

                return Json(new { data = list.ToList() }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Xoa(int maNguoiDung, int maVaiTro)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {
                var model = _db.PhanQuyenNguoiDungs.FirstOrDefault(x => x.MaNguoiDung == maNguoiDung && x.MaVaiTro ==maVaiTro);
                if (model != null)
                {
                    _db.PhanQuyenNguoiDungs.Remove(model);
                    _db.SaveChanges();
                }
                return RedirectToAction("CapNhat", "QuanLyNguoiDung", new { maNguoiDung = maNguoiDung});
            }
        }

    }
}