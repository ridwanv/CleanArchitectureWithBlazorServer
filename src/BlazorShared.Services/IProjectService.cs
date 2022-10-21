using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Models;

namespace BlazorShared.Services;
public  interface IProjectService
{
    Task<List<Project>> Search(ProjectSearchRequest projectSearchRequest);
    Task<Project> Retrieve(Guid id);

    Task<Project> Create(Project supplierCreateRequest);
}
