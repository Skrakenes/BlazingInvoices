using BlazingInvoices.Data;
using BlazingInvoices.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazingInvoices.Services;

public class UserService
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public UserService(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<(string Name, string BusinessName)> GetUserInfoAsync(string userId)
    {
        using var context = _contextFactory.CreateDbContext();

        var user = await context.Users
                            .AsNoTracking()
                            .Where(u => u.Id == userId)
                            .Select(u => new { u.Name, u.BusinessName })
                            .FirstOrDefaultAsync();

        ArgumentNullException.ThrowIfNull(user);

        return (user.Name, user.BusinessName);
    }

    public async Task<BusinessInfoModel> GetBusinessInfoAsync(string userId)
    {
        using var context = _contextFactory.CreateDbContext();

        var businessInfo = await context.Users
                            .AsNoTracking()
                            .Where(u => u.Id == userId)
                            .Select(u => new BusinessInfoModel
                            {
                                Address = u.BusinessAddress,
                                BusinessName = u.BusinessName,
                                ContactNumber = u.BusinessContactNumber,
                                EmailId = u.BusinessEmailId,
                                TaxPercentage = u.TaxPercentage
                            })
                            .FirstOrDefaultAsync();
        return businessInfo!;
    }

    public async Task SaveBusinessInfoAsync(string userId, BusinessInfoModel businessInfo)
    {
        using var context = _contextFactory.CreateDbContext();

        var user = await context.Users
                            .Where(u => u.Id == userId)
                            .FirstOrDefaultAsync();

        user.BusinessAddress = businessInfo.Address;
        user.BusinessName = businessInfo.BusinessName;
        user.BusinessContactNumber = businessInfo.ContactNumber;
        user.BusinessEmailId = businessInfo.EmailId;
        user.TaxPercentage = businessInfo.TaxPercentage;

        await context.SaveChangesAsync();
    }
}
