using LearnTop.Modules.Requests.Application.Tickets.Features.Commands.CreateTicket;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Requests.Presentation.Tickets.CreateTicket;

internal sealed class CreateTicketEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Tickets", static async (
                CreateTicketCommand command,
                ISender sender) =>
            {
                Result<CreateTicketResponse> result = await sender.Send(command);
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Tickets);
    }
}
