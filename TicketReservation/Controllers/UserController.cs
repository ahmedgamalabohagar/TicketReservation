using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TicketReservation.Models;

namespace TicketReservation.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LogUserVM userVM)
        {
            if (!ModelState.IsValid)
                return View(userVM);
            var user = _userManager.FindByEmailAsync(userVM.Email).Result;
            if (user != null)
            {
                if (_userManager.CheckPasswordAsync(user, userVM.Pass).Result)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, userVM.Pass, userVM.RememberMe, false);
                    if (result.Succeeded) return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Incorrect E-mail Or Password");
            return View(userVM);
        }

        public ActionResult Registartion()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registartion(UserVM model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = new AppUser
            {
                Email = model.Email,
                Agree = model.Agree,
                UserName = model.UserName,
                Role = "User"
            };
            var result = _userManager.CreateAsync(user, model.Password).Result;
            if (result.Succeeded)
                return Redirect(nameof(Login));
            else
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            return View(model);
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
