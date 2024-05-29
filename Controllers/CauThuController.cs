using SportsLeague.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SportsLeague.Controllers
{
    public class CauThuController : Controller
    {
        // GET: CauThu
        private SportLeagueContext _db;

        public ActionResult CheckLogin()
        {
            //Kiểm tra xem session có tồn tại hay không.
            if (Session != null)
            {
                //Lấy thông tin người dùng từ session nếu có.
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
                var list = from p in _db.CauThus
                           select new
                           {
                               MaCauThu = p.MaCauThu,
                               TenCauThu = p.TenCauThu,
                               Avatar = p.Avatar,
                               NgaySinh = p.NgaySinh.ToString(),
                               ChieuCao = p.ChieuCao,
                               QuocTich = p.QuocTich,
                               ViTriThiDau = p.ViTriThiDau
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
        public ActionResult DangKy(CauThu cauThu, HttpPostedFileBase Avatar)
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

                    // Thêm xuống database
                    cauThu.Avatar = path;
                    _db.CauThus.Add(cauThu);
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
        public ActionResult DanhSachCauThu()
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {
                List<CauThu> ketQua = _db.CauThus.ToList();
                return View(ketQua);
            }

        }
        public ActionResult CapNhat(int maCauThu)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {

                // Lấy thông tin cầu thủ cần cập nhật và trả về cho view
                var DSModel = _db.CauThus.Find(maCauThu);
                return View(DSModel);
            }
        }
        [HttpPost]
        public ActionResult CapNhat(CauThu model, HttpPostedFileBase Avatar)
        {
            try
            {

                using (_db = new SportLeagueContext())

                {

                    var cauThu = _db.CauThus.Find(model.MaCauThu);

                    Random r = new Random();
                    string path = "-1";
                    int random = r.Next();
                    if (Avatar != null && Avatar.ContentLength > 0) // Kiểm tra xem có upload Avatar mới không?
                    {
                        string extension = Path.GetExtension(Avatar.FileName);
                        if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                        {
                            try
                            {
                                path = Path.Combine(Server.MapPath("~/Content/upload/"), random + Path.GetFileName(Avatar.FileName));
                                Avatar.SaveAs(path);
                                path = "Content/upload/" + random + Path.GetFileName(Avatar.FileName);
                                cauThu.Avatar = path;
                            }
                            catch (Exception ex)
                            {
                                path = "-1";
                            }

                        }
                    }

                   
                    cauThu.TenCauThu = model.TenCauThu;
                  
                    cauThu.NgaySinh = model.NgaySinh;
                    cauThu.ChieuCao = model.ChieuCao;
                    cauThu.QuocTich = model.QuocTich;
                    cauThu.ViTriThiDau = model.ViTriThiDau;
                    _db.SaveChanges();
                   
                    return RedirectToAction("CapNhat", new { maCauThu = cauThu.MaCauThu });

                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

        }
        public ActionResult Xoa(int maCauThu)
        {
            #region Kiểm tra đăng nhập và quyền
            var loginResult = CheckLogin();
            if (loginResult != null)
                return loginResult; // Chuyển hướng nếu kiểm tra đăng nhập không hợp lệ
            #endregion
            using (_db = new SportLeagueContext())
            {
                var model = _db.CauThus.Find(maCauThu);
                _db.CauThus.Remove(model);
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