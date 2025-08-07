using LearnTop.Modules.Blogs.Application.Categories.Events;
using LearnTop.Modules.Blogs.Application.Categories.Services;
using LearnTop.Modules.Blogs.Application.Categories.Views;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Blogs.Application.Categories.EventHandlers;

internal sealed class CategoryCreatedEventHandler(ICategoryQueryService categoryQueryService) : IApplicationEventHandler<CategoryCreatedEvent>
{

    public async Task Handle(
        CategoryCreatedEvent notification, 
        CancellationToken cancellationToken)
    {
        CategoryView view = new()
        {
            Id = notification.Category.Id,
            Name = notification.Category.Name,
        };
        await categoryQueryService.CreateCategoryAsync(view);
    }
}
