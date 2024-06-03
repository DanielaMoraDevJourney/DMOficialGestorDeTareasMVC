using Microsoft.EntityFrameworkCore;
using DMAPIGestorDeTareasMagicOficial.Data;
using DMAPIGestorDeTareasMagicOficial.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace DMAPIGestorDeTareasMagicOficial.Controllers;

public static class DMCategoriaEndpoints
{
    public static void MapDMCategoriaEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/DMCategoria").WithTags(nameof(DMCategoria));

        group.MapGet("/", async (DMAPIGestorDeTareasMagicOficialContext db) =>
        {
            return await db.DMCategoria.ToListAsync();
        })
        .WithName("GetAllDMCategoria")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<DMCategoria>, NotFound>> (int dmcategoriaid, DMAPIGestorDeTareasMagicOficialContext db) =>
        {
            return await db.DMCategoria.AsNoTracking()
                .FirstOrDefaultAsync(model => model.DMCategoriaID == dmcategoriaid)
                is DMCategoria model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetDMCategoriaById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int dmcategoriaid, DMCategoria dMCategoria, DMAPIGestorDeTareasMagicOficialContext db) =>
        {
            var affected = await db.DMCategoria
                .Where(model => model.DMCategoriaID == dmcategoriaid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.DMCategoriaID, dMCategoria.DMCategoriaID)
                    .SetProperty(m => m.DMNombre, dMCategoria.DMNombre)
                    .SetProperty(m => m.DMDescripcion, dMCategoria.DMDescripcion)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateDMCategoria")
        .WithOpenApi();

        group.MapPost("/", async (DMCategoria dMCategoria, DMAPIGestorDeTareasMagicOficialContext db) =>
        {
            db.DMCategoria.Add(dMCategoria);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/DMCategoria/{dMCategoria.DMCategoriaID}",dMCategoria);
        })
        .WithName("CreateDMCategoria")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int dmcategoriaid, DMAPIGestorDeTareasMagicOficialContext db) =>
        {
            var affected = await db.DMCategoria
                .Where(model => model.DMCategoriaID == dmcategoriaid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteDMCategoria")
        .WithOpenApi();
    }
}
