using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using PDFFormFiller.Models;
using Microsoft.OpenApi.Models;
using System;

namespace PDFFormFiller
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //GetConnectionString() will return null when Integration Tests is the caller
            if (Configuration.GetConnectionString("PostgreSQL") is string connString)
                services.AddDbContext<DBContext>(options => options.UseNpgsql(connString));

            // Register the Swagger generator
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("PDFFormFiller",
                                   new OpenApiInfo
                                   {
                                       Title = "VanHackathon - Global Talent Stream Application Filler",
                                       Description = "PDF Filler API",
                                       Contact = new OpenApiContact
                                       {
                                           Name = "Igor Oliveira Campos",
                                           Email = "igorocampos@gmail.com",
                                           Url = new Uri("https://github.com/igorocampos/")
                                       }
                                   });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/PDFFormFiller/swagger.json", "PDF Filler API");
                options.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
