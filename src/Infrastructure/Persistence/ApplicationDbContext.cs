// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Reflection;
using CleanArchitecture.Blazor.Infrastructure.Extensions;
using CleanArchitecture.Blazor.Infrastructure.Persistence.Interceptors;
using MediatR;

namespace CleanArchitecture.Blazor.Infrastructure.Persistence;

#nullable disable
public class ApplicationDbContext : IdentityDbContext<
    ApplicationUser, ApplicationRole, string,
    ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
    ApplicationRoleClaim, ApplicationUserToken>, IApplicationDbContext
{


    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,

        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor
        ) : base(options)
    {
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    public DbSet<Project> Projects { get; set; }
    public DbSet<AnswerFormat> AnswerFormats { get; set; }
    public DbSet<ShortText> ShortTextAnswerFormats { get; set; }
    public DbSet<Evaluation> EvaluationAnswerFormats { get; set; }

    public DbSet<Invitation> Invitations { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Logger> Loggers { get; set; }
    public DbSet<AuditTrail> AuditTrails { get; set; }
    public DbSet<Document> Documents { get; set; }

    public DbSet<KeyValue> KeyValues { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.ApplyGlobalFilters<ISoftDelete>(s => s.Deleted == null);

    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

}