using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Anuncios.mvc.Data;
using Swashbuckle.Swagger;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AnunciosmvcContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AnunciosmvcContext") ?? throw new InvalidOperationException("Connection string 'AnunciosmvcContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen(options =>
{

});

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
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
