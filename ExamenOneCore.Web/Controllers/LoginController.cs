using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExamenOneCore.Entity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using ExamenOneCore.Web.Models;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using ExamenOneCore.Web.App_Code;

namespace ExamenOneCore.Web.Controllers
{
    public class LoginController : Controller
    {
        public const string AuthControllerAuthId = "AuthControllerAuthId";

        private readonly IOptions<MySettingsModel> appSettings;

        public LoginController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View("~/Views/Shared/Login.cshtml");
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]//IFormCollection
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Password = Security.Encrypt(model.Password.ToString());
                    string response = await ApiClientFactory.Instance.Login(model);

                    if (response.Equals("\"FAIL\""))
                        return RedirectToAction(nameof(Index));

                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Username),
                    };

                    ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    AuthenticationProperties authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                        IsPersistent = true,
                    };

                    await HttpContext.SignInAsync(AuthControllerAuthId, principal, authProperties);

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    return View();
                }
            }
            var validationErrors = ModelState.Values.Where(E => E.Errors.Count > 0)
                .SelectMany(E => E.Errors)
                .Select(E => E.ErrorMessage)
                .ToList();

            ViewBag.LoginErrors = validationErrors;
            ModelState.AddModelError("", "Invalid login attempt");

            return View(model);
        }

        public async Task<IActionResult> Logout(string requestPath)
        {
            await HttpContext.SignOutAsync(AuthControllerAuthId);

            return RedirectToAction("Index", "Login");
        }
    }
}