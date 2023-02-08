using AutoMapper;
using CleanArchitecture.Blazor.Application.Common.Mappings;
using CleanArchitecture.Blazor.Domain.Entities;

namespace BlazorShared.Models;

public class SupplierDto:IMapFrom<Supplier>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Supplier, SupplierDto>(MemberList.None).ReverseMap();

    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string TaxReferenceNumber { get; set; }

    public string Category { get; set; }

    public string RiskRating { get; set; }

    public List<ContactDto> Contacts { get; set; }

    public List<QuestionaireDto> OnboardingQuestionaires { get; set; }

    public List<Attachment> Attachments { get; set; }

    public Address PhysicalAddress { get; set; }

    public string PhoneNumber { get; set; }

    public Contact PrimaryContact { get; set; } = new Contact();

    public string Comments { get; set; }

    public List<InvitationDto> Invitations { get; set; }
}
