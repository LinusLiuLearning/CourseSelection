using Microsoft.EntityFrameworkCore;
using CourseSelection.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using CourseSelection.Service.Interface;
using CourseSelection.Service.Implement;
using CourseSelection.Repository.Interface;
using CourseSelection.Repository.Implement;

var builder = WebApplication.CreateBuilder(args);

var _connectionString = builder.Configuration.GetValue<string>("ConnectionString");

// Add services to the container.
builder.Services.AddDbContext<CsContext>(options =>
options.UseSqlServer(_connectionString));

// Service
builder.Services.AddScoped<IStudentService, StudentService>();
// Repsitory
builder.Services.AddScoped<IStudentRepository, StudentRepository>(sp => {
    var connectString = _connectionString;
    return new StudentRepository(connectString);
});
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
