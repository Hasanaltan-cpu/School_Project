using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SMS_Data_Layer.Repositories.Interfaces.IEntityTypeRepositories;
using SMS_Entity_Layer.Entities.Concrete;
using SMS_Entity_Layer.Enums;

namespace SMS_Web_Layer.Areas.Admin.Controllers
{
    public class StudentController : Controller
    {
        public class ProductController : Controller
        {
            private readonly IStudentRepository  _studentRepo;
            private readonly ILessonRepository _lessonRepo;
            private readonly IWebHostEnvironment _webHostEnvironment;

            public ProductController(IStudentRepository studentRepository,
                                     ILessonRepository lessonRepository,
                                     IWebHostEnvironment webHostEnvironment)
            {
                _lessonRepo = lessonRepository;
                _studentRepo = studentRepository;
                _webHostEnvironment = webHostEnvironment;
            }


            public async Task<IActionResult> Create()
            {
                ViewBag.CategoryId = new SelectList(await _lessonRepo.Get(x => x.Status != Status.Passived), "Id", "Name");
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Create(Student student)
            {
                if (ModelState.IsValid)
                {
                    string imageName = "noimage.png";
                    if (student.ImageUpload != null)
                    {
                        string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");
                        imageName = Guid.NewGuid().ToString() + "_" + student.ImageUpload.FileName;
                        string filePath = Path.Combine(uploadDir, imageName);
                        FileStream fileStream = new FileStream(filePath, FileMode.Create);
                        await student.ImageUpload.CopyToAsync(fileStream);
                        fileStream.Close();
                    }

                    student.Image = imageName;
                    await _studentRepo.Add(student);
                    TempData["Success"] = "The product add..!";
                    return View();
                }
                else
                {
                    TempData["Error"] = "The product hasn't been add..!";
                    return View(student);
                }
            }

            public async Task<IActionResult> List() => View(await _studentRepo.Get(x => x.Status != Status.Passived));

            public async Task<IActionResult> Edit(int id)
            {
                Student product = await _studentRepo.GetById(id);

                ViewBag.LessonId = new SelectList(await _lessonRepo.Get(x => x.Status != Status.Passived), "Id", "Name", product.LessonId);

                return View(product);
            }

            [HttpPost]
            public async Task<IActionResult> Edit(Student student)
            {
                if (ModelState.IsValid)
                {
                    if (student.ImageUpload != null)
                    {
                        string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");

                        if (!string.Equals(student.Image, "noimage.png"))
                        {
                            string oldPath = Path.Combine(uploadDir, student.Image);
                            if (System.IO.File.Exists(oldPath))
                            {
                                System.IO.File.Delete(oldPath);
                            }
                        }

                        string imageName = Guid.NewGuid().ToString() + "_" + student.ImageUpload.FileName;
                        string filePath = Path.Combine(uploadDir, imageName);
                        FileStream fileStream = new FileStream(filePath, FileMode.Create);
                        await student.ImageUpload.CopyToAsync(fileStream);
                        fileStream.Close();
                        student.Image = imageName;


                    }
                    await _studentRepo.Update(student);
                    TempData["Success"] = "The product edited..!";
                    return RedirectToAction("List");
                }
                else
                {
                    TempData["Error"] = "The product hasn't been edited..!";
                    return View(student);
                }
            }

            public async Task<IActionResult> Delete(int id)
            {
                Student student = await _studentRepo.GetById(id);

                if (student != null)
                {
                    await _studentRepo.Delete(student);
                    TempData["Success"] = "The Student deleted..!";
                    return RedirectToAction("List");
                }
                else
                {
                    TempData["Error"] = "The Student hasn't been deleted..!";
                    return RedirectToAction("List");
                }
            }

        }
    }
}
