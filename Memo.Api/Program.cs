using MemoApp.ApplicationCore.Interfaces;
using MemoApp.ApplicationCore.Services;
using MemoApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MemoContext>(options => 
options.UseSqlite(builder.Configuration.GetConnectionString("MemoConnection")));

builder.Services.AddScoped(typeof(IAsyncRepository<,>), typeof(AsyncRepository<,>));
builder.Services.AddScoped<IMemoService, MemoService>();
builder.Services.AddScoped<ICompteService, CompteService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // autorise Angular dev server
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularDev");

app.UseAuthorization();

app.MapControllers();

app.Run();
