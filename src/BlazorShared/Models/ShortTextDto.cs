using AutoMapper;
using CleanArchitecture.Blazor.Application.Common.Mappings;
using CleanArchitecture.Blazor.Domain.Entities;

namespace BlazorShared.Models;

public class ShortTextDto : AnswerFormatDto, IMapFrom<ShortText>
{

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ShortText, ShortTextDto>(MemberList.None);
        profile.CreateMap<ShortTextDto, ShortText>(MemberList.None);

    }

    public string Label { get; set; }
}
