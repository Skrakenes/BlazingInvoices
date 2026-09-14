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
}
