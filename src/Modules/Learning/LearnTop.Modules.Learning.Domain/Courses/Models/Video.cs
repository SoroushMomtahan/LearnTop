namespace LearnTop.Modules.Learning.Domain.Courses.Models;

public class Video
{
    public Guid CourseId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Link { get; private set; }
    public string Duration { get; private set; }
}
