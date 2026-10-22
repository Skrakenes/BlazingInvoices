using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazingInvoices.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }
    public DbSet<InvoiceCounter> InvoiceCounters { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<InvoiceCounter>(e =>
        {
            // Primary Key
            e.HasKey(ic => new { ic.UserId, ic.Year });
        });

        builder.Entity<Invoice>(e =>
        {
            // Uniqe index on userId+Invocie number
            e.HasIndex(i => new { i.UserId, i.InvoiceNumber }).IsUnique();
        });
    }
}
