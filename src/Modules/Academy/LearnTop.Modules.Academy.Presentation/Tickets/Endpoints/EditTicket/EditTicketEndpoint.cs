using LearnTop.Modules.Academy.Application.Tickets.Commands.EditTicket;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Academy.Presentation.Tickets.Endpoints.EditTicket;

public class EditTicketEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/Tickets", static async (EditTicketCommand command, ISender sender) =>
            {
                Result<EditTicketResponse> result = await sender.Send(command);
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Tickets);
    }
}
