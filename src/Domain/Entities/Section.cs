using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Blazor.Domain.Entities;
public class Section
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string SectionName { get; set; }
    public List<Question> Questions { get; set; } = new List<Question>();
    public List<SubSection> SubSections { get; set; } = new List<SubSection>();
}
