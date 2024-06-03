using Microsoft.EntityFrameworkCore;
using DMAPIGestorDeTareasMagicOficial.Data;
using DMAPIGestorDeTareasMagicOficial.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace DMAPIGestorDeTareasMagicOficial.Controllers;

public static class DMTareaEndpoints
{
    public static void MapDMTareaEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/DMTarea").WithTags(nameof(DMTarea));

        group.MapGet("/", async (DMAPIGestorDeTareasMagicOficialContext db) =>
        {
            return await db.DMTarea.ToListAsync();
        })
        .WithName("GetAllDMTareas")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<DMTarea>, NotFound>> (int dmtareaid, DMAPIGestorDeTareasMagicOficialContext db) =>
        {
            return await db.DMTarea.AsNoTracking()
                .FirstOrDefaultAsync(model => model.DMTareaID == dmtareaid)
                is DMTarea model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetDMTareaById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int dmtareaid, DMTarea dMTarea, DMAPIGestorDeTareasMagicOficialContext db) =>
        {
            var affected = await db.DMTarea
                .Where(model => model.DMTareaID == dmtareaid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.DMTareaID, dMTarea.DMTareaID)
                    .SetProperty(m => m.DMTitulo, dMTarea.DMTitulo)
                    .SetProperty(m => m.DMDescripcion, dMTarea.DMDescripcion)
                    .SetProperty(m => m.DMFechaVencimiento, dMTarea.DMFechaVencimiento)
                    .SetProperty(m => m.DMPrioridadID, dMTarea.DMPrioridadID)
                    .SetProperty(m => m.DMCategoriaID, dMTarea.DMCategoriaID)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateDMTarea")
        .WithOpenApi();

        group.MapPost("/", async (DMTarea dMTarea, DMAPIGestorDeTareasMagicOficialContext db) =>
        {
            db.DMTarea.Add(dMTarea);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/DMTarea/{dMTarea.DMTareaID}",dMTarea);
        })
        .WithName("CreateDMTarea")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int dmtareaid, DMAPIGestorDeTareasMagicOficialContext db) =>
        {
            var affected = await db.DMTarea
                .Where(model => model.DMTareaID == dmtareaid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteDMTarea")
        .WithOpenApi();
    }
}
