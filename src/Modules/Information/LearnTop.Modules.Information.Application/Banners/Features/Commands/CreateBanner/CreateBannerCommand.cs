﻿using LearnTop.Shared.Application.Cqrs;
using Microsoft.AspNetCore.Http;

namespace LearnTop.Modules.Information.Application.Banners.Features.Commands.CreateBanner;

public record CreateBannerCommand(
    IFormFile Image,
    string Title,
    string Description,
    DateTime StartAt,
    DateTime EndAt
    ) : ICommand<CreateBannerResponse>;
