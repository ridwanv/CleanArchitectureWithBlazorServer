namespace BlazorShared.Models;

public class EventDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProjectId { get; set; }

    public string EventName { get; set; }
    public EventType EventType { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public List<SupplierDto> Suppliers { get; set; } = new List<SupplierDto>();

    public QuestionaireDto Questionaire { get; set; } = new QuestionaireDto() {  };

    public EventStatus EventStatus { get; set; } = EventStatus.Draft;

    public List<InvitationDto> Invitations { get; set; } = new List<InvitationDto>();


    public void PublishEvent()
    {
        try
        {
            if (!EndDate.HasValue)
                throw new Exception("End Date Not Populated");
            this.EventStatus = EventStatus.Active;
            StartDate = DateTime.Now;
        }
        catch (Exception)
        {

            throw;
        }

    }
    public EventDto(Guid projectId)
    {

    }

    public EventDto()
    {

    }

}
