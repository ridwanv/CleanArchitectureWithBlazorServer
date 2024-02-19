using AutoMapper;
using CleanArchitecture.Blazor.Application.Common.Mappings;
using CleanArchitecture.Blazor.Domain.Entities;

namespace BlazorShared.Models;

public class QuestionaireDto :IMapFrom<Questionaire>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Questionaire, QuestionaireDto>(MemberList.None).ReverseMap();
        profile.CreateMap<QuestionaireDto, SupplierQuestionaire>().ForMember(x => x.Questionaire, y => y.MapFrom(s => s)).ReverseMap();

    }

    public Guid Id { get; set; } = Guid.NewGuid();

    public QuestionaireType QuestionaireType { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
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
                    if(qs.FirstOrDefault(x=>x.Id == question.Id) ==null)
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
            if (section.Questions.FirstOrDefault(x => x.Id == question.Id) == null)
                section.Questions.Add(question);
        }
        else
        {
            var newSection = new SectionDto() { SectionName = question.Category };
            newSection.Questions.Add(question);
            Sections.Add(newSection);

        }
    }

    public QuestionaireDto()
    {
        Sections = new List<SectionDto>() { new SectionDto() { SectionName = "Default" } };   
    }

}

public enum QuestionaireType
{
    GeneralSupplierQuestionaire,
    FinancialSupplierQuestionaire,
    HealthAndSafetySupplierQuestionaire,
    QualitySupplierQuestionaire,
    EnvironmentalSupplierQuestionaire,
    Other


}
