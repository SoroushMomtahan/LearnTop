using LearnTop.Modules.Requests.Application.Tickets.Features.Commands.DeleteReplyTicket;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Requests.Presentation.Tickets.DeleteReplyTicket;

internal sealed class DeleteReplyTicketEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/Tickets/Reply", async ([AsParameters] DeleteReplyTicketCommand command, ISender sender) =>
        {
            Result<DeleteReplyTicketResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem); 
        })
        .WithTags(Tags.Tickets);
    }
}
