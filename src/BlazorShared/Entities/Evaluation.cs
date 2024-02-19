using System.ComponentModel.DataAnnotations.Schema;
using BlazorShared.Enums;
using CleanArchitecture.Blazor.Domain.Enums;

namespace CleanArchitecture.Blazor.Domain.Entities;

[Table("AnswerFormatEvaluations")]
public class Evaluation : AnswerFormat
{
    public BlazorShared.Enums.PriorityEnum Priority { get; set; }
    public BlazorShared.Enums.AssessmentEnum SelfAssessment { get; set; }
    public BlazorShared.Enums.AssessmentEnum InternalAssessment { get; set; }

}
