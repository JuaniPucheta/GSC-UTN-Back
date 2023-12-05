using EjEfCore.DataAccess;
using EjEfCore.Domain;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

using var context = new AcademiaDbContext();

await ReadSamples(context);

//int idEstudiante = await Create(context);
//await ReadAll(context);

//await Update(context, idEstudiante);
//await ReadAll(context);

//await Delete(context, idEstudiante);
//await ReadAll(context);

Console.ReadKey();

static async Task ReadSamples(AcademiaDbContext context)
{
    Estudiante? estudiante = await context.Estudiantes.SingleAsync();
}   

static async Task<int> Create(AcademiaDbContext context)
{
    var estudiante = new Estudiante
    {
        Nombre = "Juan",
        Apellido = "Perez",
        Legajo = 1234,
        FechaNacimiento = new DateOnly(2000, 1, 1)
    };
    context.Estudiantes.Add(estudiante);
    await context.SaveChangesAsync();

    return estudiante.Id;
}

static async Task ReadAll(AcademiaDbContext context)
{
    var estudiantes = await context.Estudiantes.ToListAsync(); // Obtiene todos los estudiantes de la base de datos
    var options = new JsonSerializerOptions()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };
    estudiantes.ForEach(e =>
    {
        string json = JsonSerializer.Serialize(e, options);
        Console.WriteLine(json);
    });
}

static async Task Update(AcademiaDbContext context, int id)
{
    var estudiante = await context.FindAsync<Estudiante>(id);

    estudiante.FechaNacimiento = new DateOnly(2004, 1, 1);

    // context.Update(estudiante); --> No es necesario porque el objeto ya está siendo trackeado por el context
    await context.SaveChangesAsync();
}

static async Task Delete(AcademiaDbContext context, int id)
{
    var estudiante = await context.FindAsync<Estudiante>(id);

    context.Remove(estudiante);
    await context.SaveChangesAsync();
}
