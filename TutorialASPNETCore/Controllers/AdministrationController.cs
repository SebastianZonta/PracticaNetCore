using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TutorialASPNETCore.Models;
using TutorialASPNETCore.ViewModels;

namespace TutorialASPNETCore.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager,
                                        UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRolViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.rolName
                };
                var result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "administration");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role=await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with id {id} doesn't exists";
                return View("NotFound");
            }
            var model = new EditRoleViewModel
            {
                id = id,
                nameRole = role.Name
               
            };
            foreach (var item in await userManager.Users.ToListAsync())
            {

                if (await userManager.IsInRoleAsync(item, role.Name))
                {
                    model.users.Add(item.UserName);
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(EditRoleViewModel model)
        {
            
            
            var role = await roleManager.FindByIdAsync(model.id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with id {model.id} doesn't exists";
                return View("NotFound");
            }
            else
            {
                role.Name=model.nameRole;
                var result=await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(model);
            }
            
            
        }
        
    }
}
