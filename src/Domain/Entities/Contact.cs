using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Blazor.Domain.Entities;
public class Contact : AuditableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? FullName { get; set; }
    public string? Position { get; set; }
    public string? EmailAddress { get; set; }
    public string? PhoneNumber { get; set; }

    public ICollection<Supplier> Suppliers { get; set; }
}
