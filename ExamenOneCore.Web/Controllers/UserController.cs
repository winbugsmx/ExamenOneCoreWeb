using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenOneCore.Entity.Models;
using ExamenOneCore.Web.App_Code;
using ExamenOneCore.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

namespace ExamenOneCore.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;

        public UserController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
        }

        // GET: User
        public ActionResult Index()
        {
            var statusSelectLists = new[]
{
                new SelectListItem(){Value = "True", Text= "Activo"},
                new SelectListItem(){Value = "False", Text= "Inactivo"},
            };

            var sexSelectLists = new[]
{
                new SelectListItem(){Value = "F", Text= "Femenino"},
                new SelectListItem(){Value = "M", Text= "Masculino"},
            };

            ViewBag.StatusSelectLists = statusSelectLists;
            ViewBag.SexSelectLists = sexSelectLists;
            return View();
        }

        // GET: User/GetUsers
        public async Task<IActionResult> GetUsers()
        {
            List<UsuarioModel> usersList = (List<UsuarioModel>)await ApiClientFactory.Instance.GetUsers();
            return Json(usersList);
        }

        //// GET: User/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: User/Create
        public ActionResult Create()
        {
            var statusSelectLists = new[]
            {
                new SelectListItem(){Value = "True", Text= "Activo"},
                new SelectListItem(){Value = "False", Text= "Inactivo"},
            };

            var sexSelectLists = new[]
{
                new SelectListItem(){Value = "F", Text= "Femenino"},
                new SelectListItem(){Value = "M", Text= "Masculino"},
            };

            ViewBag.StatusSelectLists = statusSelectLists;
            ViewBag.SexSelectLists = sexSelectLists;

            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioModel model)
        {
            model.FechaCreacion = DateTime.Now;
            model.FechaActualizacion = DateTime.Now;

            var statusSelectLists = new[]
{
                new SelectListItem(){Value = "True", Text= "Activo"},
                new SelectListItem(){Value = "False", Text= "Inactivo"},
            };

            var sexSelectLists = new[]
{
                new SelectListItem(){Value = "F", Text= "Femenino"},
                new SelectListItem(){Value = "M", Text= "Masculino"},
            };

            ViewBag.StatusSelectLists = statusSelectLists;
            ViewBag.SexSelectLists = sexSelectLists;

            if (ModelState.IsValid)
            {
                try
                {
                    model.Password = Security.Encrypt(model.Password.ToString());
                    await ApiClientFactory.Instance.CreateUser(model);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View(model);
                }
            }

            var validationErrors = ModelState.Values.Where(E => E.Errors.Count > 0)
                .SelectMany(E => E.Errors)
                .Select(E => E.ErrorMessage)
                .ToList();

            ViewBag.LoginErrors = validationErrors;
            ModelState.AddModelError("", "Datos inválidos");

            return View(model);
        }

        // POST: User/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(EditUsuarioModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await ApiClientFactory.Instance.UpdateUser(model);
                    if (model.ChangePassword)
                    {
                        model.Password = Security.Encrypt(model.Password.ToString());
                        ChangePasswordModel changePasswordModel = new ChangePasswordModel() { UserId = model.UserId, Password = model.Password };
                        await ApiClientFactory.Instance.ChangePassword(changePasswordModel);
                    }
                    return Json(new ResponseModel()
                    {
                        ReturnCode = Response.StatusCode,
                        Message = "Se actualizaron los datos correctamente."
                    });
                }
                catch
                {
                    return Json(new ResponseModel()
                    {
                        ReturnCode = Response.StatusCode,
                        Message = "Ocurrió un error al actualizar la información."
                    });
                }
            }
            return Json(new ResponseModel()
            {
                ReturnCode = Response.StatusCode,
                Message = "Debe de capturar todos los campos solicitados."
            });
        }

        // GET: User/VerificaUsuario
        public async Task<IActionResult> VerificaUsuario(string username, int userid)
        {
            EditUsuarioModel model = new EditUsuarioModel() { Username = username, ConfirmPassword = string.Empty, Password = string.Empty, Email = string.Empty, Estatus = true, FechaActualizacion = DateTime.Now, FechaCreacion = DateTime.Now, Sexo = string.Empty, UserId = userid };

            string response = await ApiClientFactory.Instance.VerificaUsuario(model);

            return Json(new ResponseModel()
            {
                ReturnCode = Response.StatusCode,
                Message = response
            });
        }

        // GET: User/VerificaEmail
        public async Task<IActionResult> VerificaEmail(string email, int userid)
        {
            EditUsuarioModel model = new EditUsuarioModel() { Username = string.Empty, ConfirmPassword = string.Empty, Password = string.Empty, Email = email, Estatus = true, FechaActualizacion = DateTime.Now, FechaCreacion = DateTime.Now, Sexo = string.Empty, UserId = userid };

            string response = await ApiClientFactory.Instance.VerificaEmail(model);

            return Json(new ResponseModel()
            {
                ReturnCode = Response.StatusCode,
                Message = response
            });
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteUsuarioModel model)
        {
            try
            {
                await ApiClientFactory.Instance.Delete(model);

                return Json(new ResponseModel()
                {
                    ReturnCode = Response.StatusCode,
                    Message = "Se actualizaron los datos correctamente."
                });
            }
            catch
            {
                return View();
            }
        }
    }
}