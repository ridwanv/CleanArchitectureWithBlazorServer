// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.Suppliers.Caching;

public static class SupplierCacheKey
{
    public const string GetAllCacheKey = "all-Suppliers";
    public static string GetPaginationCacheKey(string parameters) {
        return $"SuppliersWithPaginationQuery,{parameters}";
    }
    static SupplierCacheKey()
    {
        _tokensource = new CancellationTokenSource(new TimeSpan(3,0,0));
    }
    private static CancellationTokenSource _tokensource;
    public static CancellationTokenSource SharedExpiryTokenSource()
    {
        if (_tokensource.IsCancellationRequested)
        {
            _tokensource = new CancellationTokenSource(new TimeSpan(3, 0, 0));
        }
        return _tokensource;
    }
    public static MemoryCacheEntryOptions MemoryCacheEntryOptions => new MemoryCacheEntryOptions().AddExpirationToken(new CancellationChangeToken(SharedExpiryTokenSource().Token));
}

