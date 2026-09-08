using BlazingInvoices.Data;
using BlazingInvoices.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazingInvoices.Services;

public class ProductService
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public ProductService(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<ServiceModel>> GetServicesAsync(string userId)
    {
        using var context = _contextFactory.CreateDbContext();

        return await context.Services
            .AsNoTracking()
            .Where(s => s.UserId == userId)
            .Select(s => new ServiceModel
            {
                Description = s.Description,
                Id = s.Id,
                Name = s.Name,
                Rate = s.Rate,
                Unit = s.Unit
            }).ToArrayAsync();
    }

    public async Task<ServiceModel> SaveAsync(string userId, ServiceModel model)
    {
        using var context = _contextFactory.CreateDbContext();

        Service? service = null;

        // Create new Service
        if (model.Id == 0)
        {
            service = new Service
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Rate = model.Rate,
                Unit = model.Unit,
                UserId = userId
            };
            context.Services.Add(service);

        }

        // Update existing Service
        else
        {
            service = await context.Services
                .AsTracking()
                .Where(s => s.Id == model.Id && s.UserId == userId)
                .FirstOrDefaultAsync();

            ArgumentNullException.ThrowIfNull(service);

            service.Name = model.Name;
            service.Description = model.Description;
            service.Rate = model.Rate;
            service.Unit = model.Unit;
        }
        await context.SaveChangesAsync();

        model.Id = service.Id;

        return model;
    }

    public async Task DeleteAsync(string userId, int serviceId)
    {
        using var context = _contextFactory.CreateDbContext();

        var service = await context.Services
               .AsNoTracking()
               .Where(s => s.Id == serviceId && s.UserId == userId)
               .FirstOrDefaultAsync();

        ArgumentNullException.ThrowIfNull(service);

        context.Services.Remove(service);
        await context.SaveChangesAsync();
    }
}
