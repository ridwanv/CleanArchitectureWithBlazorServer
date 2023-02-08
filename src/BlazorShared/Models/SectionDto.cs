namespace BlazorShared.Models;

public class SectionDto
{

    public string SectionName { get; set; }
    public List<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
    public List<SubSectionDto> SubSections { get; set; } = new List<SubSectionDto>();
}
