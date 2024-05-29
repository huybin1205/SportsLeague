using SportsLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsLeague.Controllers
{
    public class QuanLyCLBVaGiaiDauController : Controller
    {
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
        public ActionResult Them(QuanLyCLBVaGiaiDau quanLyCLBVaGiaiDau)
        {
            try
            {
                using (_db = new SportLeagueContext())
                {
                    // Thêm xuống database
                    _db.QuanLyCLBVaGiaiDaus.Add(quanLyCLBVaGiaiDau);
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

        public ActionResult GetData(int maGiaiDau)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {
                // nếu như không có where
                // thì nó lấy hết tất cả trong database bao gồm luôn 2 giải 1002 và 1004
                // thêm where vào để mình lấy ra 1 giải khi mình chọn bên ngoài 

               

                // Mỗi lần  chọn từ trang index, thì  chọn 1 giải đấu thì nó có maGiaiDau riêng biệt
                // Xong vào đây  phài filter theo cái maGiaiDau đó 
                // Thì nó mới lên chính xác đc số đội bóng tham gia giải đấu đó
                
                var list = from p in _db.QuanLyCLBVaGiaiDaus
                           where p.MaGiaiDau == maGiaiDau
                           join doiBong in _db.DoiBongs on p.MaCLB equals doiBong.MaDoiBong
                           select new
                           {
                               MaDoiBong = doiBong.MaDoiBong,
                               Logo = doiBong.Logo,
                               TenDoiBong = doiBong.TenDoiBong,
                               NguoiQuanLyCLB = doiBong.NguoiQuanLyCLB,
                           };

                return Json(new { data = list.ToList() }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Xoa(int maGiaiDau, int maCLB)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {
                var model = _db.QuanLyCLBVaGiaiDaus.FirstOrDefault(x => x.MaGiaiDau == maGiaiDau && x.MaCLB == maCLB);
                if (model != null)
                {
                    _db.QuanLyCLBVaGiaiDaus.Remove(model);
                    _db.SaveChanges();
                }
                return RedirectToAction("CapNhat", "QLGiaiDau", new { maGiaiDau = maGiaiDau });
            }
        }
    }
}