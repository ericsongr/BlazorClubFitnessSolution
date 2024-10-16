using ClubFitnessDomain;
using ClubFitnessSolution.Components;
using ClubFitnessSolution.Components.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Radzen;
using ClubFitnessInfrastructure;
using System.Reflection;
using ClubFitnessDomain.Validators;
using ClubFitnessSolution;
using ClubFitnessSolution.MappingProfiles;
using ClubFitnessSolution.Services.Hubs;
using FluentValidation;
using FluentValidation.AspNetCore;
using ClubFitnessSolution.Services;
using Microsoft.JSInterop;

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

//register for signalr these 3
//builder.Services.AddRazorPages();
//builder.Services.AddServerSideBlazor();
builder.Services.AddSignalR(); 
builder.Services.AddRadzenComponents();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<ChatService>();
builder.Services.AddScoped<UserGroupService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ClubFitnessDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ClubFitnessDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

//AutoMappers
builder.Services.AddAutoMapper(typeof(AdministratorProfile));


// Register the generic repository
//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Register all services with transient lifetime
// Get the assembly containing the services (e.g., MyServicesAssembly.dll)
var clubFitnessInfrastructure = Assembly.Load("ClubFitnessInfrastructure");
var clubFitnessServices = Assembly.Load("ClubFitnessServices");

builder.Services.AddScoped<AuthenticationStateProvider, UserAuthenticationStateProvider>();
builder.Services.AddScoped<UserAuthenticationStateProvider>();

//// Register all repositories
builder.Services.AddAllRepositoriesFromAssemblies(clubFitnessInfrastructure);

// Register all services
builder.Services.AddAllServicesFromAssemblies(clubFitnessServices);

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

// Register automapper validators
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<AccountProductCategoryDtoValidator>();

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

//register for signalr - hub
//app.MapRazorPages();
//app.MapBlazorHub();
app.MapHub<ChatHub>("/chathub");
//app.MapFallbackToPage("/_Host");

app.Run();
