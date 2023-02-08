using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Blazor.Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CleanArchitecture.Blazor.Domain.Entities;
public class Event:AuditableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProjectId { get; set; }

    public string EventName { get; set; }
    public EventType EventType { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Questionaire Questionaire { get; set; } = new Questionaire() { };

    public EventStatus EventStatus { get; set; } = EventStatus.Draft;

    public ICollection<Supplier> Suppliers { get; set; }
    public ICollection<Invitation> Invitations { get; set; } 
}
