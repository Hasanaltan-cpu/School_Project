using SMS_Entity_Layer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SMS_Entity_Layer.Entities.Concrete
{
    public class Lesson : IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Must type a title")]
        [MinLength(2, ErrorMessage = "Minimum lenght is 2")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only allowed letters")]
        public string LessonName { get; set; }

        public string Slug { get; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }

        public List<Student> Students { get; set; }
    }
}
