using BlazorShared.Enums;
using BlazorShared.Models;

namespace CleanArchitecture.Blazor.Domain.Entities;

public abstract class AnswerFormat
{
    public BlazorShared.Enums.AnswerTypeEnum AnswerTypeEnum { get; set; }
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime? AnswerDate { get; set; } = null;
    public string AnswerMotivation { get; set; }
}