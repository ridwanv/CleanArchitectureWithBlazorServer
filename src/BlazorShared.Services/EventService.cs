using BlazorShared.Events;
using BlazorShared.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using EasyCaching.Core;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorShared.Services;
[ScopedRegistration]
public class EventService : IEventService
{

    private readonly IEasyCachingProviderFactory _factory;
    private readonly IEasyCachingProvider _provider;
    private readonly IPublisher _publisher;


    public EventService(IEasyCachingProviderFactory factory, IPublisher publisher)
    {
        _factory = factory;
        _provider = _factory.GetCachingProvider("default");
        _publisher = publisher;
    }


         
    public async Task<Event> Create(Event request)
    {
        var e = await Retrieve(request.Id);
        if (e != null)
            return await Update(request);

        string cacheKey = "";
        await _publisher.Publish(new CreatedEvent<Event>(request));

        //foreach (var invite in request.Invitations)
        //{
        //    invite.Questionaire = request.Questionaire;
        //    cacheKey = $"invitation:{invite.Id}";
        //    _provider.Set<Models.Invitation>(cacheKey, invite, new TimeSpan(1, 0, 0));
        //    await _publisher.Publish(new CreatedEvent<Invitation>(invite));
        //}

        //foreach (var supplier in request.Suppliers)
        //{
        //    //create response link 
        //    var invitation = new Invitation() { Questionaire = request.Questionaire, Supplier = supplier };
        //    cacheKey = $"invitation:{invitation.Id}";
        //    supplier.Invitations.Add(invitation);
        //    _provider.Set<Models.Invitation>(cacheKey, invitation, new TimeSpan(1, 0, 0));
        //    await _publisher.Publish(new CreatedEvent<Invitation>(invitation));
        //}



        cacheKey = $"event:{request.Id}";
        _provider.Set<Models.Event>(cacheKey, request, new TimeSpan(1, 0, 0));
        return request;
    }

    public async Task<Invitation> GetInvitation(Guid id)
    {
        string cacheKey = $"invitation:{id}";
        var results = await _provider.GetAsync<Models.Invitation>(cacheKey);
        return results.Value;
    }

    public async Task<Event> Publish(Guid id)
    {
        string cacheKey = $"event:{id}";
        var eventre = await _provider.GetAsync<Models.Event>(cacheKey);
      
        return eventre.Value;
    }

    public async Task<Event> Retrieve(Guid id)
    {
        string cacheKey = $"event:{id}";
        var results =await  _provider.GetAsync<Models.Event>(cacheKey);
        cacheKey = $"response:{results.Value.Questionaire.QuestionaireId}";
        foreach (var invite in results.Value.Invitations)
        {
            cacheKey = $"response:{invite.Id}";
            var questionaire = _provider.GetAsync<Models.Questionaire>(cacheKey).Result;
            if (questionaire.HasValue)
                invite.Questionaire = questionaire.Value;
        }

        return results.Value;
    }

    public async Task<Questionaire> SubmitResponse(Guid InvitationId, Questionaire questionaire)
    {
        string cacheKey = $"response:{InvitationId}";
        _provider.Set<Models.Questionaire>(cacheKey, questionaire, new TimeSpan(1, 0, 0));
        return questionaire;
    }

    public async Task<List<Event>> Search(EventSearchRequest eventSearchRequest)
    {
        var projects = new List<Event>();

        var results = await _provider.GetByPrefixAsync<Models.Event>("event");

        foreach (var item in results.Values)
        {
            if (item.Value.ProjectId == eventSearchRequest.ProjectId)
                projects.Add(item.Value);
        }

        return projects;
    }

    public async Task<Event> Update(Event eventRequest)
    {
        string cacheKey = $"event:{eventRequest.Id}";
        var eve = await Retrieve(eventRequest.Id);
        eve.StartDate = eventRequest.StartDate;
        eve.EndDate = eventRequest.EndDate;
        eve.Suppliers = eventRequest.Suppliers;
        eve.Invitations = eventRequest.Invitations;
        eve.Questionaire = eventRequest.Questionaire;

        if(eve.EventStatus!=eventRequest.EventStatus)
        {
            if(eventRequest.EventStatus == EventStatus.Active)
            {
                eve.EventStatus = eventRequest.EventStatus;

                foreach (var invite in eventRequest.Invitations)
                {
                    invite.InvitationStatus = InvitationStatus.InvitationSent;
                    invite.Questionaire = eventRequest.Questionaire;
                    cacheKey = $"invitation:{invite.Id}";
                    _provider.Set<Models.Invitation>(cacheKey, invite, new TimeSpan(1, 0, 0));
                    await _publisher.Publish(new CreatedEvent<Invitation>(invite));
                }

            }

        }
       cacheKey = $"event:{eventRequest.Id}";
        _provider.Set<Models.Event>(cacheKey, eve, new TimeSpan(1, 0, 0));
        return eve;

    }
}
