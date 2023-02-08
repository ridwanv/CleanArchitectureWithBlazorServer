// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.Suppliers.Commands.Update;

public class UpdateSupplierCommandValidator : AbstractValidator<UpdateSupplierCommand>
{
        public UpdateSupplierCommandValidator()
        {
           // TODO: Implement UpdateSupplierCommandValidator method, for example: 
           // RuleFor(v => v.Name)
           //      .MaximumLength(256)
           //      .NotEmpty();
           throw new System.NotImplementedException();
        }
     public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
     {
        var result = await ValidateAsync(ValidationContext<UpdateSupplierCommand>.CreateWithOptions((UpdateSupplierCommand)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
     };
}

