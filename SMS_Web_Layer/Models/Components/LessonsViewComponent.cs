using Microsoft.AspNetCore.Mvc;
using SMS_Data_Layer.Repositories.Interfaces.IEntityTypeRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_Web_Layer.Models.Components
{
    public class LessonsViewComponent:ViewComponent
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonsViewComponent(ILessonRepository lessonRepository) => _lessonRepository = lessonRepository;

        public async Task<IViewComponentResult> InvokeAsync() => View(await _lessonRepository.GetAll());

    }
}
