using BlazingInvoices.Data;
using BlazingInvoices.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazingInvoices.Services;

public class InvoiceService
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public InvoiceService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
    {
        _contextFactory = dbContextFactory;
    }

    public async Task<InvoiceModel> SaveInvoiceAsync(string userId, InvoiceModel model)
    {
        using var context = _contextFactory.CreateDbContext();

        if (model.Id == 0)
        {
            //new invoice creation
            Invoice invoice = new Invoice
            {
                Id = model.Id,
                BusinessAddress = model.BusinessAddress,
                BusinessContactNumber = model.BusinessContactNumber,
                BusinessEmailId = model.BusinessEmailId,
                BusinessName = model.BusinessName,
                ClientContactNumber = model.ClientContactNumber,
                ClientEmailId = model.ClientEmailId,
                ClientName = model.ClientName,
                ClientId = model.ClientId,
                DueOn = model.DueOn,
                InvoiceNumber = model.InvoiceNumber,
                IsPaid = model.IsPaid,
                IssuedOn = model.IssuedOn,
                Notes = model.Notes,
                TaxPercentage = model.TaxPercentage,
                UserId = userId,
                LineItems = model.LineItems.Select(li => new InvoiceLineItem
                {
                    Name = li.ServiceName,
                    Quantity = li.Quantity,
                    Rate = li.Rate,
                    ServiceId = li.ServiceId,
                    Unit = li.Unit
                }).ToArray()
            };
            context.Invoices.Add(invoice);
        }
        else
        {
            //update existing invoice
        }

        await context.SaveChangesAsync();
        return model;
    }




    public async Task<PagedResult<InvoiceModel>> GetInvoicesAsync(string userId, string forTabType, int pageNumber = 1, int pageSize = 10)
    {
        using var context = _contextFactory.CreateDbContext();

        var query = context.Invoices
            .Include(i => i.LineItems)
            .Where(i => i.UserId == userId);

        query = forTabType switch
        {
            InvoiceTabTypes.Recent => query,
            InvoiceTabTypes.Pending => query.Where(i => !i.IsPaid),
            InvoiceTabTypes.Paid => query.Where(i => i.IsPaid),
            InvoiceTabTypes.All => query,
            _ => throw new InvalidOperationException()
        };

        query = query.OrderByDescending(i => i.Id);

        int total = await query.CountAsync();

        if (forTabType == InvoiceTabTypes.Recent)
        {
            query = query.Take(10);
        }
        else
        {
            query = query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }

        var invoices = await query.Select(i => new InvoiceModel
        {
            Id = i.Id,
            LineItems = i.LineItems
                    .Select(li => new InvoiceLineItemModel
                    {
                        Quantity = li.Quantity,
                        Rate = li.Rate,
                        ServiceId = li.ServiceId ?? 0,
                        ServiceName = li.Name,
                        Unit = li.Unit,
                    }).ToArray(),
            IsPaid = i.IsPaid,
            BusinessAddress = i.BusinessAddress,
            BusinessContactNumber = i.BusinessContactNumber,
            BusinessEmailId = i.BusinessEmailId,
            BusinessName = i.BusinessName,
            ClientContactNumber = i.ClientContactNumber,
            ClientEmailId = i.ClientEmailId,
            ClientId = i.ClientId ?? 0,
            ClientName = i.ClientName,
            DueOn = i.DueOn,
            InvoiceNumber = i.InvoiceNumber,
            IssuedOn = i.IssuedOn,
            TaxPercentage = i.TaxPercentage,
            PaidOn = i.PaidOn,
            Notes = i.Notes



        }).ToListAsync();

        return PagedResult<InvoiceModel>.Create(invoices, total);
    }
}
