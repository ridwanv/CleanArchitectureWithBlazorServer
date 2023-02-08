using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Blazor.Application.Features.AuditTrails.DTOs;
using CleanArchitecture.Blazor.Domain.Entities;
using CleanArchitecture.Blazor.Domain.Entities.Audit;

namespace BlazorShared.Models;

public class Attachment
{
    public string AttachmentType { get; set; }
    public byte[] Contents { get; set; }
}

public class Requests
{

    public string Name { get; set; }
    public string Description { get; set; }
    public List<Attachment> AvailableDocuments { get; set; }
    public QuestionaireDto RequestQuestionaire { get; set; }


}

public class ProjectSearchRequest
{
    public string Name { get; set; }

}

public class EventSearchRequest
{
    public string Name { get; set; }
    public Guid ProjectId { get; set; }

}



public enum EventStatus
{
    Draft,
    Active, 
    Paused,
    Ended



}
public enum EventType
{
    RFI,
    Request,
    RFQ
}

public class SupplierSearchRequest
{
    public string Name { get; set; }

}

public class SupplierSearchResponse
{
    public List<SupplierDto> Suppliers { get; set; }
}

public class SupplierCreateRequest
{

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = $"Supplier{DateOnly.FromDateTime(DateTime.Now)}";
    public string TaxReferenceNumber { get; set; }
    public string Website { get; set; }
    public List<ContactDto> Contacts { get; set; } = new List<ContactDto>();
    public List<Attachment> Attachments { get; set; } = new List<Attachment>();
    public AddressDto PhysicalAddress { get; set; } = new AddressDto();

    public string PhoneNumber { get; set; }

    public ContactDto PrimaryContact { get; set; } = new ContactDto();

    public string Comments { get; set; }

}

public enum SupplierType
{
    Broker,
    Vendor
}