using LearnTop.Modules.Academy.Application.Tickets.Commands.AddReplyTicket;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Academy.Presentation.Tickets.Endpoints.AddReplyTicket;

public class AddReplyTicketEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/ReplyTickets", static async (AddReplyTicketCommand command, ISender sender) =>
        {
            Result<AddReplyTicketResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.ReplyTickets);
    }
}
