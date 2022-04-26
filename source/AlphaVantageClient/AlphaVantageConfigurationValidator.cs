using Microsoft.Extensions.Options;

namespace AlphaVantageClient
{
    internal class AlphaVantageConfigurationValidator : IValidateOptions<AlphaVantageConfiguration>
    {
        public ValidateOptionsResult Validate(string name, AlphaVantageConfiguration options)
        {
            if (string.IsNullOrWhiteSpace(options.ApiKey)) return ValidateOptionsResult.Fail($"{nameof(options.ApiKey)} cannot be empty.");
            if (string.IsNullOrWhiteSpace(options.BaseUrl)) return ValidateOptionsResult.Fail($"{nameof(options.BaseUrl)} cannot be empty.");
            return ValidateOptionsResult.Success;
        }
    }
}