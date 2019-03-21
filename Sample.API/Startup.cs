using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Domain.Abstract;
using Sample.Domain.Entities;
using Sample.Infrastructure;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using System.Collections.Generic;

namespace Sample.API
{
    /// <summary>
    /// ASP.NET Core configuration class for the Sample API.
    /// </summary>
    public class Startup
    {

        /// <summary>Initializes a new instance of the <see cref="Startup"/> class.</summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private Container container = new Container();

        /// <summary>Configures the services; called by ASP.NET Core.</summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            IntegrateSimpleInjector(services);
        }

        /// <summary>
        /// Integrate the SimpleInjector services.
        /// </summary>
        /// <see href="https://simpleinjector.readthedocs.io/">Simple Injector</see>
        /// <param name="services"></param>
        private void IntegrateSimpleInjector(IServiceCollection services)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(container));

            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(container));

            services.EnableSimpleInjectorCrossWiring(container);
            services.UseSimpleInjectorAspNetRequestScoping(container);
        }

        /// <summary>Configures the specified application; called by ASP.NET Core.</summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The environment.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            InitializeContainer(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors();  

            container.Verify();

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        /// <summary>
        /// Initializes the SimpleInjector container.
        /// </summary>
        /// <param name="app">The application.</param>
        private void InitializeContainer(IApplicationBuilder app)
        {
            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);

            container.Register<IMessageRepository, InMemoryMessageRepository>(Lifestyle.Scoped);
            container.Register<IEnumerable<Message>>(
                () => new List<Message>() { new Message("Hello World") }, 
                Lifestyle.Scoped);

            container.AutoCrossWireAspNetComponents(app);
        }
    }
}