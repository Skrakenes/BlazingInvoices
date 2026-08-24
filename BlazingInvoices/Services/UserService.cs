using BlazingInvoices.Data;
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
        using var context =  _contextFactory.CreateDbContext();

        var user = await context.Users
                            .AsNoTracking()
                            .Where(u => u.Id == userId)
                            .Select(u=> new {u.Name, u.BusinessName})
                            .FirstOrDefaultAsync();

        ArgumentNullException.ThrowIfNull(user);
        
        return (user.Name, user.BusinessName);
    }
}
