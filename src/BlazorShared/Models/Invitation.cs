using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;
public class Invitation
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid SupplierId { get; set; }
    public Supplier Supplier { get; set; } = new Supplier();
    public Questionaire Questionaire { get; set; } = new Questionaire();

    public InvitationStatus InvitationStatus { get; set; } = InvitationStatus.Draft;
}

public enum InvitationStatus
{
    Draft,
    InvitationSent,
    InProgress,
    ResponseCompleted

}