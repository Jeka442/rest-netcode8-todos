using Microsoft.EntityFrameworkCore;
using TodoNet.Data;
using TodoNet.Repositories;
using TodoNet.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// database
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnetion"));
});
builder.Services.AddScoped<DataContext, DataContext>();

// Services
builder.Services.AddScoped<ITodoService, TodoService>();

// Repositories
builder.Services.AddScoped<ITodoRepository, TodoRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();