using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HRmanagement.BLL;
using HRmanagement.BLL.DTO.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace HRmanagement.Controllers
{
    public class UserManagementController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register(string Email, string Username, string Password, string ConfirmPassword)
        {
            if (Email == null && Username == null && Password == null && ConfirmPassword == null)
            {
                return View();
            }

            UserBLL bll = new UserBLL();
            RegisterUserResponse regResponse = bll.Register(Email, Username, Password, ConfirmPassword);

            if (!regResponse.Success)
            {
                throw new NotImplementedException();
            }

            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Authenticate(string UserName, string Password, bool StayLogged)
        {
            UserBLL bll = new UserBLL();
            AuthenticationResponseDto dto = bll.LoginAuthentication(UserName, Password);

            // Check if login successful
            if (!dto.Success)
            {
                return RedirectToAction("Login");
            }

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(dto.Claims, "UserIdentity");
            ClaimsPrincipal principal = new ClaimsPrincipal(new[] { claimsIdentity });

            HttpContext.SignInAsync(principal);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
