using Microsoft.Extensions.Configuration;

namespace NetCore.Template.Configuration
{
    public class ConfigurationAccessor
    {
        public const string AzureAdConfigurationKey = "AzureAd";
        public const string ApiInformationKey = "ApiInformation";
        public const string ConnectionStringKey = "ConnectionString";
        public const string DetailedErrorsKey = "DetailedErrors";

        public ApiInformation ApiInformation => configuration.GetSection(ApiInformationKey)
            .Get<ApiInformation>();

        public string ConnectionString => configuration.GetValue<string>(ConnectionStringKey);

        public bool DetailedErrors => configuration.GetValue<bool>(DetailedErrorsKey);

        public AzureAdConfiguration AzureAdConfiguration => configuration.GetSection(AzureAdConfigurationKey)
            .Get<AzureAdConfiguration>();

        private readonly IConfiguration configuration;

        public ConfigurationAccessor(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Bind(string configurationKey, object instance)
        {
            configuration.Bind(configurationKey, instance);
        }
    }
}
