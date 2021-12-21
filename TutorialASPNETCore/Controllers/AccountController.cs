using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TutorialASPNETCore.Models;
using TutorialASPNETCore.ViewModels;

namespace TutorialASPNETCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
                                    SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet][HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> isEmailInUse(string email)
        {
            var user=await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            return Json($"The provided email is already in use");
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult>Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool existeUser = await _userManager.FindByEmailAsync(model.email)!=null;
                if (existeUser)
                {
                    ModelState.AddModelError("","ya existe ese usuario ingrese otro email por favor");
                    return View();
                }
                var user= new ApplicationUser { Email=model.email, UserName=model.email,city=model.city};
                var result=await _userManager.CreateAsync(user,model.password);
                if (result.Succeeded)
                {
                   await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                
            }
            return View();
        }
        [HttpPost]
      
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index","home");
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult LogIn()
        {
            return View();
        }
#nullable enable
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn( LogInViewModel model, string? ReturnUrl)
        {
            
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.email,model.password,model.rememberMe,false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("index", "home");
                }
               ModelState.AddModelError("", "invalid log attempt");
                

            }
            return View();
        }
#nullable disable
    }
}
