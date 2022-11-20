using Icon.Middleware.Config;
using Icon.Middleware.DataAccess;
using Icon.Middleware.DataAccess.Entities;
using Icon.Middleware.Middlewares;
using Icon.Middleware.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Icon.Middleware
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
            // Config for IdentityDbContext
            services.ConfigIdentityDbContext(Configuration);

            // Register services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<HttpContextAccessor>();

            services.AddControllers();

            // Config for swagger can use TokenKey
            services.ConfigSwaggerWithAuthentication(Configuration);

            // Connfig for Authentication
            services.ConfigAuthentication(Configuration);

            // Middleware 
            services.AddScoped<GlobalExceptionMiddleware>();
            services.AddScoped<InformationMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Icon.Middleware v1"));
            }

            app.UseMiddleware<GlobalExceptionMiddleware>();
            app.UseMiddleware<InformationMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
