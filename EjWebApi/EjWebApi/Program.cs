using EjWebApi.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AcademiaDbContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("AcademiaDb")));

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
// app.MapGet("/", () => "Hello World!");

//app.MapGet("/api/estudiantes", async (AcademiaDbContext context) =>
//{
  //  return await context.Estudiantes.ToListAsync();
//});

app.Run();
