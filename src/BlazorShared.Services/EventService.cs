using AutoMapper;
using BlazorShared.Events;
using BlazorShared.Models;
using CleanArchitecture.Blazor.Application.Common.Interfaces;
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
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;


    public EventService(IEasyCachingProviderFactory factory, IPublisher publisher, IApplicationDbContext context, IMapper mapper)
    {
        _factory = factory;
        _provider = _factory.GetCachingProvider("default");
        _publisher = publisher;
        _context = context;
        _mapper= mapper;

    }


         
    public async Task<EventDto> Create(EventDto request)
    {
       
        var e = await Retrieve(request.Id);
        if (e != null)
            return await Update(request);

        string cacheKey = "";
        await _publisher.Publish(new CreatedEvent<EventDto>(request));

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
        _provider.Set<Models.EventDto>(cacheKey, request, new TimeSpan(1, 0, 0));
        return request;
    }

    public async Task<InvitationDto> GetInvitation(Guid id)
    {
        string cacheKey = $"invitation:{id}";
        var results = await _provider.GetAsync<Models.InvitationDto>(cacheKey);
        if(results.HasValue)
        {
            cacheKey = $"response:{id}";
            var questionaire = _provider.GetAsync<Models.QuestionaireDto>(cacheKey).Result;
            if (questionaire.HasValue)
                results.Value.Questionaire = questionaire.Value;
        }
        return results.Value;
    }

    public async Task<EventDto> Publish(Guid id)
    {
        string cacheKey = $"event:{id}";
        var eventre = await _provider.GetAsync<Models.EventDto>(cacheKey);
      
        return eventre.Value;
    }

    public async Task<EventDto> Retrieve(Guid id)
    {
        string cacheKey = $"event:{id}";
        var results =await  _provider.GetAsync<Models.EventDto>(cacheKey);

        if (results.HasValue)
        {
            foreach (var invite in results.Value.Invitations)
            {
                cacheKey = $"response:{invite.Id}";
                var questionaire = _provider.GetAsync<Models.QuestionaireDto>(cacheKey).Result;
                if (questionaire.HasValue)
                    invite.Questionaire = questionaire.Value;
            }
            return results.Value;
        }
        return null;
        
    }

    public async Task<QuestionaireDto> SubmitResponse(Guid InvitationId, QuestionaireDto questionaire)
    {
        string cacheKey = $"response:{InvitationId}";
        _provider.Set<Models.QuestionaireDto>(cacheKey, questionaire, new TimeSpan(1, 0, 0));
        return questionaire;
    }

    public async Task<List<EventDto>> Search(EventSearchRequest eventSearchRequest)
    {
        var projects = new List<EventDto>();

        var results = await _provider.GetByPrefixAsync<Models.EventDto>("event");

        foreach (var item in results.Values)
        {
            if (item.Value.ProjectId == eventSearchRequest.ProjectId)
                projects.Add(item.Value);
        }

        return projects;
    }

    public async Task<EventDto> Update(EventDto eventRequest)
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
                    _provider.Set<Models.InvitationDto>(cacheKey, invite, new TimeSpan(1, 0, 0));
                    await _publisher.Publish(new CreatedEvent<InvitationDto>(invite));
                }

            }

        }
       cacheKey = $"event:{eventRequest.Id}";
        _provider.Set<Models.EventDto>(cacheKey, eve, new TimeSpan(1, 0, 0));
        return eve;

    }
}
