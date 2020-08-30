using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NaturalPersonsHandbook.DAL.DbContextModel;
using AutoMapper;
using NaturalPersonsHandbook.Service.MappingProfiles;
using NaturalPersonsHandbook.DAL.Interfaces;
using NaturalPersonsHandbook.DAL.UnitOfWork;
using NaturalPersonsHandbook.Service.Services;
using FluentValidation.AspNetCore;
using NaturalPersonsHandbook.Service.Validators;
using NaturalPersonsHandbook.Service.Filters;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace NaturalPersonsHandbook.API
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

            services.AddLocalization();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<NaturalPersonService, NaturalPersonService>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });


            services.AddMvc(x =>
            {
                x.EnableEndpointRouting = false;
                x.Filters.Add<ValidationFilter>();
            })
                .AddFluentValidation(x =>
                {
                    x.RegisterValidatorsFromAssemblyContaining<NaturalPersonValidator>();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);




            services.AddDbContext<NaturalPersonDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("NaturalPersonDbConnectionString")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            CultureInfo[] supportedCultures = new[]
            {
                new CultureInfo("ka-GE"),
                new CultureInfo("en-US")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("ka-GE"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            
        }
    }
}
