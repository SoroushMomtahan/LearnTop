using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.enums;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Blogs.Application.Articles.Dtos;

public record GetArticleQueryDto(
    string Search,
    Status Status) : PaginationRequest;
