using SportsLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsLeague.Controllers
{
    public class QuanLyDoiBongVaCauThuController : Controller
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
        public ActionResult Them(QuanLyDoiBongVaCauThu quanLyDoiBongVaCauThu)
        {
            try
            {
                using (_db = new SportLeagueContext())
                {
                    // Thêm xuống database
                    _db.QuanLyDoiBongVaCauThus.Add(quanLyDoiBongVaCauThu);
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

        public ActionResult GetData(int maDoiBong)
        {
            //#region Kiểm tra đăng nhập và quyền
            //var loginResult = CheckLogin();
            //if (loginResult != null)
            //    return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            //#endregion
            using (_db = new SportLeagueContext())
            {
                var list = from p in _db.QuanLyDoiBongVaCauThus
                           where p.MaDoiBong== maDoiBong 
                           join cauThu in _db.CauThus on p.MaCauThu equals cauThu.MaCauThu
                           select new
                           {
                               MaCauThu = cauThu.MaCauThu,
                               Avatar = cauThu.Avatar,
                               TenCauThu = cauThu.TenCauThu,
                               QuocTich= cauThu.QuocTich,
                               ViTriThiDau = cauThu.ViTriThiDau,             
                               SoAo = p.SoAo
                           };              

                return Json(new { data = list.ToList() }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Xoa(int maDoiBong, int maCauThu)
        {
            //#region Kiểm tra đăng nhập và quyền
            //var loginResult = CheckLogin();
            //if (loginResult != null)
            //    return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            //#endregion
            using (_db = new SportLeagueContext())
            {
                var model = _db.QuanLyDoiBongVaCauThus.FirstOrDefault(x => x.MaDoiBong == maDoiBong && x.MaCauThu == maCauThu);
                if(model != null)
                {
                    _db.QuanLyDoiBongVaCauThus.Remove(model);
                    _db.SaveChanges();
                }
                return RedirectToAction("CapNhat","DoiBong",new { maDoiBong = maDoiBong });
            }
        }

    }
}