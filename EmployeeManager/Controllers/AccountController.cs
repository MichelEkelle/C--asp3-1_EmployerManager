using EmployeeManager.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Controllers
{
   
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager ,
                                 SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult RegisterView()
        {
            return View();
        }
        
        [HttpPost]
        public  async Task<IActionResult> RegisterView(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid) 
            {
                var user = new IdentityUser{UserName = registerModel.Email ,
                                               Email = registerModel.Email};
                var result = await _userManager.CreateAsync(user, registerModel.PassWord);
                if (result.Succeeded)
                {
                   await _signInManager.SignInAsync(user,isPersistent: false);
                    return RedirectToAction("AllEmployeeView","home");
                }
                foreach (var error in result.Errors) 
                {
                    ModelState.AddModelError("",error.Description);
                }
            }
            return View(registerModel);
        }
    }
}
