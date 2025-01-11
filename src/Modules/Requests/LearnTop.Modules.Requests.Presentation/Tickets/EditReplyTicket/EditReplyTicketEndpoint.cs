using LearnTop.Modules.Requests.Application.Tickets.Features.Commands.EditReplyTicket;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Requests.Presentation.Tickets.EditReplyTicket;

internal sealed class EditReplyTicketEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/Tickets/Reply", async (EditReplyTicketCommand command, ISender sender) =>
        {
            Result<EditReplyTicketResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Tickets);
    }
}
