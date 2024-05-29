using SportsLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsLeague.Controllers
{
    public class QuanLyDanhHieuCauThuController : Controller
    {
        // GET: QuanLyDanhHieuCauThu
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
                var list = from danhHieuCauThu in _db.DanhHieuCauThus

                           join lichThiDau in _db.LichThiDaus on danhHieuCauThu.MaLichThiDau equals lichThiDau.MaLichThiDau

                           join cauThu in _db.CauThus on danhHieuCauThu.MaCauThu equals cauThu.MaCauThu

                           join loaiThiDau in _db.LoaiGiaiThuongs on danhHieuCauThu.MaLoaiGiaiThuong equals loaiThiDau.MaLoaiGiaiThuong

                           select new
                           {
                               MaDanhHieuCauThu = danhHieuCauThu.MaDanhHieuCauThu,
                               MaLichThiDau = lichThiDau.MaLichThiDau ,
                               TenCauThu = cauThu.TenCauThu,
                               LoaiGiaiThuong = loaiThiDau.TenLoaiGiaiThuong,
                               SoLuong = danhHieuCauThu.SoLuong,
                           };
                return Json(new { data = list.ToList() }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Xoa(int maDanhHieuCauThu)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {
                var model = _db.DanhHieuCauThus.Find(maDanhHieuCauThu);
                _db.DanhHieuCauThus.Remove(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
    }
}