using BlazorShared.Models;
using FluentValidation;
/// <summary>
/// A standard AbstractValidator which contains multiple rules and can be shared with the back end API
/// </summary>
/// <typeparam name="OrderModel"></typeparam>
public class BankAccountFluentValidator : AbstractValidator<BankVerificationRequest>
{
    public BankAccountFluentValidator()
    {

    }

    private async Task<bool> IsUniqueAsync(string email)
    {
        // Simulates a long running http call
        await Task.Delay(2000);
        return email.ToLower() != "test@test.com";
    }

    //public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    //{
    //    var result = await ValidateAsync(ValidationContext<OrderModel>.CreateWithOptions((OrderModel)model, x => x.IncludeProperties(propertyName)));
    //    if (result.IsValid)
    //        return Array.Empty<string>();
    //    return result.Errors.Select(e => e.ErrorMessage);
    //};
}