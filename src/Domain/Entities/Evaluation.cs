using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitecture.Blazor.Domain.Enums;

namespace CleanArchitecture.Blazor.Domain.Entities;

[Table("AnswerFormatEvaluations")]
public class Evaluation : AnswerFormat
{
    public PriorityEnum Priority { get; set; }
    public AssessmentEnum SelfAssessment { get; set; }
    public AssessmentEnum InternalAssessment { get; set; }

}
