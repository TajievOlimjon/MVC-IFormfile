using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebMVC.Areas.Admin.IMapperService;
using WebMVC.Areas.Admin.ModelDTO;
using WebMVC.Areas.Admin.Services;
using WebMVC.DataDB;

var builder = WebApplication.CreateBuilder(args);



string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(connection));




// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<TeacherService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddAutoMapper(typeof(IMapperService));


var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller}/{action}"
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
