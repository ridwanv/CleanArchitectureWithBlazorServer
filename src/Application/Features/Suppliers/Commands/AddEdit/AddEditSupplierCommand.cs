// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using CleanArchitecture.Blazor.Application.Features.Suppliers.DTOs;
using CleanArchitecture.Blazor.Application.Features.Suppliers.Caching;
namespace CleanArchitecture.Blazor.Application.Features.Suppliers.Commands.AddEdit;

    public class AddEditSupplierCommand: SupplierDto,IRequest<Result<Guid>>, ICacheInvalidator
    {
      public string CacheKey => SupplierCacheKey.GetAllCacheKey;
      public CancellationTokenSource? SharedExpiryTokenSource => SupplierCacheKey.SharedExpiryTokenSource();
    }

    public class AddEditSupplierCommandHandler : IRequestHandler<AddEditSupplierCommand, Result<Guid>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditSupplierCommandHandler> _localizer;
        public AddEditSupplierCommandHandler(
            IApplicationDbContext context,
            IStringLocalizer<AddEditSupplierCommandHandler> localizer,
            IMapper mapper
            )
        {
            _context = context;
            _localizer = localizer;
            _mapper = mapper;
        }
        public async Task<Result<Guid>> Handle(AddEditSupplierCommand request, CancellationToken cancellationToken)
        {
            // TODO: Implement AddEditSupplierCommandHandler method 
            if (request.Id > 0)
            {
                var item = await _context.Suppliers.FindAsync(new object[] { request.Id }, cancellationToken) ?? throw new NotFoundException($"Supplier {request.Id} Not Found.");
                item = _mapper.Map(request, item);
				// raise a update domain event
				item.AddDomainEvent(new UpdatedEvent<Supplier>(item));
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<Guid>.SuccessAsync(item.Id);
            }
            else
            {
                var item = _mapper.Map<Supplier>(request);
                // raise a create domain event
				item.AddDomainEvent(new CreatedEvent<Supplier>(item));
                _context.Suppliers.Add(item);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<Guid>.SuccessAsync(item.Id);
            }
           
        }
    }

