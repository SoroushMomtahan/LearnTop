using FluentValidation;

namespace LearnTop.Modules.Commenting.Application.Comments.Features.Commands.CreateComment;

public class CreateCommentValidation : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentValidation()
    {
        RuleFor(x => x.Content).NotEmpty();
    }
}
