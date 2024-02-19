namespace CleanArchitecture.Blazor.Domain.Entities;

public   class QuestionResponse : AuditableEntity
{

    public Guid Id { get; set; }
    public Guid SupplierQuestionaireId { get; set; }
    public Guid QuestionId { get; set; }
    public string? Answer { get; set; }

    public virtual SupplierQuestionaire SupplierQuestionaire { get; set; }
    public virtual Question Question { get; set; }

}

public enum Priority
{
    MustHave = 1,
    SHouldHave,
    LikeToHave,
    CouldHave

}

public enum Assessment
{
    NotApplicable = 0,
    DoNotComply = 1,
    PartiallyComply = 2,
    FullyComply = 3

}