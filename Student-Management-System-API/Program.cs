using Microsoft.EntityFrameworkCore;
using Student_Management_System_API.Repository;
using Student_Management_System_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Add dbcontext
builder.Services.AddDbContext<StudentManagementDbContext>(options => 
{
    string? connectionString = builder.Configuration.GetConnectionString("StudentManagementDbContext");
    options.UseSqlServer(connectionString);
});

//Add repository
builder.Services.AddScoped<IStudentRepository, StudentRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
