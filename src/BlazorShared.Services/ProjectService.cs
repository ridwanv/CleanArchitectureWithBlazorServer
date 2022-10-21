using BlazorShared.Models;
using EasyCaching.Core;

namespace BlazorShared.Services;
[ScopedRegistration]
public class ProjectService : IProjectService
{

    private readonly IEasyCachingProviderFactory _factory;
    private readonly IEasyCachingProvider _provider;
    private readonly IEventService _eventService;


    public ProjectService(IEasyCachingProviderFactory factory,IEventService eventService)
    {
        _factory = factory;
        _provider = _factory.GetCachingProvider("default");
        _eventService = eventService;
    }


         
    public async Task<Project> Create(Project request)
    {
        string cacheKey = $"project:{request.Id}";

        _provider.Set<Models.Project>(cacheKey, request, new TimeSpan(1, 0, 0));
        return request;
    }

    public async Task<Project> Retrieve(Guid id)
    {
        string cacheKey = $"project:{id}";
        var results =await  _provider.GetAsync<Models.Project>(cacheKey);
        results.Value.Events = await _eventService.Search(new EventSearchRequest() { ProjectId = results.Value.Id });
        return results.Value;
    }

    public async Task<List<Project>> Search(ProjectSearchRequest projectSearchRequest)
    {
        var projects = new List<Project>();

        var results = await _provider.GetByPrefixAsync<Models.Project>("project");

        foreach (var item in results.Values)
        {
            projects.Add(item.Value);
        }

        return projects;
    }
}
