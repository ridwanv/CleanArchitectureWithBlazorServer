using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Models;

namespace BlazorShared.Services;
public  interface IProjectService
{
    Task<List<ProjectDto>> Search(ProjectSearchRequest projectSearchRequest);
    Task<ProjectDto> Retrieve(Guid id);

    Task<ProjectDto> Create(ProjectDto supplierCreateRequest);
}
