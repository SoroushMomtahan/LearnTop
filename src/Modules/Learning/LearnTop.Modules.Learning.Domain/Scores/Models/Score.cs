using LearnTop.Modules.Learning.Domain.Scores.Enums;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Learning.Domain.Scores.Models;

public class Score : Aggregate
{
    public Guid ScorerId { get; private set; }
    public Guid CourseId { get; private set; }
    public Expertise Expertise { get; private set; }
    public Responsiveness Responsiveness { get; private set; }
    public Timing Timing { get; private set; }
    public CreateInterest CreateInterest { get; private set; }
}
