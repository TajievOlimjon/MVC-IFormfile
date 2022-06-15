using Microsoft.EntityFrameworkCore;
using WebMVC.Areas.Admin.Models;
using WebMVC.DataDB;

namespace WebMVC.Areas.Admin.Services
{
    public class SkillService
    {
        private readonly DataContext datacontext;

        public SkillService(DataContext context)
        {
            this.datacontext = context;
        }

        public List<Skill> GetSkills()
        {
            var list= datacontext.Skills.ToList();
            return list;
        }

        public List<Skill> GetSkillsAndTeachers()
        {
            var list = datacontext.Skills.Include("Teachers").ToList();
            return list;
        }
    }
}
