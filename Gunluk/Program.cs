global using Gunluk.Data;
global using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UygulamaDbContext>(o => o.UseSqlServer(
    builder.Configuration.GetConnectionString("UygulamaDbContext")));

builder.Services.AddControllersWithViews();

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
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//VERİTABANI YOKSA OLUŞTUR(MİGRATİONLAR YAPILMADIYSA YAP)
using (var scope = app.Services.CreateScope())
{
    var db=scope.ServiceProvider.GetService<UygulamaDbContext>();
    db?.Database.Migrate();  
}

app.Run();
