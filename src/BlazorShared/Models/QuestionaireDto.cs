namespace BlazorShared.Models;

public class QuestionaireDto
{


    public Guid QuestionaireId { get; set; } = Guid.NewGuid();
    public List<SectionDto> Sections { get; set; } = new List<SectionDto>();
    public List<QuestionDto> Questions
    {
        get
        {
            var qs = new List<QuestionDto>();
            foreach (var item in Sections)
            {
                foreach (var question in item.Questions)
                {
                    if(qs.FirstOrDefault(x=>x.QuestionId == question.QuestionId) ==null)
                        qs.Add(question);
                }
            }
            return qs;
        }
    }



    public void AddQuestion(QuestionDto question)
    {

        var section = Sections.FirstOrDefault(x => x.SectionName == question.Category);
        if(section!=null)
        {
            if (section.Questions.FirstOrDefault(x => x.QuestionId == question.QuestionId) == null)
                section.Questions.Add(question);
        }
        else
        {
            var newSection = new SectionDto() { SectionName = question.Category };
            newSection.Questions.Add(question);
            Sections.Add(newSection);

        }
    }

}
