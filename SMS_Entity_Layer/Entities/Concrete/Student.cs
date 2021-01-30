using Microsoft.AspNetCore.Http;
using SMS_Entity_Layer.Enums;
using SMS_Entity_Layer.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SMS_Entity_Layer.Entities.Concrete
{
    public class Student : IBaseEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MinLength(2, ErrorMessage = "Mininum lenght is 2")]
        public string StudentName { get; set; }

        [Required, MinLength(2, ErrorMessage = "Mininum lenght is 7")]
        public int StudentNumber { get; set; }

       

        public string Image { get; set; }

        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }

        [Display(Name = "Lessons")]
        [Range(1, int.MaxValue, ErrorMessage = "You must to choose a Lesson")]
        public int LessonId { get; set; }
        [ForeignKey("LessonId")]
        public virtual Lesson Lesson { get; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
    }
}
