using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPIStarterTemplate.Core;
using WebAPIStarterTemplate.Core.Services;
using WebAPIStarterTemplate.Data;
using WebAPIStarterTemplate.Services.Services;
using Newtonsoft.Json;
using AutoMapper;

namespace WebAPIStarterTemplate.API
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
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                ); ;



            //Sqlite Configuration
            services.AddDbContext<WebAPIStarterTemplateDbContext>(options => options.UseSqlite("Data Source=./data.db", x => x.MigrationsAssembly("WebAPIStarterTemplate.Data")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IProjectTaskService, ProjectTaskService>();
            services.AddTransient<IProjectService, ProjectService>();

            //Swagger Documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                  "v1",
                  new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Documentation", Description = "API Documentation" });
            });

            //AutoMapper
            services.AddAutoMapper(typeof(Startup));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Doc");
            }
            );
        }
    }
}
