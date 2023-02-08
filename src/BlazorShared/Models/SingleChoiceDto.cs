namespace BlazorShared.Models;

public class SingleChoiceDto : AnswerFormatDto
{
    private string _answer;

    public List<string> Choices { get; set; }
    public string Answer { get => _answer; set { _answer = value; AnswerChanged(); AnswerText = value; } }

}
