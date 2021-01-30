using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SMS_Entity_Layer.Entities.Concrete;
using SMS_Web_Layer.Areas.Admin.Models.DTOs;

namespace SMS_Web_Layer.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(UserManager<AppUser> userManager,
                             RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index() => View(_roleManager.Roles);

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([MinLength(2, ErrorMessage ="Minimum lebght is 2"),
                                                Required(ErrorMessage ="Must to into role name")] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult ıdentityResult = await _roleManager.CreateAsync(new IdentityRole(name));
                if (ıdentityResult.Succeeded)
                {
                    TempData["Success"] = "The role has been created..!";
                    return RedirectToAction("Index");
                }
                else foreach (IdentityError error in ıdentityResult.Errors) ModelState.AddModelError("", error.Description);
            }

            TempData["Error"] = "The role hasm't been created..!";
            return View(name);
        }

        public async Task<IActionResult> Edit(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);

            List<AppUser> hasRole = new List<AppUser>();
            List<AppUser> hasNotRole = new List<AppUser>();

            foreach (AppUser user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? hasRole : hasNotRole;
                list.Add(user);
            }

            return View(new RoleEdit { Role = role, HasRole = hasRole, HasNotRole = hasNotRole });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoleEdit roleEdit)
        {
            IdentityResult result;

            foreach (var userId in roleEdit.AddIds)
            {
                AppUser appUser = await _userManager.FindByIdAsync(userId);
                result = await _userManager.AddToRoleAsync(appUser, roleEdit.RoleName);
            }

            foreach (var userId in roleEdit.DeleteIds)
            {
                AppUser appUser = await _userManager.FindByIdAsync(userId);
                result = await _userManager.RemoveFromRoleAsync(appUser, roleEdit.RoleName);
            }

            return RedirectToAction("Index");
        }
    }
}
