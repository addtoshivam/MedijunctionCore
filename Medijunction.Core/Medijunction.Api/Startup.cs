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
using SimpleInjector;

namespace Medijunction.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _container = new Container();
        }

        public IConfiguration Configuration { get; }
        public Container _container;

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
            
            services.AddScoped<DbContext, MediJunctionContext>((container) => container.GetService<MediJunctionContext>());
            services.AddApiVersioning(o => {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
            services.AddSimpleInjector(_container, options =>
            {
                // AddAspNetCore() wraps web requests in a Simple Injector scope and
                // allows request-scoped framework services to be resolved.
                options.AddAspNetCore()

                    // Ensure activation of a specific framework type to be created by
                    // Simple Injector instead of the built-in configuration system.
                    // All calls are optional. You can enable what you need. For instance,
                    // ViewComponents, PageModels, and TagHelpers are not needed when you
                    // build a Web API.
                    .AddControllerActivation()
                    .AddViewComponentActivation()
                    .AddPageModelActivation()
                    .AddTagHelperActivation();

                // Optionally, allow application components to depend on the non-generic
                // ILogger (Microsoft.Extensions.Logging) or IStringLocalizer
                // (Microsoft.Extensions.Localization) abstractions.
                options.AddLogging();
                //options.AddLocalization();
            });
            _container.Register(typeof(IEFRepository<BaseEntity>), typeof(EFRepository<BaseEntity>), Lifestyle.Scoped);
            _container.Register(typeof(IEFRepository<AppointmentMaster>), typeof(EFRepository<AppointmentMaster>), Lifestyle.Scoped);
            _container.Register(typeof(IEFRepository<TodaysPatientImage>), typeof(EFRepository<TodaysPatientImage>), Lifestyle.Scoped);
            _container.Register(typeof(IEFRepository<TodaysPatientList>), typeof(EFRepository<TodaysPatientList>), Lifestyle.Scoped);
            _container.Register(typeof(IEFRepository<PreConsultation>), typeof(EFRepository<PreConsultation>), Lifestyle.Scoped);
            RegisterAllData(services);
            RegisterAllProcess(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSimpleInjector(_container);
            _container.Register<IServiceProvider>(() => _container, Lifestyle.Singleton);
            
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
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
            _container.Verify();
        }

        private void RegisterAllData(IServiceCollection services)
        {
            _container.Register<IDataFactory, DataFactory>(Lifestyle.Singleton);
            _container.Register<IAppointmentMasterDAL, AppointmentMasterDAL>(Lifestyle.Scoped);
            _container.Register<ITodaysPatientImageDAL, TodaysPatientImageDAL>(Lifestyle.Scoped);
            _container.Register<ITodaysPatientListDAL, TodaysPatientListDAL>(Lifestyle.Scoped);
            _container.Register<IPreconsulationDAL, PreConsultationDAL>(Lifestyle.Scoped);
        }

        private void RegisterAllProcess(IServiceCollection services)
        {
            _container.Register<IUserProcess, UserProcess>(Lifestyle.Scoped);
        }
    }
}
