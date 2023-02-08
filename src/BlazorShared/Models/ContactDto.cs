using AutoMapper;
using CleanArchitecture.Blazor.Application.Common.Mappings;
using CleanArchitecture.Blazor.Domain.Entities;

namespace BlazorShared.Models;

public class ContactDto : IMapFrom<Contact>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FullName { get; set; }
    public string Position { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Contact, ContactDto>(MemberList.None).ReverseMap();

    }

}
