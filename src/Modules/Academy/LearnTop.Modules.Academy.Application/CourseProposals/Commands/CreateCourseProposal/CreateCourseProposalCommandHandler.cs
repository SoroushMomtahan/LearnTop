using LearnTop.Modules.Academy.Application.Abstractions.Data;
using LearnTop.Modules.Academy.Domain.CourseProposals.Errors;
using LearnTop.Modules.Academy.Domain.CourseProposals.Models;
using LearnTop.Modules.Academy.Domain.CourseProposals.Repositories;
using LearnTop.Modules.Users.PublicApi;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Application.CourseProposals.Commands.CreateCourseProposal;

public class CreateCourseProposalCommandHandler(
    ICourseProposalRepository courseProposalRepository,
    ISkillRepository skillRepository,
    IUnitOfWork unitOfWork,
    IUsersApi usersApi
    )
    : ICommandHandler<CreateCourseProposalCommand, CreateCourseProposalResponse>
{

    public async Task<Result<CreateCourseProposalResponse>> Handle(CreateCourseProposalCommand request,
        CancellationToken cancellationToken)
    {
        bool isExist = await usersApi.IsExistAsync(request.TeacherId);
        if (!isExist)
        {
            return Result.Failure<CreateCourseProposalResponse>(CourseProposalErrors.TeacherNotFound(request.TeacherId));
        }
        var courseProposal = CourseProposal.Create(
            request.TeacherId,
            request.Content,
            request.TitleOfCourse,
            request.Skills);

        await skillRepository.AddAsync(request.Skills, cancellationToken);
        await courseProposalRepository.AddAsync(courseProposal, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateCourseProposalResponse(courseProposal.Id);
    }
}
