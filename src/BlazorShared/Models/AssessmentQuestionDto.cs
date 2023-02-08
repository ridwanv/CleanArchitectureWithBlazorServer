namespace BlazorShared.Models;

public class AssessmentQuestionDto: QuestionDto
{
    public Priority Priority { get; set; }
    public Assessment InternalAssessment { get; set; }
    public string InternalNote { get; set; }
    public int Score { get { return (5 - (int)Priority) * (int)InternalAssessment; } }
    public int MaximumScore { get { return (5 - (int)Priority) * 3; } }

    public AssessmentQuestionDto()
    {
        AnswerType = new EvaluationDto();
    }

}
