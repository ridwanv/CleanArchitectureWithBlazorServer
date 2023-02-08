namespace BlazorShared.Models;

public class LongTextDto : AnswerFormatDto
{
    private string _answer;

    public string Answer { get => _answer; set { _answer = value; AnswerChanged() ; AnswerText = value; } }
}
