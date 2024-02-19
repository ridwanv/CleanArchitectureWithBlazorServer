namespace BlazorShared.Models;

public class MultipleChoiceDto : AnswerFormatDto
{
    private string _answer;

    public Dictionary<string, string> Choices { get; set; } = new Dictionary<string, string>();


}
