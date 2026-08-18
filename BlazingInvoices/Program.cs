using BlazingInvoices.Components;
using BlazingInvoices.Components.Account;
using BlazingInvoices.Data;
using BlazingInvoices.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(options=>
    {
#if DEBUG
        options.DetailedErrors = true;
#endif
    });

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.Stores.SchemaVersion = IdentitySchemaVersions.Version3;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

builder.Services.AddScoped<UiService>();

var app = builder.Build();

#if DEBUG
AutoMigrateDb(app.Services);
SeedUserAsync(app.Services).GetAwaiter().GetResult();
#endif

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();

static void AutoMigrateDb(IServiceProvider sp)
{
    using var scope = sp.CreateScope();
    using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

static async Task SeedUserAsync(IServiceProvider sp)
{
    using var scope = sp.CreateScope();
    using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    if (context.Users.Any())
        return;

    var userStore = scope.ServiceProvider.GetRequiredService<IUserStore<ApplicationUser>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    var user = Activator.CreateInstance<ApplicationUser>();

    user.Name = "Test User";
    user.TaxPercentage = 5;
    user.BusinessName = "Test Business";
    user.BusinessEmailId = "mybiz@test.com";
    user.BusinessContactNumber = "12345678";
    user.BusinessAddress = "123 Test Street";

    var email = "test@test.com";
    var password = "Test123!";

    await userStore.SetUserNameAsync(user, email, CancellationToken.None);

    var emailStore = (IUserEmailStore<ApplicationUser>)userStore;
    await emailStore.SetEmailAsync(user, email, CancellationToken.None);

    var result = await userManager.CreateAsync(user, password);
}