using LearnTop.Modules.Academy.Domain.CourseProposals.Models;
using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Academy.Application.CourseProposals.Commands.CreateCourseProposal;

public record CreateCourseProposalCommand(
    Guid TeacherId,
    string Content,
    string TitleOfCourse,
    List<Skill> Skills
    ) : ICommand<CreateCourseProposalResponse>;
