using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using fp_stack.core.Models;
using fp_stack.web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace fp_stack.web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Perguntas");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if(model.UserName == "igor" && model.Password == "123")
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, model.UserName),
                    new Claim(ClaimTypes.Role, "admin")
                };
                var id = new ClaimsIdentity(claims, "password");
                var principal = new ClaimsPrincipal(id);

                await HttpContext.SignInAsync("app", principal, new AuthenticationProperties() { IsPersistent = model.IsPersistent });

                return RedirectToAction("Index", "Perguntas");
            }

            if(model.UserName == "igor" && model.Password == "321")
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, model.UserName),
                    new Claim(ClaimTypes.Role, "peao")
                };
                var id = new ClaimsIdentity(claims, "password");
                var principal = new ClaimsPrincipal(id);

                await HttpContext.SignInAsync("app", principal, new AuthenticationProperties() { IsPersistent = model.IsPersistent });

                return RedirectToAction("Index", "Perguntas");
            }

            return View();
        }

        public async Task<IActionResult> Logoff()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}