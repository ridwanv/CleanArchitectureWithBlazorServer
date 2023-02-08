namespace BlazorShared.Models;

public class EvaluationDto : AnswerFormatDto
{
    public Priority Priority { get; set; }
    public Assessment SelfAssessment { get; set; }
    public Assessment InternalAssessment { get; set; }

    public EvaluationDto()
    {
        base.AnswerTypeEnum = AnswerTypeEnum.Evaluation;
    }

}
