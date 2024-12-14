using LearnTop.Modules.Academy.Application.CourseProposals.Commands.CreateCourseProposal;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Academy.Presentation.CourseProposals.Endpoints;

public class CreateCourseProposalEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/CourseProposal", static async (CreateCourseProposalCommand command, ISender sender) =>
            {
                Result<CreateCourseProposalResponse> result = await sender.Send(command);
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.CourseProposals);
    }
}
