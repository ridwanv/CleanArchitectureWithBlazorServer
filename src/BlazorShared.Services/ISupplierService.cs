using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Models;

namespace BlazorShared.Services;
public  interface ISupplierService
{
    Task<List<Supplier>> SearchSuppliers(SupplierSearchRequest supplierSearchRequest);
    Task<Supplier> Retrieve(Guid id);

    Task<Supplier> Create(SupplierCreateRequest supplierCreateRequest);
}
