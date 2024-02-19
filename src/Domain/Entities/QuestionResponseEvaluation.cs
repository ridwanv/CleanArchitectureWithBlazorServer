namespace CleanArchitecture.Blazor.Domain.Entities;

public class QuestionResponseEvaluation : QuestionResponse
{
    public Priority Priority { get; set; }
    public Assessment SelfAssessment { get; set; }
    public Assessment InternalAssessment { get; set; }
}
