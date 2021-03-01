using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlueTooth.AutoMapper;
using BlueTooth.DbContext;
using BlueTooth.Models;
using BlueTooth.Models.Implementations;
using BlueTooth.Models.Interfaces;
using BlueTooth.Models.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlueTooth
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("BlueToothDBContext")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            var mappingConfig = new MapperConfiguration(mc =>
              {
                  mc.AddProfile(new MappingProfile());
              });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            
            services.AddRazorPages();

            services.AddScoped<IFirmaRepository, FirmaSQLRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentSQLRepository>();
            services.AddScoped<IDentalCheckRepository, DentalCheckUpSQLRepository>();
            services.AddScoped<IDiagnoseRepository, DiagnoseSQLRepository>();
            services.AddScoped<IEstablishedDiagnosisRepository, EstablishedDiagnosisSQLRepository>();
            services.AddScoped<IDentalCheckWorkerRepository, DentalCheckWorkerSQLRepository>();
            services.AddScoped<_IDentalCheckWorkersRepository, _DentalCheckWorkersSQLRepository>();
            services.AddScoped<IRatingRepository, RatingSQLRepository>();
            services.AddScoped<IServiceRepository, ServiceSQLRepository>();
            services.AddScoped<IDentalCheckServicesRepository, DentalCheckServiceSQLRepository>();
            services.AddScoped<_IDentalCheckServicesRepository, _DentalCheckServicesSQLRepository>();
            services.AddScoped<IUspostaviDijagnozu, UspostaviDijagnozuRepository>();
            services.AddScoped<IBillRepository, BillSQLRepository>();
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
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
