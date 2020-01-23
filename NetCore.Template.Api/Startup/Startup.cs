using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.Template.Api.Configuration;
using NetCore.Template.Configuration;
using NetCore.Template.Infrastructure;

namespace NetCore.Template.Api
{
    public class Startup
    {
        private readonly ConfigurationAccessor configurationAccessor;

        public Startup(IConfiguration configuration)
        {
            configurationAccessor = new ConfigurationAccessor(configuration);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
                .AddAzureADBearer(options => configurationAccessor.Bind(ConfigurationAccessor.AzureAdConfigurationKey, options));

            services.AddSwagger(configurationAccessor);
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.InjectCustomDependencies();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.ConfigureSwagger(configurationAccessor);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller}/{action=index}/{id}");
            });
        }
    }
}