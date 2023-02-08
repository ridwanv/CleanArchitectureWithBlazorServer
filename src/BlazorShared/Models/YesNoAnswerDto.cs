namespace BlazorShared.Models;

public class YesNoAnswerDto : AnswerFormatDto
{
    private YesNoEnum _answer;

    public YesNoEnum Answer { get => _answer; set { _answer = value; AnswerChanged(); ; AnswerText = value.ToString(); } }

}
