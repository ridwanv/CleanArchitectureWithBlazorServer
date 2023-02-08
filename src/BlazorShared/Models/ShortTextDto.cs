namespace BlazorShared.Models;

public class ShortTextDto : AnswerFormatDto
{
    private string _answer;

    public string Answer { get => _answer; set { _answer = value; AnswerChanged(); AnswerText = value; } }
}
