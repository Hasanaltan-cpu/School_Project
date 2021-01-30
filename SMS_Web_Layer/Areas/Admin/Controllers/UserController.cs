using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SMS_Entity_Layer.Entities.Concrete;

namespace SMS_Web_Layer.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager) => _userManager = userManager;

        public IActionResult Index() => View(_userManager.Users);
    }
}
