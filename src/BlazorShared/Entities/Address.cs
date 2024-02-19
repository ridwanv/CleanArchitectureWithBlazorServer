using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Blazor.Domain.Common;

namespace CleanArchitecture.Blazor.Domain.Entities;
public class Address: AuditableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Line1 { get; set; }
    public string Line2 { get; set; }
    public string City { get; set; }
    public string Code { get; set; }
}
