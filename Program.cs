using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Hangfire;
using Hangfire.SqlServer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHangfire(config => config.UseSqlServerStorage("Data Source=DRAPARTH-L-5507\\SQLEXPRESS;Initial Catalog=hangfire;User ID=sa;Password=Welcome2evoke@1234"));


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseHangfireDashboard();
app.UseHangfireServer();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
