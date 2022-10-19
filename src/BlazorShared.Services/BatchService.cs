using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Models;
using CleanArchitecture.Blazor.Application.Common.Interfaces;
using EasyCaching.Core;
using Hangfire;

namespace BlazorShared.Services;


[ScopedRegistration]
public class BatchService : IBatchService
{
    private IExcelService _excelService;
    private IPartyService _partyService;

    private readonly IEasyCachingProviderFactory _factory;
    private readonly IEasyCachingProvider _provider;
    private readonly IBackgroundJobClient _backgroundJobClient;

    public BatchService(IPartyService partyService, IExcelService excelService, IEasyCachingProviderFactory factory, IBackgroundJobClient backgroundJobClient)
    {
        _partyService = partyService;
        _excelService = excelService;
        _backgroundJobClient = backgroundJobClient;
 

        this._factory = factory;
        _provider = _factory.GetCachingProvider("default");
    }
    public async Task<Batch> UploadIdentifications(string fileName, byte[] data)
    {  
        Batch batch = new Batch() { BatchId = Guid.NewGuid(), FileName = fileName};
        string cacheKey = $"batchidentification:{batch.BatchId}";
        var s = await _excelService.ImportAsync<Models.PersonIdentificationRequest>(data, mappers: new Dictionary<string, Func<DataRow, Models.PersonIdentificationRequest, object>>
            {
                { "IdentityNumber", (row,item) => item.IdentityNumber = row["IdentityNumber"]?.ToString() }
            });
        foreach (var item in s.Data)
        {
            batch.PersonIdentificationRequests.Add(item);           
        }
        BackgroundJob.Enqueue(() => ProcessBatch(batch.BatchId));
        _provider.Set<Models.Batch>(cacheKey, batch, new TimeSpan(1, 0, 0));
        return batch;
    }

    public void ProcessBatch(Guid batchId)
    {
        string cacheKey = $"batchidentification:{batchId}";
        Console.WriteLine("Start " + batchId);
        var batch =  Get(batchId).Result;
        foreach (var item in batch.PersonIdentificationRequests)
        {
            var person = _partyService.Retrieve(item);
            batch.PersonIdentifications.Add(person.Result);
        }
        batch.BatchStatus = BatchStatus.Complete;
        _provider.Set<Models.Batch>(cacheKey, batch, new TimeSpan(1, 0, 0));
    }

    public async Task<Batch> Get(Guid batchId)
    {
        string cacheKey = $"batchidentification:{batchId}";
        var responses = new Batch();
        var results = _provider.Get<Models.Batch>(cacheKey);
        return results.Value;
    }

    public async Task<List<Batch>> Search(BatchSearchModel batchSearchModel)
    {
        var responses = new List<Models.Batch>();
        var results = _provider.GetByPrefix<Models.Batch>("batchidentification");
        foreach (var item in results)
        {
            responses.Add(item.Value.Value);
        }
        return responses;
    }

    public async Task<byte[]> Export(BatchSearchModel batchSearchModel)
    {
        var data = await Get(batchSearchModel.BatchId);
        var result = await _excelService.ExportAsync(data.PersonIdentifications,
            new Dictionary<string, Func<Models.PersonIdentification, object>>()
            {
                    //{ _localizer["Id"], item => item.Id },
                    { "Identity Number", item => item.IdentityNumber },
                    { "First Name", item => item.FirstName },
                    { "Last Name", item => item.LastName },

            }, "Sheet1"
            );
        return result;
    }
}
