using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Clalit.Insulin
{
    public class Startup
    {
        private readonly ILogger<Startup> _logger;

        public Startup(IConfiguration configuration,
            ILogger<Startup> logger)
        {
            Configuration = configuration;
            this._logger = logger;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                _logger.LogInformation("Enter ConfigureServices");
                services.AddControllers()
                .AddNewtonsoftJson();

                services.AddSwaggerGen();

                services.AddMvc();

                services.AddAuthentication(IISDefaults.AuthenticationScheme);

                services.AddControllers().AddJsonOptions(option =>
                    option.JsonSerializerOptions
                          .PropertyNamingPolicy = JsonNamingPolicy.CamelCase);
            }
            catch (System.Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            try
            {
                _logger.LogInformation("Enter Configure");
              

                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseHsts();
                }

                app.UseHttpsRedirection();

                app.UseRouting();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

                app.UseSwagger();
                app.UseSwaggerUI();

                app.UseAuthentication();
                

            }
            catch (System.Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
            }
        }
    }
}
