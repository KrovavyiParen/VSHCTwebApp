using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI;
using VSHCTwebApp.Components;
using VSHCTwebApp.Components.Account;
using VSHCTwebApp.Components.Services;
using VSHCTwebApp.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.AspNetCore.Authentication.Cookies;
using VSHCTwebApp.Services;
using VSHCTwebApp.Components.Models;

namespace VSHCTwebApp
{

    public class ProjectAvailabilityService : BackgroundService
    {
        private readonly IServiceProvider _services;
        private readonly ILogger<ProjectAvailabilityService> _logger;

        public ProjectAvailabilityService(IServiceProvider services, ILogger<ProjectAvailabilityService> logger)
        {
            _services = services;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _services.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<VSHCTwebAppContext>();

                    var now = DateTime.Now;
                    var expiredProjects = await dbContext.Project
                        .Where(p => p.IsManuallyMadeAvailable &&
                                   p.AvailableUntil.HasValue &&
                                   p.AvailableUntil <= now)
                        .ToListAsync();

                    foreach (var project in expiredProjects)
                    {
                        project.Status = ProjectStatus.Approved;
                        project.IsManuallyMadeAvailable = false;
                        _logger.LogInformation($"Project {project.Id} returned to confirmed (expired)");
                    }

                    if (expiredProjects.Any())
                    {
                        await dbContext.SaveChangesAsync();
                    }
                }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken); // Проверяем каждый час
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContextFactory<VSHCTwebAppContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("VSHCTwebAppContext") ?? throw new InvalidOperationException("Connection string 'VSHCTwebAppContext' not found.")));

            builder.Services.AddQuickGridEntityFrameworkAdapter();

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<IdentityUserAccessor>();
            builder.Services.AddScoped<IdentityRedirectManager>();
            builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

            builder.Services.AddScoped<LikeService> ();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.SlidingExpiration = true;
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LogoutPath = "/";  // Кастомный путь
                options.LoginPath = "/Account/Login";    // Чтобы не было /Identity/Account/Login
                options.ExpireTimeSpan = TimeSpan.FromDays(3);
                options.SlidingExpiration = true;
            });

            builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
                options.TokenLifespan = TimeSpan.FromHours(3));

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(connectionString),
                ServiceLifetime.Scoped);

            builder.Services.AddDbContextFactory<ApplicationDbContext>(
                options => options.UseSqlServer(connectionString),
                ServiceLifetime.Scoped);

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
            });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("ClientOnly", policy => policy.RequireRole("ClientOnly"));
            });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("ClientOrAdmin", policy =>
                    policy.RequireAssertion(context =>
                        context.User.IsInRole("Client") || context.User.IsInRole("Admin")));
            });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("TeamLidOnly", policy => policy.RequireRole("TeamLid"));
            });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOrTeacher", policy =>
                    policy.RequireAssertion(context =>
                        context.User.IsInRole("Admin") || context.User.IsInRole("Teacher")));
            });



            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDbContextFactory<VSHCTwebAppContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("VSHCTwebAppContext") ??
                    throw new InvalidOperationException(
            "Connection string 'VSHCTwebAppContext' not found.")));

            builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);

            builder.Services.AddQuickGridEntityFrameworkAdapter();

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

            builder.Services.AddSingleton<CommandService>();

            builder.Services.AddScoped<ProfileService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseMigrationsEndPoint();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            // Add additional endpoints required by the Identity /Account Razor components.
            app.MapAdditionalIdentityEndpoints();

            app.Run();


        }
    }
}
