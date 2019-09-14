using Accounts.Data;
using HR.Data;
using Inventories.Data;
using Maintenance.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MobileMoney.Data;
using Newtonsoft.Json.Serialization;
using Purchase.Data;
using System.Linq;
using UserManagement.Domain.Entities;
using UserManagemnet.Data;

namespace Purchase.UI.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AccountsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));
            services.AddDbContext<HRContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));
            services.AddDbContext<InventoryContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));
            services.AddDbContext<MaintenanceContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));
            services.AddDbContext<MobileMoneyContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));
            services.AddDbContext<PurchaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));
            services.AddDbContext<ReferenceContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));
            services.AddDbContext<UserManagerContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));
            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<UserManagerContext>();
            services.AddMvc().AddNewtonsoftJson();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
            }

            app.UseStaticFiles();
            app.UseClientSideBlazorFiles<Client.Startup>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToClientSideBlazor<Client.Startup>("index.html");
            });
        }
    }
}
