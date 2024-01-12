using BibliotecaVirtual.Data;
using BibliotecaVirtual.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//bd connection
var connection = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<MysqlContext>(options => options.UseMySql(connection,
    new MySqlServerVersion(
        new Version(8, 0, 0))));
//Injecao de dependencias
builder.Services.AddScoped<LivrosService>();

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

