// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.Suppliers.DTOs;
using CleanArchitecture.Blazor.Application.Features.Suppliers.Caching;

namespace CleanArchitecture.Blazor.Application.Features.Suppliers.Queries.Pagination;

    public class SuppliersWithPaginationQuery : PaginationFilter, IRequest<PaginatedData<SupplierDto>>, ICacheable
    {
        public string CacheKey => SupplierCacheKey.GetPaginationCacheKey($"{this}");
        public MemoryCacheEntryOptions? Options => SupplierCacheKey.MemoryCacheEntryOptions;
    }
    
    public class SuppliersWithPaginationQueryHandler :
         IRequestHandler<SuppliersWithPaginationQuery, PaginatedData<SupplierDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SuppliersWithPaginationQueryHandler> _localizer;

        public SuppliersWithPaginationQueryHandler(
            IApplicationDbContext context,
            IMapper mapper,
            IStringLocalizer<SuppliersWithPaginationQueryHandler> localizer
            )
        {
            _context = context;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<PaginatedData<SupplierDto>> Handle(SuppliersWithPaginationQuery request, CancellationToken cancellationToken)
        {
            // TODO: Implement SuppliersWithPaginationQueryHandler method 
           var data = await _context.Suppliers
                .OrderBy($"{request.OrderBy} {request.SortDirection}")
                .ProjectTo<SupplierDto>(_mapper.ConfigurationProvider)
                .PaginatedDataAsync(request.PageNumber, request.PageSize);
            return data;
        }
   }