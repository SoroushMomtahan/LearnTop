﻿using LearnTop.Modules.Blogs.Domain.Blogs.Models;

namespace LearnTop.Modules.Blogs.Domain.Blogs.Repositories;

public interface IBlogRepository
{
    Task CreateAsync(Blog blog);
    Task UpdateAsync(Blog blog);
    Task DeleteAsync(Blog blog);
    Task<Blog?> GetByIdAsync(Guid id);
    Task UpdateTagsAsync(IEnumerable<Tag> tags);
    Task UpdateCommentsAsync(IEnumerable<Comment> comments);
}