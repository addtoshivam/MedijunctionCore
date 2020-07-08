using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medijunction.DAL;
using Medijunction.DAL.Contracts;
using MediJunction.DomainModel;
using MediJunction.DomainModel.Contracts;
using MediJunction.Process;
using MediJunction.Process.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Medijunction.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddDbContextPool<MediJunctionContext>(
                (options) => {
                    options.UseSqlServer(Configuration.GetConnectionString("MedijunctionContext"),
                    x =>
                    {
                        x.MigrationsAssembly("Medijunction.Api")
                         .EnableRetryOnFailure(3, TimeSpan.FromSeconds(1), null);
                    });
                }
                );
            
            //services.AddScoped<DbContext, MediJunctionContext>((container) => container.GetService<MediJunctionContext>());
            services.AddScoped<DbContext, MediJunctionContext>();
            //services.Add(new ServiceDescriptor(typeof(IEFRepository<BaseEntity>), typeof(EFRepository<BaseEntity>), ServiceLifetime.Transient));
            services.AddScoped(typeof(IEFRepository<BaseEntity>), typeof(EFRepository<BaseEntity>));
            services.AddScoped(typeof(IEFRepository<AppointmentMaster>), typeof(EFRepository<AppointmentMaster>));
            services.AddScoped(typeof(IEFRepository<TodaysPatientImage>), typeof(EFRepository<TodaysPatientImage>));
            services.AddScoped(typeof(IEFRepository<TodaysPatientList>), typeof(EFRepository<TodaysPatientList>));
            services.AddScoped(typeof(IEFRepository<PreConsultation>), typeof(EFRepository<PreConsultation>));
            RegisterAllData(services);
            RegisterAllProcess(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseMvc(routes => {
                routes.MapRoute("default", "{controller=Users}/{action=}/{id?}");
            });
        }

        private void RegisterAllData(IServiceCollection services)
        {
            services.AddSingleton<IDataFactory, DataFactory>();
            services.AddScoped<IAppointmentMasterDAL, AppointmentMasterDAL>();
            services.AddScoped<ITodaysPatientImageDAL, TodaysPatientImageDAL>();
            services.AddScoped<ITodaysPatientListDAL, TodaysPatientListDAL>();
            services.AddScoped<IPreconsulationDAL, PreConsultationDAL>();
        }

        private void RegisterAllProcess(IServiceCollection services)
        {
            services.AddScoped<IUserProcess, UserProcess>();
        }
    }
}
