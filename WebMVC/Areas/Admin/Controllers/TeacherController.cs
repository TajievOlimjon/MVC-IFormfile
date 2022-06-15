using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMVC.Areas.Admin.ModelDTO;
using WebMVC.Areas.Admin.Models;
using WebMVC.DataDB;


namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class TeacherController : Controller
    {
        private readonly TeacherService teacherService;
        private readonly IMapper mapper;
        private readonly DataContext context;

        public TeacherController(TeacherService teacherService, IMapper mapper, DataContext context)
        {
            this.teacherService = teacherService;
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<IActionResult> GetAll()
        {
            var list = await teacherService.GetTeachers();
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var teacher = new TeacherDTO();
            return View(teacher);
        }

        //[HttpPost]

        //public async Task<IActionResult> Add(TeacherDTO teacher, IFormFile file)
        //{
        //    if (ModelState.IsValid == true)
        //    {
        //        return View(teacher);
        //    }
        //    await teacherService.Insert(teacher, file);
        //    return RedirectToAction(nameof(GetAll));
        //}

         public async Task<IActionResult> Add(TeacherDTO teacher, IFormFile file)
        {
            string dirpath = Path.GetFullPath("wwwroot/Image/");
            string path = dirpath + file.FileName;
            using (var stream = System.IO.File.Create(path))
            {
                file.CopyTo(stream);
            }
            teacher.Image = "/Image/" + file.FileName;

            var newTeacher = mapper.Map<Teacher>(teacher);
            await context.Teachers.AddAsync(newTeacher);
            context.SaveChanges();
            return RedirectToAction(nameof(GetAll));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var teacher = await teacherService.GetTeacherById(Id);
            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TeacherDTO teacher, IFormFile file)
        {
            if (ModelState.IsValid == false)
            {
                return View(teacher);
            }
            string dirpath = Path.GetFullPath("wwwroot/Image/");
            string path = dirpath + file.FileName;
            using (var stream = System.IO.File.Create(path))
            {
                file.CopyTo(stream);
            }
            teacher.Image = "/Image/" + file.FileName;            
            var t = await context.Teachers.FindAsync(teacher.Id);           
            t.FirstName = teacher.FirstName;
            t.LastName = teacher.LastName;
            t.PhoneNumber = teacher.PhoneNumber;
            t.Email = teacher.Email;
            t.Image = teacher.Image;
            t.Birthday = teacher.Birthday;
             context.SaveChanges();
            return RedirectToAction(nameof(GetAll));

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            await  teacherService.Delete(Id);
            return RedirectToAction(nameof(GetAll));

        }
    }
}
