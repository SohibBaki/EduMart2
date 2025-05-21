using EduMart.Data;
using EduMart.Data.Cart;
using EduMart.Data.Services;
using EduMart.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EduMart
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // DbContext configuration
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Services configuration
            services.AddScoped<IMentorsService, MentorsService>();
            services.AddScoped<ISkillOrganizersService, SkillOrganizersService>();
            services.AddScoped<IPlatformService, PlatformService>();
            services.AddScoped<ISkillsService,  SkillsService>();
            services.AddScoped<IOrdersService, OrdersService>();

            // Add session support
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

            // Authentication and Authorization configuration
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.AddMemoryCache();
            services.AddSession();
            services.AddAuthentication(option =>
            {
                option.DefaultScheme = IdentityConstants.ApplicationScheme;
            });
            services.AddControllersWithViews();
            services.AddCors();

            // Configure cookie policy
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.Secure = CookieSecurePolicy.Always;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseBrowserLink(); // Disable Browser Link
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors();
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy(); // Ensure cookie policy is applied

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
