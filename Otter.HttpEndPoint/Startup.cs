using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Otter.Business.Definitions.Factories;
using Otter.Business.Definitions.Services;
using Otter.Business.Fake;
using Otter.Business.Implementations.Factories;
using Otter.Business.Implementations.Services;
using Otter.DataAccess;
using Otter.DataAccess.SQLServer;
using Otter.ExternalService;
using Otter.ExternalService.Sms;
using Otter.ExternalService.Utilities;

namespace Otter.HttpEndPoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();
                    });
            });

            // *Add Authentication & Authorization
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://accounts.tejaratnoins.ir";
                    options.Audience = "mobile-insurance";
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        RequireAudience = true,
                        ValidateAudience = true
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequiredMobileInsuranceScopes", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "mobile-insurance");
                    policy.RequireClaim("scope", "access-management");
                });
            });

            DependencyInjection(services);

            services.AddControllersWithViews();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            string swaggerPath = env.IsDevelopment() ? "/swagger/v1/swagger.json" : "../swagger/v1/swagger.json";
            app.UseSwaggerUI(c => { c.SwaggerEndpoint(swaggerPath, "My API V1"); });
        }

        private void DependencyInjection(IServiceCollection services)
        {
            var useFakeService =
                Configuration.GetValue<bool>("UseFakeService");

            if (!useFakeService)
            {
                services.AddScoped<IUnitOfWork, SqlUnitOfWork>();
                services.AddScoped<ICurrencyFactory, CurrencyFactory>();
                services.AddScoped<ICurrencyService, CurrencyService>();
                services.AddScoped<IPolicyService, PolicyService>();
                services.AddScoped<IPolicyFactory, PolicyFactory>();
                services.AddScoped<IProvinceFactory, ProvinceFactory>();
                services.AddScoped<ICityFactory, CityFactory>();
                services.AddScoped<IPremiumInquiryService, PremiumInquiryService>();
                services.AddScoped<IDiscountService, DiscountService>();
                services.AddScoped<IConfigurationService, ConfigurationService>();
                services.AddScoped<ISmsService, SmsService>();
                services.AddScoped<IInternalClientService, InternalClientService>();
                services.AddScoped<IPolicyFileFactory, PolicyFileFactory>();
                services.AddScoped<ISpeakerTestNumberService, SpeakerTestNumberService>();
                services.AddScoped<IBrandFactory, BrandFactory>();
                services.AddScoped<IModelFactory, ModelFactory>();
                services.AddScoped<IBaseDataService, BaseDataService>();
                services.AddScoped<IPaymentService, PaymentService>();
                services.AddScoped<IPaymentFactory, PaymentFactory>();
                services.AddScoped<ISpeakerTestNumberFactory, SpeakerTestNumberFactory>();
                services.AddScoped<IDiscountFactory, DiscountFactory>();
                services.AddScoped<ILinkShortenerService, LinkShortenerService>();
                services.AddScoped<IHttpClientService, HttpClientService>();
                services.AddScoped<ICentralInsuranceIdentityInquiry, CentralInsuranceIdentityInquiry>();
            }
            else
            {
                services.AddScoped<ICurrencyService, CurrencyFakeService>();
            }
        }
    }
}