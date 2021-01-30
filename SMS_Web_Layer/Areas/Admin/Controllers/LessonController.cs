using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SMS_Data_Layer.Repositories.Interfaces.IEntityTypeRepositories;
using SMS_Entity_Layer.Entities.Concrete;
using SMS_Entity_Layer.Enums;

namespace SMS_Web_Layer.Areas.Admin.Controllers
{
    public class LessonController : Controller
    {
      
            private readonly ILessonRepository _lessonRepo;
            public LessonController(ILessonRepository lessonRepository) => _lessonRepo = lessonRepository;

            public IActionResult Create() => View();

            [HttpPost]
            public async Task<IActionResult> Create(Lesson lesson)
            {
                if (ModelState.IsValid)
                {
                    lesson.Slug= lesson.LessonName.ToLower().Replace(" ", "-");
                    var slug = await _lessonRepo.FirstOrDefault(x => x.Slug == lesson.Slug);
                    if (slug != null)
                    {
                        ModelState.AddModelError("", "The Lesson already exsist..!");
                        TempData["Warning"] = "The lesson already exsist..!";
                        return View(lesson);
                    }
                    else
                    {
                        await _lessonRepo.Add(lesson);
                        TempData["Success"] = "The lesson added..!";
                        return RedirectToAction("List");
                    }
                }
                else
                {
                    TempData["Error"] = "The lesson hasn't been added..!";
                    return View(lesson);
                }
            }

            public async Task<IActionResult> List() => View(await _lessonRepo.Get(x => x.Status != Status.Passived));

            public async Task<IActionResult> Edit(int id) => View(await _lessonRepo.GetById(id));

            [HttpPost]
            public async Task<IActionResult> Edit(Lesson lesson)
            {
                if (ModelState.IsValid)
                {
                    lesson.Slug = lesson.LessonName.ToLower().Replace(" ", "-");
                    var slug = _lessonRepo.FirstOrDefault(x => x.Slug == lesson.Slug);
                    if (slug != null)
                    {
                        ModelState.AddModelError("", "There is already a lesson..!");
                        TempData["Warning"] = "The lesson  is already exsist..!";
                        return View(lesson);
                    }
                    else
                    {
                        lesson.UpdateDate = DateTime.Now;
                        lesson.Status = Status.Modified;
                        await _lessonRepo.Update(lesson);
                        TempData["Success"] = "The lesson has been edited..!";
                        return RedirectToAction("List");
                    }
                }
                else
                {
                    TempData["Error"] = "The lesson hasn't been edited..!";
                    return View(lesson);
                }
            }

            public async Task<IActionResult> Remove(int id)
            {
                Lesson  lesson = await _lessonRepo.GetById(id);
                if (lesson != null)
                {
                    await _lessonRepo.Delete(lesson);
                    TempData["Success"] = "The lesson deleted..!";
                    return RedirectToAction("List");
                }
                else
                {
                    TempData["Error"] = "The lesson hasn't been deleted..!";
                    return RedirectToAction("List");
                }
            }
        }
    }

