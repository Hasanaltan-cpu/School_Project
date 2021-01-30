using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SMS_Entity_Layer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_Web_Layer.Areas.Admin.Models.TagHelpers
{
    public class RoleTagHelpers
    {

        [HtmlTargetElement("td", Attributes = "user-role")]
        public class RoleTagHelper : TagHelper
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;

            public RoleTagHelper(UserManager<AppUser> userManager,
                                 RoleManager<IdentityRole> roleManager)
            {
                _userManager = userManager;
                _roleManager = roleManager;
            }

            [HtmlAttributeName("user-role")]
            public string RoleId { get; set; }

            public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
            {
                List<string> names = new List<string>();
                IdentityRole role = await _roleManager.FindByIdAsync(RoleId);

                if (role != null)
                {
                    foreach (var user in _userManager.Users)
                    {
                        if (user != null && await _userManager.IsInRoleAsync(user, role.Name))
                        {
                            names.Add(user.UserName);
                        }
                    }
                }
                output.Content.SetContent(names.Count == 0 ? "No Users" : string.Join(", ", names));
            }
        }
    }
}
