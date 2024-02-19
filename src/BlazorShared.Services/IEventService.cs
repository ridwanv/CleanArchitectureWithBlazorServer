using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Models;

namespace BlazorShared.Services;
public  interface IEventService
{
    Task<List<EventDto>> Search(EventSearchRequest eventSearchRequest);
    Task<EventDto> Retrieve(Guid id);

    Task<EventDto> Create(EventDto eventRequest);

    Task<EventDto> Update(EventDto eventRequest);

    Task<SupplierQuestionaireDto> GetInvitation(Guid id);

    Task<EventDto> Publish(Guid id);

    Task<QuestionaireDto> SubmitResponse(Guid invitationId, QuestionaireDto questionaire);
}
