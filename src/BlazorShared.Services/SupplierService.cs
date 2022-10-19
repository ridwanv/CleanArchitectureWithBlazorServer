using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Models;
using EasyCaching.Core;

namespace BlazorShared.Services;
[ScopedRegistration]
public class SupplierService : ISupplierService
{

    private readonly IEasyCachingProviderFactory _factory;
    private readonly IEasyCachingProvider _provider;


    public SupplierService(IEasyCachingProviderFactory factory)
    {
        _factory = factory;
        _provider = _factory.GetCachingProvider("default");
    }


         
    public async Task<Supplier> Create(SupplierCreateRequest request)
    {
        string cacheKey = $"supplier:{request.Id}";
        var supplier = new Supplier()
        {
            Id = request.Id,
            Name = request.Name,
            Attachments = request.Attachments,
            Comments = request.Comments,
            PhoneNumber = request.PhoneNumber,
            Contacts = request.Contacts,
            TaxReferenceNumber = request.TaxReferenceNumber

        };
        _provider.Set<Models.Supplier>(cacheKey, supplier, new TimeSpan(1, 0, 0));
        return supplier;
    }

    public async Task<Supplier> Retrieve(Guid id)
    {
        var suppliers = await SearchSuppliers(new SupplierSearchRequest());
        return suppliers.FirstOrDefault();
    }

    public async Task<List<Supplier>> SearchSuppliers(SupplierSearchRequest supplierSearchRequest)
    {
        var suppliers = new List<Supplier>() { new Supplier() { Name=" PBSA",TaxReferenceNumber = "JHGHKGASD"} };

        var results = _provider.GetByPrefix<Models.Supplier>("supplier");

        foreach (var item in results)
        {
            suppliers.Add(item.Value.Value);
        }
        
        return suppliers;
    }
}
