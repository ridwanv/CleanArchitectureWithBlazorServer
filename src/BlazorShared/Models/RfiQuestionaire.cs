using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;
public class RfiQuestionaire
{
    public List<EvaluationSection> EvaluationSections { get; set; } = new List<EvaluationSection>();
}

public class EvaluationSection
{
    public List<Criteria> Criterion { get; set; } = new List<Criteria>();
}



public enum Priority
{
    MustHave=1,
    SHouldHave,
    LikeToHave,
    CouldHave

}

public enum Assessment
{
    NotApplicable = 0,
    DoNotComply =1,
    PartiallyComply=2,
    FullyComply=3

}
