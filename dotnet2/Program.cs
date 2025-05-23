using collegemanagementfirstproject.Controllers;
using collegemanagementfirstproject.Interface;
using collegemanagementfirstproject.Repository;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IConnection, RDBconnection>();
builder.Services.AddScoped<Icollegestudent, collegestudentrepository>();
builder.Services.AddScoped<IcollegeFaculty, CollegeFacultyrepo>();
builder.Services.AddScoped<Icollegedepart, collegeDepartRepo>();


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
