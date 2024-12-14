using LearnTop.Modules.Academy.Application.Tickets.Commands.CreateTicket;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Academy.Presentation.Tickets.Endpoints.CreateTicket;

public class CreateTicketEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("tickets", static async (CreateTicketRequest request, ISender sender) =>
            {
                CreateTicketCommand command = request.Adapt<CreateTicketCommand>();
                Result<CreateTicketResponse> result = await sender.Send(command);
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Tickets);
    }
}
