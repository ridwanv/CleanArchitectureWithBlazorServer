using CleanArchitecture.Blazor.Application.Common.Mappings;
using CleanArchitecture.Blazor.Domain.Entities;

namespace BlazorShared.Models;

public class SingleChoiceDto : AnswerFormatDto
{
    private string _answer;

    public List<string> Choices { get; set; }


}
