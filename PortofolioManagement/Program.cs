using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using PortofolioManagement.Components;
using PortofolioManagement.DbModels;
using PortofolioManagement.Services;

var builder = WebApplication.CreateBuilder(args);

try
{
    // Add services to the container.
    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents();

    builder.Services.AddScoped<PriceSeederService>();
    builder.Services.AddScoped<HistoricalPriceFetcherService>();
    builder.Services.AddScoped<PriceService>();
    builder.Services.AddScoped<CryptocurrencyService>();
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddDataProtection()
        .SetApplicationName("CryptoPortofolioManagement");

    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();
    builder.Logging.SetMinimumLevel(LogLevel.Debug);

    var app = builder.Build();

    using (var scope = app.Services.CreateScope())
    {
        var seeder = scope.ServiceProvider.GetRequiredService<PriceSeederService>();
        await seeder.SeedPricesAsync();
    }
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error", createScopeForErrors: true);
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();
    app.UseAntiforgery();

    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode();

    app.Run();
}
catch (Exception ex)
{

}
