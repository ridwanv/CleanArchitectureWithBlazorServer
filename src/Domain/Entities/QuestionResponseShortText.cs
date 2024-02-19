using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Blazor.Domain.Entities;


[Table("QuestionResponseShortTexts")]
public class QuestionResponseShortText : QuestionResponse
{

    public string Answer { get; set; }
}
