using Ariana.ECommerce.Catalog.Api.Mappings;
using Ariana.ECommerce.Catalog.Api.Seed;
using Ariana.ECommerce.Catalog.Application;
using Ariana.ECommerce.Catalog.Domain.Repository;
using Ariana.ECommerce.Catalog.Repository;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

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
            
            services.AddDbContext<CatalogContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CatalogDb")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICatalogRepository, CatalogRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Catalog Api", Version = "v1" });
            });

            Mapper.Initialize(cfg => cfg.AddProfile<CatalogMappingProfile>());

            services.AddAutoMapper();
            services.AddMediatR(typeof(Init));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
