using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Enums;
using CleanArchitecture.Blazor.Domain.Common;
using CleanArchitecture.Blazor.Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CleanArchitecture.Blazor.Domain.Entities;
public class Event: AuditableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProjectId { get; set; }

    public string EventName { get; set; }
    public BlazorShared.Enums.EventType EventType { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Questionaire Questionaire { get; set; } = new Questionaire() { };

    public BlazorShared.Enums.EventStatus EventStatus { get; set; } = BlazorShared.Enums.EventStatus.Draft;

    public ICollection<Supplier> Suppliers { get; set; }
    public ICollection<Invitation> Invitations { get; set; } 
}
