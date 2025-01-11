using LearnTop.Modules.Requests.Application.Tickets.Features.Commands.AddReplyTicket;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Requests.Presentation.Tickets.AddReplyTicket;

internal sealed class AddReplyTicketEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Tickets/Reply", async (AddReplyTicketCommand command, ISender sender) =>
        {
            Result<AddReplyTicketResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Tickets);
    }
}
