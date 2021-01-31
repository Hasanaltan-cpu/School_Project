using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentPage.Models;

namespace StudentPage.Controllers
{
    public class LessonController : Controller
    {

        public async Task<IActionResult> Index()
        {
            List<Lesson> lessons = new List<Lesson>();

            using (var httpClient = new HttpClient())
            {
                using var request = await httpClient.GetAsync("http://localhost:53007/api/lesson");
                string response = await request.Content.ReadAsStringAsync();

                lessons = JsonConvert.DeserializeObject<List<Lesson>>(response);
            }
            return View(lessons);
        }

        public IActionResult List() => View();

        [HttpPost]
        public async Task<ActionResult<Lesson>> List(Lesson lesson)
        {
            lesson.Slug = lesson.Name.ToLower();

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(lesson), Encoding.UTF32, "application/json");

                using var request = await httpClient.PostAsync("http://localhost:53007/api/lesson", content);

                string response = await content.ReadAsStringAsync();

            }

            return RedirectToAction("Index");
        }
      
    }
}
