using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestEase;

namespace Fumi24.EconomicClient
{
    public class EconomicClientFactory
    {
        public static IEconomicClient Execute(string appSecretToken, string agreementGrantToken, string url = "https://restapi.e-conomic.com")
        {
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };
            
            var client = new RestClient(url)
            {
                JsonSerializerSettings = settings,
            }.For<IEconomicClient>();

            client.AppSecretToken = appSecretToken;

            client.AgreementGrantToken = agreementGrantToken;

            return client;
        }
    }
}