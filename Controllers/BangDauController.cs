using SportsLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsLeague.Controllers
{
    public class BangDauController : Controller
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

        public ActionResult Index(int maGiaiDau)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion

            using (_db = new SportLeagueContext())
            {
                var giaiDau = _db.QuanLyGiaiDaus.Find(maGiaiDau);

                var list = (from bangDauVaDoiBongs in _db.BangDauVaDoiBongs

                            join doiBong in _db.DoiBongs on bangDauVaDoiBongs.MaDoiBong equals doiBong.MaDoiBong into bdvbDb
                            from doiBong in bdvbDb.DefaultIfEmpty()

                            join bangDau in _db.BangDaus on bangDauVaDoiBongs.MaBangDau equals bangDau.MaBangDau into bdvbBd
                            from bangDau in bdvbBd.DefaultIfEmpty()

                            where bangDau.MaGiaiDau == maGiaiDau
                            select new
                            {
                                bangDau.MaBangDau,
                                bangDau.TenBangDau,
                                DoiBong = doiBong // Lấy cả đối tượng đội bóng
                            }).GroupBy(x => new { x.MaBangDau, x.TenBangDau })
                            .Select(g => new BangDauViewModel()
                            {
                                MaBangDau = g.Key.MaBangDau,
                                TenBangDau = g.Key.TenBangDau,
                                DoiBongs = g.Select(x => x.DoiBong).ToList()
                            })
                            .ToList();

                ViewBag.GiaiDau = giaiDau;
                
                return View(list);
            }
        }
    }
}