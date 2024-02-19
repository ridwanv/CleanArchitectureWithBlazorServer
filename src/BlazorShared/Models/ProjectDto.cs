using AutoMapper;
using CleanArchitecture.Blazor.Application.Common.Mappings;
using CleanArchitecture.Blazor.Domain.Entities;

namespace BlazorShared.Models;

public class ProjectDto : IMapFrom<Project>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Project, ProjectDto>(MemberList.None).ReverseMap();

    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public string ProjectName { get; set; }
    public string ProjectCode { get; set; }
    public string Description { get; set; }

    public StatusEnum Status { get; set; }

    public List<EventDto> Events { get; set; } = new List<EventDto>();



}
