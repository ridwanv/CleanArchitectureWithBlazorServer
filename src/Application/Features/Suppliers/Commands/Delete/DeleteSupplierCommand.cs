// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using CleanArchitecture.Blazor.Application.Features.Suppliers.DTOs;
using CleanArchitecture.Blazor.Application.Features.Suppliers.Caching;


namespace CleanArchitecture.Blazor.Application.Features.Suppliers.Commands.Delete;

    public class DeleteSupplierCommand: IRequest<Result>, ICacheInvalidator
    {
      public Guid[] Id {  get; }
      public string CacheKey => SupplierCacheKey.GetAllCacheKey;
      public CancellationTokenSource? SharedExpiryTokenSource => SupplierCacheKey.SharedExpiryTokenSource();
      public DeleteSupplierCommand(Guid[] id)
      {
        Id = id;
      }
    }

    public class DeleteSupplierCommandHandler : 
                 IRequestHandler<DeleteSupplierCommand, Result>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<DeleteSupplierCommandHandler> _localizer;
        public DeleteSupplierCommandHandler(
            IApplicationDbContext context,
            IStringLocalizer<DeleteSupplierCommandHandler> localizer,
             IMapper mapper
            )
        {
            _context = context;
            _localizer = localizer;
            _mapper = mapper;
        }
        public async Task<Result> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            // TODO: Implement DeleteCheckedSuppliersCommandHandler method 
            var items = await _context.Suppliers.Where(x => request.Id.Contains(x.Id)).ToListAsync(cancellationToken);
            foreach (var item in items)
            {
			    // raise a delete domain event
				item.AddDomainEvent(new DeletedEvent<Supplier>(item));
                _context.Suppliers.Remove(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
            return await Result.SuccessAsync();
        }

    }

