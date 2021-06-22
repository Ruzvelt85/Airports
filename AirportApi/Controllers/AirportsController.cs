using System;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AirportApi.ErrorHandling;
using AirportApi.Services;
using AirportApi.Services.Exceptions;

namespace AirportApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportProvider _airportProvider;

        public AirportsController(IAirportProvider airportProvider)
        {
            _airportProvider = airportProvider;
        }

        [HttpGet("getdistanceinmiles")]
        public async Task<ActionResult<int>> GetDistanceInMiles(string airportCode1, string airportCode2)
        {
            if (!IsAirportCodeValid(airportCode1) || !IsAirportCodeValid(airportCode2) || airportCode1 == airportCode2)
                return BadRequest();

            try
            {
                var distance = await _airportProvider.GetDistanceBetweenAirportsInMiles(airportCode1, airportCode2);

                return Ok($"{distance:F4}");
            }
            catch (ProviderReturnedErrorException ex)
            {
                return new InternalServerErrorContentResult(
                    $"The third-party provider returned the error: {ex.ErrorText}");
            }
            catch (UnableToGetResponseProviderException ex)
            {
                return new InternalServerErrorContentResult(
                    $"The error occured: API couldn't get response from the third-party provider. Exception: {ex.InnerException}");
            }
            catch (Exception ex)
            {
                return new InternalServerErrorContentResult(
                    $"The unspecified error occured. Exception: {ex.InnerException}");
            }
        }
        
        /// <summary>
        /// Checks if IATA airport code is valid
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private bool IsAirportCodeValid(string code)
        {
            return !string.IsNullOrEmpty(code) && Regex.IsMatch(code, "^[a-zA-Z]{3}$");
        }
    }
}
