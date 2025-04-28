using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using APPWEB_PracticePack.Configuration;
using APPWEB_PracticePack.Contracts.Commands;
using APPWEB_PracticePack.Services.Interfaces;

namespace APPWEB_PracticePack.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;

        public UserController(
            IUserService userService, 
            IAuthenticationService authenticationService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
        }

        // GET: Login
        public ActionResult Login(bool expired = false, string? returnUrl = null)
        {
            if (expired && returnUrl != "%2F")
            {
                ViewData["SessionExpiredMessage"] = "Your session has expired. Please log in again.";
            }

            return View();
        }

        // POST: Login
        [HttpPost]
        public async Task<ActionResult> Login (LoginContract model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _userService.Login(model);

                    await _authenticationService.LogInClaims(response);

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return View(model);
        }

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        public async Task<ActionResult> Register(RegisterContract model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _userService.Register(model);
                    return RedirectToAction("Login");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return View(model);
        }

        // GET: AccessDenied
        public ActionResult AccessDenied()
        {
            return View();
        }

        // GET: NotAccess
        public ActionResult NotAccess()
        {
            return View();
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
