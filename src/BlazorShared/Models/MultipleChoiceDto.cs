namespace BlazorShared.Models;

public class MultipleChoiceDto : AnswerFormatDto
{
    private string _answer;

    public Dictionary<string, string> Choices { get; set; } = new Dictionary<string, string>();
    public string Answer { get => _answer; set {  _answer = value; AnswerChanged(); ; AnswerText = value; } }

}
