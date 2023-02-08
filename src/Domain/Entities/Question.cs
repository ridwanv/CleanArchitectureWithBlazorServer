using CleanArchitecture.Blazor.Domain.Enums;

namespace CleanArchitecture.Blazor.Domain.Entities;

public class Question
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public AnswerTypeEnum AnswerTypeEnum { get; set; }
    public string Category { get; set; } = "Default";
    public string QuestionLabel { get; set; }
    public bool IsMandatory { get; set; }
    public AnswerFormat AnswerType { get; set; }
}