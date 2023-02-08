// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.Suppliers.DTOs;
using CleanArchitecture.Blazor.Application.Features.Suppliers.Caching;

namespace CleanArchitecture.Blazor.Application.Features.Suppliers.Commands.Update;

    public class UpdateSupplierCommand: SupplierDto,IRequest<Result>, ICacheInvalidator
    {
        public string CacheKey => SupplierCacheKey.GetAllCacheKey;
        public CancellationTokenSource? SharedExpiryTokenSource => SupplierCacheKey.SharedExpiryTokenSource();
    }

    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, Result>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<UpdateSupplierCommandHandler> _localizer;
        public UpdateSupplierCommandHandler(
            IApplicationDbContext context,
            IStringLocalizer<UpdateSupplierCommandHandler> localizer,
             IMapper mapper
            )
        {
            _context = context;
            _localizer = localizer;
            _mapper = mapper;
        }
        public async Task<Result> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
           // TODO: Implement UpdateSupplierCommandHandler method 
           var item =await _context.Suppliers.FindAsync( new object[] { request.Id }, cancellationToken);
           if (item != null)
           {
                item = _mapper.Map(request, item);
				// raise a update domain event
				item.AddDomainEvent(new UpdatedEvent<Supplier>(item));
                await _context.SaveChangesAsync(cancellationToken);
           }
           return await Result.SuccessAsync();
        }
    }

