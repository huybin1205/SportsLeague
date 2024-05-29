using Microsoft.Ajax.Utilities;
using SportsLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsLeague.Providers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorizeFilterAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // Kiểm tra xem người dùng có đăng nhập hay không
            if (httpContext.Session["UserLogin"] == null)
            {
                // Nếu chưa đăng nhập, chuyển hướng đến trang đăng nhập
                httpContext.Response.Redirect("/NguoiDung/Login");
                return false;
            }

            using (var _dbContext = new SportLeagueContext())
            {
                var user = httpContext.Session["UserLogin"] as SportsLeague.Models.NguoiDung;
                var phanQuyen = _dbContext.PhanQuyenNguoiDungs.FirstOrDefault(x => x.MaNguoiDung == user.MaNguoiDung);

                // Kiểm tra quyền của người dùng
                if (phanQuyen != null)
                {
                    if (phanQuyen.VaiTro.TenVaiTro != "Admin")
                    {
                        // Nếu không phải là Admin, chuyển hướng đến trang cập nhật đội bóng
                        httpContext.Response.Redirect("/DoiBong/CapNhat?maDoiBong=" + phanQuyen.MaDoiBong + "&IsTeam=1");
                        return false;
                    }
                }
            }

            // Nếu không có quyền nào phù hợp, chuyển hướng về trang chủ hoặc trang lỗi tùy vào yêu cầu của bạn
            httpContext.Response.Redirect("/Home/Index");
            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("/NguoiDung/Login");
        }
    }
}