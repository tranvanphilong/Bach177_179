﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebDemo14112023.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(Request.Query["ReturnUrl"].ToString()))
            {
                Redirect("" + Request.Query["ReturnUrl"]);
            }
            return View();
        }

        public IActionResult Logout()
        {
            // Đăng xuất người dùng
            HttpContext.SignOutAsync("Admin");
            SetAlert("Đăng xuất thành công!", "success");
            // Chuyển hướng đến trang đăng nhập hoặc trang chính
            return RedirectToAction("Index", "Login", new { area = "Admin" }); // Thay thế bằng tên trang đăng nhập hoặc trang chính của bạn
        }
    }
}
