using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BlazorShared.Models;

public class EventDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProjectId { get; set; }

    public string EventName { get; set; }
    public EventType EventType { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public List<SupplierDto> SelectedSuppliers { get; set; } = new List<SupplierDto>();

    public List<QuestionaireDto> Questionaires { get; set; } = new List<QuestionaireDto>();

    public QuestionaireDto Questionaire { get; set; } = new QuestionaireDto() {  };

    public EventStatus EventStatus { get; set; } = EventStatus.Draft;

    public List<SupplierQuestionaireDto> Invitations { get; set; } = new List<SupplierQuestionaireDto>();


    public void PublishEvent()
    {
        try
        {
            if (!EndDate.HasValue)
                throw new Exception("End Date Not Populated");
    
                foreach (var invite in Invitations)
                {
                    if (invite.Questionaire == null)
                    {
                        invite.Questionaire = Questionaires.FirstOrDefault();
                    }
                }
          
            
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
