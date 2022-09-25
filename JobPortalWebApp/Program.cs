using JobPortal.Interface;
using JobPortalBLL;
using JobPortalBLL.Service;
using JobPortalDAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

string conStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<fldbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(conStr));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IEmployeeProfileService, EmployeeProfileService>();
//builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
//builder.Services.AddTransient<IModelUnitOfWork, ModelUnitOfWork>();
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
    name: "default",
    pattern: "{controller=Home}/{action=EmploymentForm}/{id?}");

app.Run();
