// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.Suppliers.DTOs;
using CleanArchitecture.Blazor.Application.Features.Suppliers.Caching;

namespace CleanArchitecture.Blazor.Application.Features.Suppliers.Queries.GetAll;

    public class GetAllSuppliersQuery : IRequest<IEnumerable<SupplierDto>>, ICacheable
    {
       public string CacheKey => SupplierCacheKey.GetAllCacheKey;
       public MemoryCacheEntryOptions? Options => SupplierCacheKey.MemoryCacheEntryOptions;
    }
    
    public class GetAllSuppliersQueryHandler :
         IRequestHandler<GetAllSuppliersQuery, IEnumerable<SupplierDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<GetAllSuppliersQueryHandler> _localizer;

        public GetAllSuppliersQueryHandler(
            IApplicationDbContext context,
            IMapper mapper,
            IStringLocalizer<GetAllSuppliersQueryHandler> localizer
            )
        {
            _context = context;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<IEnumerable<SupplierDto>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            // TODO: Implement GetAllSuppliersQueryHandler method 
            var data = await _context.Suppliers
                         .ProjectTo<SupplierDto>(_mapper.ConfigurationProvider)
                         .ToListAsync(cancellationToken);
            return data;
        }
    }


