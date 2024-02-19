using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Blazor.Application.Common.Mappings;
using FluentEmail.Core.Models;

namespace BlazorShared.Models;
public class AddressDto : IMapFrom<CleanArchitecture.Blazor.Domain.Entities.Address>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CleanArchitecture.Blazor.Domain.Entities.Address, AddressDto>(MemberList.None).ReverseMap();

    }


    public Guid Id { get; set; } = Guid.NewGuid();
    public string Line1 { get; set; }
    public string Line2 { get; set; }
    public string City { get; set; }
    public string Code { get; set; }
}
