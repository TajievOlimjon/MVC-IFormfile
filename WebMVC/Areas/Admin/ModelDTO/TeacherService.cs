using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebMVC.Areas.Admin.Models;
using WebMVC.DataDB;
using Microsoft.AspNetCore.Http;

namespace WebMVC.Areas.Admin.ModelDTO
{
    public class TeacherService
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private IWebHostEnvironment webHost;
        public TeacherService(DataContext context,IMapper mapper, IWebHostEnvironment webHost)
        {
            this.context = context;
            this.mapper = mapper;
            this.webHost = webHost;
        }

        public async Task<List<Teacher>> Get()
        {
            var list = await context.Teachers.ToListAsync();
            return list;
        }

        public async Task<List<TeacherDTO>> GetTeachers()
        {
            var list= await(                
                from t in context.Teachers                
                select new TeacherDTO
                {
                    Id=t.Id,
                    FirstName=t.FirstName,
                    LastName=t.LastName,
                    PhoneNumber=t.PhoneNumber,
                    Email=t.Email,
                    Image=t.Image,
                    Birthday=t.Birthday                    
                }).ToListAsync();
            if (list == null) return new List<TeacherDTO>();
            return list;
        }

        //public async Task<List<TeacherSkill>> GetTeachersAsync()
        //{
        //    var list=context.Teachers.Include(p=>p.Id).Include()
        //}


        public async Task<TeacherDTO> GetTeacherById(int Id)
        {
            var list = await (
               from t in context.Teachers
               where t.Id == Id
               select new TeacherDTO
               {
                   Id = t.Id,
                   FirstName = t.FirstName,
                   LastName = t.LastName,
                   PhoneNumber = t.PhoneNumber,
                   Email = t.Email,
                   Image = t.Image,
                   Birthday = t.Birthday,
               }).FirstOrDefaultAsync();
            if (list == null) return new TeacherDTO();
            return list;

        }
        //public async Task<int> Insert(TeacherDTO teacher, IFormFile file)
        //{
        //    if (!file.Equals(null))
        //    {
        //        var root = webHost.WebRootPath;
        //        var path = Path.Combine(root, "Img", file.FileName);
        //        using (var filestream = new FileStream(path, FileMode.Create))
        //        {
        //            await file.CopyToAsync(filestream);
        //        }

        //    }
        //    teacher.Image = "/Img/" + file.FileName;

        //    var newTeacher = mapper.Map<Teacher>(teacher);
        //    await context.Teachers.AddAsync(newTeacher);
        //    return context.SaveChanges();
        //}


        //public async Task<int> Insert(TeacherDTO teacher, IFormFile file)
        //{
        //    string dirpath = Path.GetFullPath("wwwroot/Image/");
        //    string path = dirpath + file.FileName;
        //    using (var stream = System.IO.File.Create(path))
        //    {
        //        file.CopyTo(stream);
        //    }
        //    teacher.Image = "/Image/" + file.FileName;

        //    var newTeacher = mapper.Map<Teacher>(teacher);
        //    await context.Teachers.AddAsync(newTeacher);
        //    return context.SaveChanges();
        //}

        public async Task<int> Update(TeacherDTO teacher)
        {
            var t =await context.Teachers.FirstOrDefaultAsync(t=>t.Id==teacher.Id);
            if (t == null) return 0;
            t.FirstName = teacher.FirstName;
            t.LastName = teacher.LastName;
            t.PhoneNumber = teacher.PhoneNumber;
            t.Email = teacher.Email;
            t.Image = teacher.Image;
            t.Birthday = teacher.Birthday;
            return  context.SaveChanges();
        }

        public async Task<int> Delete(int Id)
        {
            var teacher = await context.Teachers.SingleOrDefaultAsync(t => t.Id == Id);
            if (teacher == null) return 0;
            context.Teachers.Remove(teacher);
            return context.SaveChanges();
        }
    }
}
