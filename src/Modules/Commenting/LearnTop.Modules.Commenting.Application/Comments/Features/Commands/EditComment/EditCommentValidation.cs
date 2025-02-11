using FluentValidation;

namespace LearnTop.Modules.Commenting.Application.Comments.Features.Commands.EditComment;

public class EditCommentValidation : AbstractValidator<EditCommentCommand>
{
    public EditCommentValidation()
    {
        RuleFor(x=>x.Content).NotEmpty();
    }
}
