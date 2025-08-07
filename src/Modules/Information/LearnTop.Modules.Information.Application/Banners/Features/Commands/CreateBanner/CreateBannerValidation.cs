using FluentValidation;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Information.Application.Banners.Features.Commands.CreateBanner;

internal sealed class CreateBannerValidation : AbstractValidator<CreateBannerCommand>
{
    public CreateBannerValidation()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage(Error.Empty("عنوان").Description);
    }
}
