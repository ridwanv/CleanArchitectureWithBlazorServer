using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CleanArchitecture.Blazor.Domain.Entities;
public class Supplier : AuditableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }
    public string? TaxReferenceNumber { get; set; }

    public string? Category { get; set; }

    public string? RiskRating { get; set; }

    public ICollection<Contact> Contacts { get; set; }

    public ICollection<SupplierQuestionaire> SupplierQuestionaires { get; set; } 

   // public List<Attachment> Attachments { get; set; }

    public virtual Address? PhysicalAddress { get; set; }

    public string? PhoneNumber { get; set; }

    //public Contact PrimaryContact { get; set; } = new Contact();

    public string? Comments { get; set; }
    public ICollection<Event> Events { get; set; }
    public ICollection<Invitation> Invitations { get; set; }
}
