using Microsoft.EntityFrameworkCore;
using WebMVC.Areas.Admin.Models;

namespace WebMVC.DataDB
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
            public DbSet<Teacher>? Teachers { get; set; }
            public DbSet<Skill>? Skills { get; set; }
            public  DbSet<User> Users { get; set; }
     

    }
}
