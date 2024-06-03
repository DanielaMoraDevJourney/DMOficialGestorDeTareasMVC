using Microsoft.EntityFrameworkCore;
using DMAPIGestorDeTareasMagicOficial.Data;
using DMAPIGestorDeTareasMagicOficial.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace DMAPIGestorDeTareasMagicOficial.Controllers;

public static class DMPrioridadEndpoints
{
    public static void MapDMPrioridadEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/DMPrioridad").WithTags(nameof(DMPrioridad));

        group.MapGet("/", async (DMAPIGestorDeTareasMagicOficialContext db) =>
        {
            return await db.DMPrioridad.ToListAsync();
        })
        .WithName("GetAllDMPrioridads")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<DMPrioridad>, NotFound>> (int dmprioridadid, DMAPIGestorDeTareasMagicOficialContext db) =>
        {
            return await db.DMPrioridad.AsNoTracking()
                .FirstOrDefaultAsync(model => model.DMPrioridadId == dmprioridadid)
                is DMPrioridad model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetDMPrioridadById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int dmprioridadid, DMPrioridad dMPrioridad, DMAPIGestorDeTareasMagicOficialContext db) =>
        {
            var affected = await db.DMPrioridad
                .Where(model => model.DMPrioridadId == dmprioridadid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.DMPrioridadId, dMPrioridad.DMPrioridadId)
                    .SetProperty(m => m.DMNombre, dMPrioridad.DMNombre)
                    .SetProperty(m => m.DMDescripcion, dMPrioridad.DMDescripcion)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateDMPrioridad")
        .WithOpenApi();

        group.MapPost("/", async (DMPrioridad dMPrioridad, DMAPIGestorDeTareasMagicOficialContext db) =>
        {
            db.DMPrioridad.Add(dMPrioridad);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/DMPrioridad/{dMPrioridad.DMPrioridadId}",dMPrioridad);
        })
        .WithName("CreateDMPrioridad")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int dmprioridadid, DMAPIGestorDeTareasMagicOficialContext db) =>
        {
            var affected = await db.DMPrioridad
                .Where(model => model.DMPrioridadId == dmprioridadid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteDMPrioridad")
        .WithOpenApi();
    }
}
