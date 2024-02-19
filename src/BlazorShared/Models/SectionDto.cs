using AutoMapper;
using CleanArchitecture.Blazor.Application.Common.Mappings;
using CleanArchitecture.Blazor.Domain.Entities;

namespace BlazorShared.Models;

public class SectionDto:IMapFrom<Section>
{

    public virtual void Mapping(Profile profile)
    {
        profile.CreateMap<Section, SectionDto>(MemberList.None);
        profile.CreateMap<SectionDto, Section>(MemberList.None)
            .ForMember(x => x.SubSections, opt => opt.Ignore());
    }


    public Guid Id { get; set; } = Guid.NewGuid();
    public string SectionName { get; set; }
    public List<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
    public List<SubSectionDto> SubSections { get; set; } = new List<SubSectionDto>();
}
