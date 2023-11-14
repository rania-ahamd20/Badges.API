using Badges.Core.Common;
using Badges.Core.Repository;
using Badges.Core.Services;
using Badges.Infra.Common;
using Badges.Infra.Repository;
using Badges.Infra.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//AddScoped
builder.Services.AddScoped<IDbContext, DbContext>();

//----------------------------------------------------- Repository -----------------------------------------------------

builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBadgesRepository, BadgesRepository>();
builder.Services.AddScoped<ICourseTraineeRepository,CourseTraineeRepository>();

//----------------------------------------------------- Services -----------------------------------------------------

builder.Services.AddScoped<IAssignmentService, AssignmentService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBadgesService, BadgesService>();
builder.Services.AddScoped<ICourseTraineeService, CourseTraineeService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
