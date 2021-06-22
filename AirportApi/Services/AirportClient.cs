using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AirportApi.Services.Dto;
using AirportApi.Services.Exceptions;
using Newtonsoft.Json;

namespace AirportApi.Services
{
    public class AirportClient
    {
        private readonly string _serviceUrl;

        public AirportClient(string url)
        {
            _serviceUrl = url;
        }

        /// <summary>
        /// The method gets information about the airport with specified IATA code
        /// </summary>
        /// <param name="airportCode">Airport IATA code</param>
        public async Task<AirportInfoResponse> GetAirportInfo(string airportCode)
        {
            return await SendGetRequest<AirportInfoResponse>(airportCode);
        }

        /// <summary>
        /// The method sends GET request to third-party web-client
        /// </summary>
        /// <param name="airportCode">Airport IATA code</param>
        private async Task<T> SendGetRequest<T>(string airportCode) where T : class
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var requestUrl = $"{_serviceUrl}/{airportCode}";
                    var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                    
                    var response = await httpClient.SendAsync(requestMessage);
                    var stringResult = await response.Content.ReadAsStringAsync();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return JsonConvert.DeserializeObject<T>(stringResult);
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new ProviderReturnedErrorException("The airport with specified IATA code is not found", null);
                    }

                    throw new ProviderReturnedErrorException("UnspecifiedError", null);
                }
            }
            catch (WebException ex)
            {
                throw new UnableToGetResponseProviderException(ex);
            }
        }
    }
}
