using Microsoft.AspNetCore.Mvc;
using OnlineExamination.BLL.Services;
using OnlineExamination.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamination.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public IActionResult Login()
        {
            LoginViewModel sessionObj = HttpContext.Session.Get<LoginViewModel>("loginvm");
            if (sessionObj == null)
                return View();
            else
            {
                return RedirectUser(sessionObj);
            }

                
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Set<LoginViewModel>("loginvm", null);
            return RedirectToAction("Login");
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                LoginViewModel loginVM = _accountService.Login(loginViewModel);
                if (loginVM != null)
                {
                    HttpContext.Session.Set<LoginViewModel>("loginvm", loginVM);
                    return RedirectUser(loginVM);
                }
            }
            else
                return View(loginViewModel); 

        }
        public IActionResult RedirectUser(LoginViewModel loginViewModel)
        {
            if (loginViewModel.Role == (int)EnumRoles.Admin)
            {
                return RedirectToAction("Index", "Users");
            }
            else if (loginViewModel.Role == (int)EnumRoles.Teacher)
            {
                return RedirectToAction("Index", "Exams");
            }
            return RedirectToAction("Profile", "Students");
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
