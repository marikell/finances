using Finances.Data.Models;
using Finances.Service.Interfaces;
using Finances.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Finances.Web.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService _service;
        private UserManager<Account> _userManager;
        private SignInManager<Account> _signInManager;
        public AccountController(IAccountService service, UserManager<Account> userManager, SignInManager<Account> signInManager)
        {
            _service = service;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            try
            {
                string logoutState = "Already logout!";
                if (User.Identity.IsAuthenticated)
                {
                    await _signInManager.SignOutAsync();
                    logoutState = "Logout successful!";
                }

                return new OkObjectResult(logoutState);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Logout error.");
            }
        }
        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = User.Identity.Name;

            return View();
        }

        [HttpGet]
        public IActionResult IsAuthenticated()
        {
            if (User.Identity.IsAuthenticated)
            {
                return new OkObjectResult("Já Autenticado!");
            }
            else
            {
                return new OkObjectResult("Não Autenticado!");
            }
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account { UserName = registerViewModel.UserName, Email = registerViewModel.Email, Description = registerViewModel.Description };
                IdentityResult identityResult = await _userManager.CreateAsync(account, registerViewModel.Password);
                if (identityResult.Succeeded)
                {
                    return new OkObjectResult("Account created.");
                }
                else
                {
                    foreach (var error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return new BadRequestResult();
        }

        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(login.Username, login.Password, true, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //Tratar o erro
                }
            }
            return new BadRequestResult();
        }
    }
}
