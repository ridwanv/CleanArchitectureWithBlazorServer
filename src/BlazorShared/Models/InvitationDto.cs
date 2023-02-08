using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;
public class InvitationDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid SupplierId { get; set; }
    public SupplierDto Supplier { get; set; } = new SupplierDto();
    public QuestionaireDto Questionaire { get; set; } = new QuestionaireDto();

    public InvitationStatus InvitationStatus { get; set; } = InvitationStatus.Draft;
}

public enum InvitationStatus
{
    Draft,
    InvitationSent,
    InProgress,
    ResponseCompleted

}