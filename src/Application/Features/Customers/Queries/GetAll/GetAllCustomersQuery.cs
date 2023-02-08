﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.Customers.DTOs;
using CleanArchitecture.Blazor.Application.Features.Customers.Caching;

namespace CleanArchitecture.Blazor.Application.Features.Customers.Queries.GetAll;

    public class GetAllSuppliersQuery : IRequest<IEnumerable<CustomerDto>>, ICacheable
    {
       public string CacheKey => CustomerCacheKey.GetAllCacheKey;
       public MemoryCacheEntryOptions? Options => CustomerCacheKey.MemoryCacheEntryOptions;
    }
    
    public class GetAllCustomersQueryHandler :
         IRequestHandler<GetAllSuppliersQuery, IEnumerable<CustomerDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<GetAllCustomersQueryHandler> _localizer;

        public GetAllCustomersQueryHandler(
            IApplicationDbContext context,
            IMapper mapper,
            IStringLocalizer<GetAllCustomersQueryHandler> localizer
            )
        {
            _context = context;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<IEnumerable<CustomerDto>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            // TODO: Implement GetAllCustomersQueryHandler method 
            var data = await _context.Customers
                         .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                         .ToListAsync(cancellationToken);
            return data;
        }
    }


