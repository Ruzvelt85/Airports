using System.Threading.Tasks;

namespace AirportApi.Services
{
    public interface IAirportProvider
    {
        /// <summary>
        /// The method gets the distance in miles between two airports
        /// </summary>
        /// <param name="code1">IATA code of the first airport</param>
        /// <param name="code2">IATA code of the second airport</param>
        /// <returns></returns>
        Task<double> GetDistanceBetweenAirportsInMiles(string code1, string code2);
    }
}
