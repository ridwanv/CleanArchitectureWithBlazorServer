using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Models;

namespace BlazorShared.Services;
public  interface ISupplierService
{
    Task<List<SupplierDto>> SearchSuppliers(SupplierSearchRequest supplierSearchRequest);
    Task<SupplierDto> Retrieve(Guid id);

    Task<SupplierDto> Create(SupplierCreateRequest supplierCreateRequest);
}
