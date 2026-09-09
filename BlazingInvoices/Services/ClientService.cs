using BlazingInvoices.Data;
using BlazingInvoices.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazingInvoices.Services;

public class ClientService
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public ClientService(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<ClientModel>> GetClientsAsync(string userId)
    {
        using var context = _contextFactory.CreateDbContext();

        return await context.Clients
            .AsNoTracking()
            .Where(s => s.UserId == userId)
            .Select(s => new ClientModel
            {
                Id = s.Id,
                ContactNumber = s.ContactNumber,
                EmailId = s.EmailId,
                Name = s.Name,
                Remarks = s.Remarks
            }).ToArrayAsync();
    }

    public async Task<ClientModel> SaveAsync(string userId, ClientModel model)
    {
        using var context = _contextFactory.CreateDbContext();

        Client? client = null;

        // Create new client
        if (model.Id == 0)
        {
            client = new Client
            {
                Name = model.Name,
                Remarks = model.Remarks,
                EmailId = model.EmailId,
                ContactNumber = model.ContactNumber,
                UserId = userId
            };
            context.Clients.Add(client);

        }

        // Update existing client
        else
        {
            client = await context.Clients
                .AsTracking()
                .Where(s => s.Id == model.Id && s.UserId == userId)
                .FirstOrDefaultAsync();

            ArgumentNullException.ThrowIfNull(client);

            client.Name = model.Name;
            client.Remarks = model.Remarks;
            client.EmailId = model.EmailId;
            client.ContactNumber = model.ContactNumber;
        }
        await context.SaveChangesAsync();

        model.Id = client.Id;

        return model;
    }

    public async Task DeleteAsync(string userId, int clientId)
    {
        using var context = _contextFactory.CreateDbContext();

        var client = await context.Clients
               .AsNoTracking()
               .Where(s => s.Id == clientId && s.UserId == userId)
               .FirstOrDefaultAsync();

        ArgumentNullException.ThrowIfNull(client);

        context.Clients.Remove(client);
        await context.SaveChangesAsync();
    }
}
