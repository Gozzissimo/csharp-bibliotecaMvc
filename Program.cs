//USING DA AGGIUNGERE
using csharp_bibliotecaMvc.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//STRINGA CHE RICHIAMA IL SERVER IN APPSETTINGS,JSON
string sConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BibliotecaContext>(options =>
  options.UseSqlServer(sConnectionString));

//-----------------------
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
    pattern: "{controller=Libroes}/{action=Index}/{id?}");

//-----INSERT DI DATI IN DB
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<BibliotecaContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.Run();
