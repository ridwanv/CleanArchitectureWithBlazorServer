using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BlazorShared.Models;
using CleanArchitecture.Blazor.Application.Common.Interfaces;
using EasyCaching.Core;

namespace BlazorShared.Services;
[ScopedRegistration]
public class SupplierService : ISupplierService
{

    private readonly IEasyCachingProviderFactory _factory;
    private readonly IEasyCachingProvider _provider;
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;




    public SupplierService(IEasyCachingProviderFactory factory, IApplicationDbContext context, IMapper mapper)
    {
        _factory = factory;
        _provider = _factory.GetCachingProvider("default");
        _context = context;
        _mapper = mapper;
    }



    public async Task<SupplierDto> Create(SupplierCreateRequest request)
    {

        string cacheKey = $"supplier:{request.Id}";
        var supplier = new SupplierDto()
        {
            Id = request.Id,
            Name = request.Name,
            Attachments = request.Attachments,
            Comments = request.Comments,
            PhoneNumber = request.PhoneNumber,
            Contacts = request.Contacts,
            TaxReferenceNumber = request.TaxReferenceNumber

        };
        try
        {
            var entity = _mapper.Map<CleanArchitecture.Blazor.Domain.Entities.Supplier>(supplier);
            _context.Suppliers.Add(entity);
            await _context.SaveChangesAsync(new CancellationToken());
        }
        catch (Exception ex)
        {
            
            throw;
        }
   
     
        _provider.Set<Models.SupplierDto>(cacheKey, supplier, new TimeSpan(1, 0, 0));
        return supplier;
    }

    public async Task<SupplierDto> Retrieve(Guid id)
    {
        var suppliers = await SearchSuppliers(new SupplierSearchRequest());
        return suppliers.FirstOrDefault();
    }

    public async Task<List<SupplierDto>> SearchSuppliers(SupplierSearchRequest supplierSearchRequest)
    {
        var suppliers = new List<SupplierDto>(); ;// { new SupplierDto() { Id = new Guid("e14172fd-da80-47ef-8adc-fd2bf0f72664"), Name =" PBSA",TaxReferenceNumber = "JHGHKGASD", Contacts = new List<ContactDto>() { new ContactDto() { Id = new Guid("3e2fd844-1295-44a1-80ce-e9f3b48075e1"), FullName = "Ridwan",EmailAddress = "Ridz01@gmail.com"} } } };

        // var results = _provider.GetByPrefix<Models.SupplierDto>("supplier");

        var results = _context.Suppliers.AsEnumerable();
        foreach (var item in results)
        {
            var supplier = _mapper.Map<SupplierDto>(item);
            suppliers.Add(supplier);
        }
        
        return suppliers;
    }
}
