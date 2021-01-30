using SMS_Entity_Layer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_Web_Layer.Models.DTOs
{
    public class CartItem
    {

        public int StudentNumber { get; set; }
        public string StudentName { get; set; }
    
        public string Image { get; set; }

        public CartItem() { }

        public CartItem(Student student)
        {
            StudentNumber = student.StudentNumber;
            StudentName = student.StudentName;
            Image = student.Image;
        }
    }
}
