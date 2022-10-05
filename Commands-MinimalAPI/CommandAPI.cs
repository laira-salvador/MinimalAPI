using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.CompilerServices;

namespace Commands_MinimalAPI
{
    public static class CommandAPI
    {
        public static void AddCommandAPI(this WebApplication app)
        {
            app.MapGet("/", () => "Hello World!")
                .WithTags("Query").AllowAnonymous();

            app.MapGet("/commands",
                async (ICommandData commandData) =>
                Results.Ok(await commandData.GetCommands()))
                .WithTags("Query")
                .Produces<IEnumerable<CommandModel>>(StatusCodes.Status200OK);


            app.MapGet("/commands/filtered",
                async (Filter filter, ICommandData commandData) =>
                Results.Ok(await commandData.GetByFilter(filter.Property, filter.Value)))
                .WithTags("Query")
                .Produces<IEnumerable<CommandModel>>(StatusCodes.Status200OK);



            app.MapPost("/commands",
                async  (CommandModel command, ICommandData commandData) =>
                {
                    await commandData.InsertCommand(command);
                    Results.Created($"/commands", command);
                })
                .WithTags("Commands")
                .Produces(StatusCodes.Status201Created);




            app.MapPut("/commands/{Id}",
                async (int Id, CommandModel command, ICommandData commandData) =>
                {
                    var commandToUpdate = commandData.GetCommand(Id);
                    if (commandToUpdate == null)
                    {
                        return Results.NotFound();
                    }

                    await commandData.UpdateCommand(command);

                    return Results.Ok();
                })
                .WithTags("Commands")
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);



            app.MapDelete("/commands/{Id}",
                async (int Id, ICommandData commandData) =>
                {
                    var commandToDelete = commandData.GetCommand(Id);
                    if (commandToDelete == null)
                    {
                        return Results.NotFound();
                    }

                    await commandData.DeleteCommand(Id);

                    return Results.NoContent();
                })
                .WithTags("Commands")
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

        }
    }
}
