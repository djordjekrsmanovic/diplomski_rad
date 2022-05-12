using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MicrosoftGraphSecurityApi.Authentication;
using MicrosoftGraphSecurityApi.Dto;
using MicrosoftGraphSecurityApi.Mapper;
using MicrosoftGraphSecurityApi.Model;
using MicrosoftGraphSecurityApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftGraphSecurityApi
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

            services.AddControllers();
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MicrosoftGraphSecurityApi", Version = "v1" });
            });

            services.AddScoped<IAuthenticationProvider, AuthenticationWithAppPermission>();
            services.AddScoped<IModelMapper<Alert,AlertTableDto>, AlertToAlertTableDtoMapper>();
            services.AddScoped<IGraphRequestService, GraphRequestService>();
            services.AddScoped<IAlertService, AlertService>();
            services.AddScoped<IModelMapper<Microsoft.Graph.SecurityVendorInformation, VendorInfromationDto>, SecurityVendorInformationToDtoMapper>();
            services.AddScoped<IModelMapper<Alert, AlertDetailsDto>, AlertToAlertDetailsDtoMapper>();
            services.AddScoped<IModelMapper<AlertFilter, AlertFilterDto>, FilterDtoToFilterModel>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MicrosoftGraphSecurityApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors("MyPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
