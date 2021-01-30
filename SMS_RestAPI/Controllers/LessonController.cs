using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS_RestAPI.DataAccess.ProjectContext;
using SMS_RestAPI.Entities.Enums;
using SMS_RestAPI.Models;

namespace SMS_RestAPI.Controllers
{
    public class LessonController : Controller
    {
        [Produces("application/json")]
        [Route("api/[controller]")]
        [ApiController]
        public class CategoryController : ControllerBase
        {
            private readonly ApplicationDbContext _applicationDbContext;

            public CategoryController(ApplicationDbContext applicationDbContext) => _applicationDbContext = applicationDbContext;

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            public async Task<IEnumerable<Lesson>> GetLessons() => await _applicationDbContext.Lessons.Where(x => x.Status != Status.Passived).OrderBy(x => x.Id).ToListAsync();

            /// <summary>
            /// 
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            [HttpGet("{id:int}", Name = "GetLessonById")]
            public async Task<ActionResult<Lesson>> GetLessonById(int id)
            {
                Lesson lesson = await _applicationDbContext.Lessons.FindAsync(id);

                if (lesson == null) return NotFound();

                return Ok(lesson);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="lessonSlug"></param>
            /// <returns></returns>
            [HttpGet("{lessonSlug}", Name = "GetLessonBySlug")]
            public async Task<ActionResult<Lesson>> GetLessonBySlug(string lessonSlug)
            {
                Lesson  lesson = await _applicationDbContext.Lessons.FirstOrDefaultAsync(x => x.Slug == lessonSlug);

                if (lesson == null) return NotFound();

                return Ok(lesson);
            }

            /// <summary>
            /// This method help to you insert category into database
            /// </summary>
            /// <param name="lesson">
            ///     name* string
            ///     minLength: 2
            ///     pattern: ^[a-zA-Z]+$
            ///     slug* string
            ///     createDate*  string ($date-time)
            ///     status Statusinteger($int32)
            ///     Enum:[ 1, 2, 3 ]
            /// </param>
            /// <returns></returns>
            [HttpPost]
            public async Task<ActionResult<Lesson>> PostLesson(Lesson lesson)
            {
                _applicationDbContext.Lessons.Add(lesson);
                await _applicationDbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetLessons), lesson);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="id"></param>
            /// <param name="lesson"></param>
            /// <returns></returns>
            [HttpPut("{id}", Name = "PutLesson")]
            public async Task<ActionResult<Lesson>> PutCategory(int id, Lesson lesson)
            {
                if (id != lesson.Id) return BadRequest();

                _applicationDbContext.Entry(lesson).State = EntityState.Modified;

                await _applicationDbContext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetLessons), lesson);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            [HttpDelete("{id}", Name = "DeleteLesson")]
            public async Task<ActionResult<Lesson>> DeleteLesson(int id)
            {
                Lesson lesson = await _applicationDbContext.Lessons.FindAsync(id);

                if (lesson == null) return NotFound();

                _applicationDbContext.Lessons.Remove(lesson);
                await _applicationDbContext.SaveChangesAsync();

                return NoContent(); //=> 204 status code
            }
        }
    }
}
