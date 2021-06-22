using System;
using System.Threading.Tasks;
using AirportApi.Services.Exceptions;
using GeoCoordinatePortable;
using Microsoft.Extensions.Configuration;

namespace AirportApi.Services
{
    public class AirportProvider : IAirportProvider
    {
        private readonly AirportClient _airportClient;

        public AirportProvider(IConfiguration configuration)
        {
            string serviceConnection = configuration.GetValue<string>("ServiceUrl");

            _airportClient = new AirportClient(serviceConnection);
        }

        /// <summary>
        /// The method gets the distance in miles between two airports
        /// </summary>
        /// <param name="code1">IATA code of the first airport</param>
        /// <param name="code2">IATA code of the second airport</param>
        public async Task<double> GetDistanceBetweenAirportsInMiles(string code1, string code2)
        {
            var airportInfo1 = await _airportClient.GetAirportInfo(code1);

            var airportInfo2 = await _airportClient.GetAirportInfo(code2);

            if (airportInfo1?.Location?.Latitude == null || airportInfo1.Location?.Longitude == null ||
                airportInfo2?.Location?.Latitude == null || airportInfo2.Location?.Longitude == null)
            {
                throw new ProviderReturnedErrorException("Incomplete or incorrect data is returned by the provider", null);
            }

            var point1 = new GeoCoordinate(airportInfo1.Location.Latitude.Value, airportInfo1.Location.Longitude.Value);
            var point2 = new GeoCoordinate(airportInfo2.Location.Latitude.Value, airportInfo2.Location.Longitude.Value);

            return CalculationHelper.CalculateDistance(point1, point2);
        }
    }
}
