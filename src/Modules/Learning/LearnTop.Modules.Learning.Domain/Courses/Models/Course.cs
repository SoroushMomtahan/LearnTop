using LearnTop.Modules.Learning.Domain.Courses.Enums;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Learning.Domain.Courses.Models;

public class Course : Aggregate
{
    public string Title { get; private set; }
    public string Content { get; private set; }
    public Guid TeacherId { get; private set; }
    public string Duration { get; private set; }
    public Level Level { get; private set; }
    public Status Status { get; private set; }
    public string TotalVideos { get; private set; }
    public string TotalDurations { get; private set; }
    private readonly List<Student> _students = [];
    public IReadOnlyList<Student> Students => [.. _students];
    private readonly List<Subscriber> _subscribers = [];
    public IReadOnlyList<Subscriber> Subscribers => [.. _subscribers];
}
