using System.ComponentModel.DataAnnotations;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using BlazorShared.Enums;
using CleanArchitecture.Blazor.Application.Common.Mappings;
using CleanArchitecture.Blazor.Domain.Entities;

namespace BlazorShared.Models;

public class SupplierDto:IMapFrom<Supplier>
{
    public void Mapping(Profile profile)
    {


        profile.CreateMap<Supplier, SupplierDto>(MemberList.None).ReverseMap();


        //    profile.CreateMap<Supplier, SupplierDto>()
        //  .ForMember(dto => dto.Scorecards, opt => opt.MapFrom(x => x.Questionaires)).ReverseMap()
        //.AfterMap((s, d) =>
        //{
        //    foreach (var bookCategory in d.Questionaires)
        //        bookCategory.SupplierId = s.Id;
        //});

    }

    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Tax Reference Number is required")]
    public string TaxReferenceNumber { get; set; }

    [Required(ErrorMessage = "Category is required")]
    public CategoryEnum? Category { get; set; }

    public string RiskRating { get; set; }

    public List<ContactDto> Contacts { get; set; } = new List<ContactDto>() { new ContactDto() };


    public List<SupplierQuestionaireDto> SupplierQuestionaires { get; set; } = new List<SupplierQuestionaireDto>();

    public List<Attachment> Attachments { get; set; } = new List<Attachment>();

    public BlazorShared.Models.AddressDto PhysicalAddress { get; set; } = new ();

    [Required(ErrorMessage = "Phone Number is required")]
    public string PhoneNumber { get; set; }

    public BlazorShared.Models.ContactDto PrimaryContact { get; set; } = new ();

    public string Comments { get; set; }

    //public List<SupplierQuestionaireDto> SupplierQuestionaires { get; set; } = new List<SupplierQuestionaireDto>();
    public StatusEnum Status { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public string Website { get; set; }

    [Required(ErrorMessage ="Please confirm that the information provided is accurate and complete by checking the box")]
    public bool? DeclarationChecked { get; set; }

    public SupplierDto()
    {
        Status = StatusEnum.Pending;
    }
}


public enum StatusEnum
{
    Active,
    Pending,
    Suspended,
    Inactive

}
