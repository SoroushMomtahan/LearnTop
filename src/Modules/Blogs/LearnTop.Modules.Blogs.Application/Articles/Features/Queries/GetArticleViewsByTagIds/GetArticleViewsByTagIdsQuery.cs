﻿using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsByTagIds;

public record GetArticleViewsByTagIdsQuery(PaginationRequest Request, List<Guid> TagIds)
    : IQuery<GetArticleViewsByTagIdsResponse>;
