using AutoMapper;
using BlazorShared.Models;
using CleanArchitecture.Blazor.Application.Common.Interfaces;
using EasyCaching.Core;

namespace BlazorShared.Services;
[ScopedRegistration]
public class ProjectService : IProjectService
{

    private readonly IEasyCachingProviderFactory _factory;
    private readonly IEasyCachingProvider _provider;
    private readonly IEventService _eventService;
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;



    public ProjectService(IEasyCachingProviderFactory factory,IEventService eventService, IApplicationDbContext context, IMapper mapper)
    {
        _factory = factory;
        _provider = _factory.GetCachingProvider("default");
        _eventService = eventService;
        _context= context;

        _mapper= mapper;


    }


         
    public async Task<ProjectDto> Create(ProjectDto request)
    {
        string cacheKey = $"project:{request.Id}";

        _provider.Set<Models.ProjectDto>(cacheKey, request, new TimeSpan(1, 0, 0));

        _context.Projects.Add(_mapper.Map<CleanArchitecture.Blazor.Domain.Entities.Project>(request));
        await _context.SaveChangesAsync(new CancellationToken());
        return request;
    }

    public async Task<ProjectDto> Retrieve(Guid id)
    {
        string cacheKey = $"project:{id}";
        //var results =await  _provider.GetAsync<Models.ProjectDto>(cacheKey);
        //results.Value.Events = await _eventService.Search(new EventSearchRequest() { ProjectId = results.Value.Id });

       var project= _context.Projects.Where(x => x.Id == id).FirstOrDefault();

        return _mapper.Map<ProjectDto>(project);
        //return results.Value;
    }

    public async Task<List<ProjectDto>> Search(ProjectSearchRequest projectSearchRequest)
    {
        var projects = new List<ProjectDto>();
        projects.Add(new ProjectDto() {Id = Guid.NewGuid(),Description="Procurement for the Sales Department",ProjectName="Sales Department",ProjectCode ="KJLAS001",Status = StatusEnum.Inactive });
        projects.Add(new ProjectDto() { Id = Guid.NewGuid(), Description = "FICA Project", ProjectName = "Demo Project", ProjectCode = "KJLAS002", Status = StatusEnum.Inactive });
        var results = await _provider.GetByPrefixAsync<Models.ProjectDto>("project");

        foreach (var item in results.Values)
        {
            projects.Add(item.Value);
        }

        var projectsFromDb = _context.Projects.ToList();
        return _mapper.Map<List<ProjectDto>>(projectsFromDb);


        return projects;
    }
}
