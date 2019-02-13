using Finances.Data.Models;
using Finances.Service.Interfaces;
using Finances.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finances.Web.Controllers
{
    [Route("api/[controller]")]
    public class UserController: Controller
    {
        private UserManager<User> _userManager;
        private IUserService _service;
        public UserController(IUserService service, UserManager<User> userManager)
        {
            _userManager = userManager;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegisterViewModel registerViewModel)
        {
            User user = new User { UserName = registerViewModel.UserName, Email = registerViewModel.Email, CelUser = registerViewModel.CelUser };

            IdentityResult identityResult = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (identityResult.Succeeded)
            {
                return new OkObjectResult("Account created.");
            }
            else
            {
                return new BadRequestObjectResult("User creation error.");
            }
        }
    }
}
