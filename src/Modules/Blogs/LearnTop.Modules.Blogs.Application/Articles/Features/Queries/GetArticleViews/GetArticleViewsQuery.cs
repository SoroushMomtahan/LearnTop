using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.enums;
using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViews;

public record GetArticleViewsQuery(
    string? Search, 
    Status? Status,
    bool? IsActive,
    int PageIndex,
    int PageSize)
    : IQuery<GetArticleViewsResult>;
    
    
    
    

