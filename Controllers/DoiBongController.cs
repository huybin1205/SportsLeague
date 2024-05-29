using SportsLeague.Models;
using SportsLeague.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SportsLeague.Controllers
{
    public class DoiBongController : Controller
    {
        // GET: DoiBong
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
                var list = from p in _db.DoiBongs
                           select new
                           {
                               MaDoiBong = p.MaDoiBong,
                               TenDoiBong = p.TenDoiBong,
                               Logo = p.Logo,
                               NguoiQuanLyCLB = p.NguoiQuanLyCLB,
                               DoiTruong = p.DoiTruong,
                               ViTri = p.ViTri
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
        public ActionResult DangKy(DoiBong doiBong, HttpPostedFileBase Logo)
        {
            try
            {
                Random r = new Random();
                string path = "-1";
                int random = r.Next();
                if (Logo != null && Logo.ContentLength > 0)
                {
                    string extension = Path.GetExtension(Logo.FileName);
                    if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                    {
                        try
                        {
                            path = Path.Combine(Server.MapPath("~/Content/upload/"), random + Path.GetFileName(Logo.FileName));
                            Logo.SaveAs(path);
                            path = "Content/upload/" + random + Path.GetFileName(Logo.FileName);
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
                    // Thêm xuống database
                    doiBong.Logo = path;
                    _db.DoiBongs.Add(doiBong);
                    // Lưu
                    _db.SaveChanges();
                }

                // Return
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult DanhSachDoiBong()
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion

            using (_db = new SportLeagueContext())
            {
                List<DoiBong> ketQua = _db.DoiBongs.ToList();
                return View(ketQua);
            }

        }

        public ActionResult CapNhat(int maDoiBong, int IsTeam = 0)
        {
            #region Kiểm tra đăng nhập và quyền
            var user = Session["UserLogin"] as SportsLeague.Models.NguoiDung;
            if (user == null)
            {
                return Redirect("/NguoiDung/Login");
            }
            #endregion

            using (_db = new SportLeagueContext())
            {
                //var DSModel = _db.DoiBongs.Find(maDoiBong);
                ////lay cau thu
                //ViewBag.DsCauThu = _db.CauThus.ToList();
                //ViewBag.IsTeam = IsTeam;
                //return View(DSModel);


                var DSModel = _db.DoiBongs.Find(maDoiBong);

                // Lấy danh sách ID của cầu thủ đã thêm vào đội bóng hiện tại
                var dsCauThuDaThemIds = _db.QuanLyDoiBongVaCauThus
                    .Where(ctdb => ctdb.MaDoiBong == maDoiBong)
                    .Select(ctdb => ctdb.MaCauThu)
                    .ToList();

                // Lấy toàn bộ danh sách cầu thủ chưa thuộc đội bóng nào
                var dsCauThuChuaThuocDoiBong = _db.CauThus
                    .Where(ct => !dsCauThuDaThemIds.Contains(ct.MaCauThu))
                    .ToList();

                ViewBag.DsCauThu = dsCauThuChuaThuocDoiBong;
                ViewBag.IsTeam = IsTeam;
                return View(DSModel);
            }
        }
        [HttpPost]
        public ActionResult CapNhat(DoiBong model, HttpPostedFileBase Logo)
        {
            try
            {
                using (_db = new SportLeagueContext())
                {
                    var doiBong = _db.DoiBongs.Find(model.MaDoiBong);

                    Random r = new Random();
                    string path = "-1";
                    int random = r.Next();
                    if (Logo != null && Logo.ContentLength > 0) // Kiểm tra xem có upload logo mới không?
                    {
                        string extension = Path.GetExtension(Logo.FileName);
                        if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                        {
                            try
                            {
                                path = Path.Combine(Server.MapPath("~/Content/upload/"), random + Path.GetFileName(Logo.FileName));
                                Logo.SaveAs(path);
                                path = "Content/upload/" + random + Path.GetFileName(Logo.FileName);
                                doiBong.Logo = path;
                            }
                            catch (Exception ex)
                            {
                                path = "-1";
                            }

                        }
                    }

                    doiBong.TenDoiBong = model.TenDoiBong;
                    doiBong.NguoiQuanLyCLB = model.NguoiQuanLyCLB;
                    doiBong.DoiTruong = model.DoiTruong;
                    doiBong.ViTri = model.ViTri;

                    _db.SaveChanges();

                    return RedirectToAction("CapNhat", new { maDoiBong = doiBong.MaDoiBong });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

        }
        public ActionResult Xoa(int maDoiBong)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion

            using (_db = new SportLeagueContext())
            {
                var model = _db.DoiBongs.Find(maDoiBong);
                _db.DoiBongs.Remove(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        public string uploadimage(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Content/upload"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Content/upload" + random + Path.GetFileName(file.FileName);
                        //viewbag.message = "file upload successfully";
                    }
                    catch (Exception ex)
                    {
                        path = "-1";
                    }

                }
                else
                {
                    Response.Write("<scrip>alert('Only jpg,jepg or png formats are acceptable');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please select a file');</script>");
                path = "-1";
            }
            return path;
        }
    }
}