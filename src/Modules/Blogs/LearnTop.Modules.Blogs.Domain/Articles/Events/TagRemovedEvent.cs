﻿using LearnTop.Modules.Blogs.Domain.Articles.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Articles.Events;

public class TagRemovedEvent(Tag tag) : DomainEvent
{
    public Tag Tag { get; } = tag;
}