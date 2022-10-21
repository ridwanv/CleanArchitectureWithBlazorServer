using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;
public class Supplier
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string TaxReferenceNumber { get; set; }

    public string Category { get; set; }

    public string RiskRating { get; set; }

    public List<Contact> Contacts { get; set; }

    public List<Questionaire> OnboardingQuestionaires { get; set; }

    public List<Attachment> Attachments { get; set; }

    public Address PhysicalAddress { get; set; }

    public string PhoneNumber { get; set; }

    public Contact PrimaryContact { get; set; } = new Contact();

    public string Comments { get; set; }

    public List<Invitation> Invitations { get; set; }
}

public class Contact
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FullName { get; set; }
    public string Position { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }

}

public class Project
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string ProjectName { get; set; }
    public string ProjectCode { get; set; }
    public string Description { get; set; }

    public List<Event> Events { get; set; } = new List<Event>();



}

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
    public Questionaire RequestQuestionaire { get; set; }


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

public class Event
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProjectId { get; set; }

    public string EventName { get; set; }
    public EventType EventType { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public List<Supplier> Suppliers { get; set; } = new List<Supplier>();

    public Questionaire Questionaire { get; set; } = new Questionaire() {  };

    public EventStatus EventStatus { get; set; } = EventStatus.Draft;

    public List<Invitation> Invitations { get; set; } = new List<Invitation>();


    public void PublishEvent()
    {
        try
        {
            if (!EndDate.HasValue)
                throw new Exception("End Date Not Populated");
            this.EventStatus = EventStatus.Active;
            StartDate = DateTime.Now;
        }
        catch (Exception)
        {

            throw;
        }

    }
    public Event(Guid projectId)
    {

    }

    public Event()
    {

    }

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
    public List<Supplier> Suppliers { get; set; }
}

public class SupplierCreateRequest
{

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = $"Supplier{DateOnly.FromDateTime(DateTime.Now)}";
    public string TaxReferenceNumber { get; set; }
    public string Website { get; set; }
    public List<Contact> Contacts { get; set; } = new List<Contact>();
    public List<Attachment> Attachments { get; set; } = new List<Attachment>();
    public Address PhysicalAddress { get; set; } = new Address();

    public string PhoneNumber { get; set; }

    public Contact PrimaryContact { get; set; } = new Contact();

    public string Comments { get; set; }

}

public enum SupplierType
{
    Broker,
    Vendor
}