using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
                                    SignInManager<ApplicationUser> signInManager
                                    )
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account",
                                new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }
        [AllowAnonymous]
        public async Task<IActionResult>
            ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            LogInViewModel loginViewModel = new LogInViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins =
                        (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if (remoteError != null)
            {
                ModelState
                    .AddModelError(string.Empty, $"Error from external provider: {remoteError}");

                return View("Login", loginViewModel);
            }

            // Get the login information about the user from the external login provider
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState
                    .AddModelError(string.Empty, "Error loading external login information.");

                return View("Login", loginViewModel);
            }

            // If the user already has a login (i.e if there is a record in AspNetUserLogins
            // table) then sign-in the user with this external login provider
            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider,
                info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (signInResult.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            // If there is no record in AspNetUserLogins table, the user may not have
            // a local account
            else
            {
                // Get the email claim value
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);

                if (email != null)
                {
                    // Create a new user without password if we do not have a user already
                    var user = await _userManager.FindByEmailAsync(email);

                    if (user == null)
                    {
                        user = new ApplicationUser
                        {
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                        };

                        await _userManager.CreateAsync(user);
                    }

                    // Add a login (i.e insert a row for the user in AspNetUserLogins table)
                    await _userManager.AddLoginAsync(user, info);
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);
                }

                // If we cannot find the user email we cannot continue
                ViewBag.ErrorTitle = $"Email claim not received from: {info.LoginProvider}";
                ViewBag.ErrorMessage = "Please contact support on Pragim@PragimTech.com";

                return View("Error");
            }
        }
        [HttpGet]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> isEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
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
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool existeUser = await _userManager.FindByEmailAsync(model.email) != null;
                if (existeUser)
                {
                    ModelState.AddModelError("", "ya existe ese usuario ingrese otro email por favor");
                    return View();
                }
                var user = new ApplicationUser { Email = model.email, UserName = model.email, city = model.city };
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action("ConfirmedLink", "Account", new
                {
                    userId = user.Id,
                    token = token
                }, Request.Scheme);
                var result = await _userManager.CreateAsync(user, model.password);
                if (result.Succeeded)
                {
                    if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListUsers", "administration");
                    }
                    ViewBag.ErrorTitle = "Registration exitosa";
                    ViewBag.ErrorMessage = "confirm your email in your inbox";
                    return View("Error");
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
            return RedirectToAction("index", "home");
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn(string returnUrl)
        {
            LogInViewModel model = new LogInViewModel();
            model.ReturnUrl = returnUrl;
            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            return View(model);
        }
#nullable enable
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn(LogInViewModel model, string? ReturnUrl)
        {
            
            model.ExternalLogins= (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.email, model.password, model.rememberMe, false);
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
            return View(model);
        }
#nullable disable

    }
}
