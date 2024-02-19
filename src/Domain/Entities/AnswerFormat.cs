using CleanArchitecture.Blazor.Domain.Enums;

namespace CleanArchitecture.Blazor.Domain.Entities;

public abstract class AnswerFormat: AuditableEntity
{
    public AnswerTypeEnum AnswerTypeEnum { get; set; }
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime? AnswerDate { get; set; } = null;
    public string? AnswerMotivation { get; set; }
}