using Microsoft.AspNetCore.Mvc;
using SMS_Web_Layer.Models.DTOs;
using SMS_Web_Layer.Models.Extension;
using SMS_Web_Layer.Models.Vms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_Web_Layer.Models.Components
{
    public class SmallCartViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            SmallCartViewModel smallCartViewModel;

            if (cart == null || cart.Count == 0)
            {
                smallCartViewModel = null;
            }
            else
            {
                smallCartViewModel = new SmallCartViewModel
                {
                    NumberOfStudents = cart.Sum(x => x.StudentNumber)
                };
            }

            return View(smallCartViewModel);
        }


    }
}
