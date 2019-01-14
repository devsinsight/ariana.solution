using Ariana.ECommerce.Catalog.Api.Mappings;
using Ariana.ECommerce.Catalog.Api.Seed;
using Ariana.ECommerce.Catalog.Application;
using Ariana.ECommerce.Catalog.Domain.Repository;
using Ariana.ECommerce.Catalog.Repository;
using Ariana.ECommerce.EventBus.EventBus;
using Ariana.ECommerce.EventBus.EventBus.Abstractions;
using Ariana.ECommerce.EventBus.RabbitMQ;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace Ariana.ECommerce.Catalog.Api
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

            services.AddDbContext<CatalogContext>(options =>
                options.UseSqlServer(
                    Configuration["ConnectionString"],
                    sqlServerOptions => sqlServerOptions.CommandTimeout(30))
            );
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICatalogRepository, CatalogRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.Configure<CatalogSettings>(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Catalog Api", Version = "v1" });
            });

            Mapper.Initialize(cfg => cfg.AddProfile<CatalogMappingProfile>());

            services.AddAutoMapper();
            services.AddMediatR(typeof(Init));

            RegisterEventBus(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        private void RegisterEventBus(IServiceCollection services)
        {

            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();

                var factory = new ConnectionFactory()
                {
                    HostName = Configuration["EventBusConnection"]
                };

                if (!string.IsNullOrEmpty(Configuration["EventBusUserName"]))
                {
                    factory.UserName = Configuration["EventBusUserName"];
                }

                if (!string.IsNullOrEmpty(Configuration["EventBusPassword"]))
                {
                    factory.Password = Configuration["EventBusPassword"];
                }

                if (!string.IsNullOrEmpty(Configuration["EventBusPort"]))
                {
                    factory.Port = Convert.ToInt32(Configuration["EventBusPort"]);
                }

                factory.VirtualHost = "/";
                factory.AutomaticRecoveryEnabled = true;

                var retryCount = 10;
                if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
                {
                    retryCount = int.Parse(Configuration["EventBusRetryCount"]);
                }

                return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);

            });

            var subscriptionClientName = Configuration["SubscriptionClientName"];

            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                var retryCount = 5;
                if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
                {
                    retryCount = int.Parse(Configuration["EventBusRetryCount"]);
                }

                return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, sp, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
            });

            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

            //services.AddTransient<ProductPriceChangedIntegrationEventHandler>();
            //services.AddTransient<OrderStartedIntegrationEventHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                CatalogContextSeed.SeedAsync(app).Wait();
                app.UseDeveloperExceptionPage();
                
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog Api v1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
