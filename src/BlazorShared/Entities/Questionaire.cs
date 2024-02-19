using static System.Collections.Specialized.BitVector32;

namespace CleanArchitecture.Blazor.Domain.Entities;

public class Questionaire
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public List<Section> Sections { get; set; } = new List<Section>();
}