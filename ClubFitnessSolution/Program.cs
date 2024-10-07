using ClubFitnessDomain;
using ClubFitnessSolution.Components;
using ClubFitnessSolution.Components.Account;
using ClubFitnessDomain;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Radzen;
using ClubFitnessInfrastructure;
using ClubFitnessInfrastructure.Interfaces;
using ClubFitnessInfrastructure.Repositories;
using System.Reflection;
using ClubFitnessSolution;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();


builder.Services.AddRadzenComponents();
builder.Services.AddScoped<DialogService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ClubFitnessDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ClubFitnessDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

// Register the generic repository
//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Register all services with transient lifetime
// Get the assembly containing the services (e.g., MyServicesAssembly.dll)
var clubFitnessInfrastructure = Assembly.Load("ClubFitnessInfrastructure");
var clubFitnessServices = Assembly.Load("ClubFitnessServices");

//// Register all repositories
builder.Services.AddAllRepositoriesFromAssemblies(clubFitnessInfrastructure);

// Register all services
builder.Services.AddAllServicesFromAssemblies(clubFitnessServices);

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();




var app = builder.Build();

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

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
