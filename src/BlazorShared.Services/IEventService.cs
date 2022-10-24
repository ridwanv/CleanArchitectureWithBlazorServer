using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Models;

namespace BlazorShared.Services;
public  interface IEventService
{
    Task<List<Event>> Search(EventSearchRequest eventSearchRequest);
    Task<Event> Retrieve(Guid id);

    Task<Event> Create(Event eventRequest);

    Task<Event> Update(Event eventRequest);

    Task<Invitation> GetInvitation(Guid id);

    Task<Event> Publish(Guid id);

    Task<Questionaire> SubmitResponse(Guid invitationId, Questionaire questionaire);
}
