using CodingChallengeV1.DAL;
using CodingChallengeV1.DAL.Repository.Abstraction;
using CodingChallengeV1.DAL.Repository.Implementation;
using CodingChallengeV1.Server.Settings;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System;

/*
 * 
 * Read from appsettings.json in Dot Net 6 Program.cs file
 *      https://stackoverflow.com/questions/69390676/how-to-use-appsettings-json-in-asp-net-core-6-program-cs-file
 * Getting started with Entity framework Core Code first
 *      https://www.c-sharpcorner.com/article/using-entity-framework-core/
 *      https://medium.com/c-sharp-progarmming/tutorial-code-first-approach-in-asp-net-core-mvc-with-ef-5baf5af696e9
 * CRUD operations in Blazor Web assembly with EF Core
 *      https://www.c-sharpcorner.com/blogs/create-a-net-6-app-on-blazor-wasm-for-crud-operations-with-ef-core
 */

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var connectionStringSettings = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();
builder.Services.AddDbContext<CustomDbContext>(o =>
{
    o.UseSqlServer(connectionStringSettings.DefaultDb);
});

builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<ISubElementRepository, SubElementRepository>();
builder.Services.AddTransient<IWindowRepository, WindowRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
