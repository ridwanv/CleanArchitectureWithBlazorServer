using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Blazor.Application.Common.Interfaces;
using CleanArchitecture.Blazor.Domain.Entities;
using Hangfire;

namespace BlazorShared.Services;

[ScopedRegistration]
public class FileImportService:IFileImportService
{

    private IExcelService _excelService;

    public FileImportService(IExcelService excelService)
    {
        _excelService = excelService;
    }

    public async Task<List<Models.PersonIdentificationRequest>> ReadFile(string fileName, byte[] data)
    {
        var s = await _excelService.ImportAsync<Models.PersonIdentificationRequest>(data, mappers: new Dictionary<string, Func<DataRow, Models.PersonIdentificationRequest, object>>
            {
                { "IdentityNumber", (row,item) => item.IdentityNumber = row["IdentityNumber"]?.ToString() }
            });
        foreach (var item in s.Data)
        {
            
        }

        return s.Data.ToList();
    }


}
