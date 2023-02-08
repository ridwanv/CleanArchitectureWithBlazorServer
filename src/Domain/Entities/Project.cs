using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Blazor.Domain.Entities;
public class Project : AuditableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string ProjectName { get; set; }
    public string ProjectCode { get; set; }
    public string Description { get; set; }

    public List<Event> Events { get; set; } = new List<Event>();
}
