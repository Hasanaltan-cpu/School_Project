using SMS_Web_Layer.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_Web_Layer.Models.Vms
{
    public class CartViewModel
    {
        public CartViewModel()
        {
            CartItems = new List<CartItem>();
        }

        public List<CartItem> CartItems { get; set; }
        public decimal TotalLessons { get; set; }
    }
}
