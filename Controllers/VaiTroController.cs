using SportsLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsLeague.Controllers
{
    public class VaiTroController : Controller
    {
        // GET: VaiTro
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
            //using (_db = new SportLeagueContext())
            //{
            //    List<QuanLyGiaiDau> QLList = _db.QuanLyGiaiDaus.ToList<QuanLyGiaiDau>();
            //    return Json(new { data = QLList.ToList() }, JsonRequestBehavior.AllowGet);
            //}
            using (_db = new SportLeagueContext())
            {
                var list = from p in _db.VaiTroes

                           select new
                           {
                               MaVaiTro = p.MaVaiTro,
                              TenVaiTro = p.TenVaiTro
                            
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
        public ActionResult DangKy(VaiTro vaiTro)
        {
            try
            {
                using (_db = new SportLeagueContext())
                {
                    // Thêm xuống database
                    _db.VaiTroes.Add(vaiTro);
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
        public ActionResult CapNhat(int maVaiTro)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {
                var DSModel = _db.VaiTroes.Find(maVaiTro);            

                return View(DSModel);
            }
        }
        [HttpPost]
        public ActionResult CapNhat(VaiTro model)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            try
            {
                using (_db = new SportLeagueContext())
                {
                    var vaiTro = _db.VaiTroes.Find(model.MaVaiTro);
                    vaiTro.TenVaiTro = model.TenVaiTro;
                   
                    
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
        public ActionResult Xoa(int maVaiTro)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {
                var model = _db.VaiTroes.Find(maVaiTro);
                _db.VaiTroes.Remove(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
    }
}