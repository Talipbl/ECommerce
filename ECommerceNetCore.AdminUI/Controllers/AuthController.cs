using ECommerceNetCore.Application;
using ECommerceNetCore.Application.DataTransferObjects;
using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.SqlServer;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ECommerceNetCore.AdminUI.Controllers
{
    public class AuthController : Controller
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var result = _authService.Login(login);
            if (!result.Success)
                return View();


            List<Claim> claims = new List<Claim>();
            claims.AddNameIdentifier(result.Data.Id.ToString());
            claims.AddName(result.Data.FullName);
            claims.AddRoles(new string[] { result.Data.SecurityLevel.ToString() });
            ClaimsIdentity identity = new ClaimsIdentity(claims, "login");
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);

            var crypto = AesCrypto.Encrpty(result.Data.SecurityLevel.ToString(), "develop");
            HttpContext.Session.SetObject("level", crypto);

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult LogOut()
        {

            return View();
        }
    }
}
