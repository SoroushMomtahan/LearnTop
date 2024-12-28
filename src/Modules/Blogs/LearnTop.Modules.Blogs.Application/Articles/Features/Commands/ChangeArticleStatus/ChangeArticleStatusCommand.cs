using LearnTop.Modules.Blogs.Domain.Articles.enums;
using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.ChangeArticleStatus;

public record ChangeArticleStatusCommand(Guid ArticleId, Status Status) : ICommand<ChangeArticleStatusResponse>;
