using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using CleanArchitecture.Blazor.Domain.Enums;

namespace CleanArchitecture.Blazor.Domain.Entities;
public class SupplierQuestionaire : AuditableEntity
{

    public Guid Id { get; set; }
    public Guid SupplierId { get; set; }
    public Supplier Supplier { get; set; }
    public Guid QuestionaireId { get; set; }

    public InvitationStatusEnum InvitationStatus { get; set; }

    public virtual Questionaire? Questionaire { get; set; }

    public ICollection<QuestionResponse> QuestionResponses { get; set; }

}

