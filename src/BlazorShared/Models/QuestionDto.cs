using JsonSubTypes;
using Newtonsoft.Json;

namespace BlazorShared.Models;

[JsonConverter(typeof(JsonSubtypes), "AnswerTypeEnum")]
[JsonSubtypes.KnownSubType(typeof(AssessmentQuestionDto), AnswerTypeEnum.Evaluation)]
public class QuestionDto
{
    public Guid QuestionId { get; set; } = Guid.NewGuid();
    public AnswerTypeEnum AnswerTypeEnum { get; set; }
    public string Category { get; set; } = "Default";
    public string QuestionLabel { get; set; }
    public bool IsMandatory { get; set; }
    public AnswerFormatDto AnswerType { get; set; }


    public static QuestionDto Create(AnswerTypeEnum answerTypeEnum)
    {
        var question = new QuestionDto();
        switch (answerTypeEnum)
        {
            case AnswerTypeEnum.ShortText:
                question.AnswerType = new ShortTextDto();
                break;
            case AnswerTypeEnum.LongText:
                question.AnswerType = new LongTextDto();
                break;
            case AnswerTypeEnum.YesNo:
                break;
            case AnswerTypeEnum.MulipleChoice:
                break;
            case AnswerTypeEnum.Evaluation:
                break;
            default:
                break;
        }
        return question;
    }



}
