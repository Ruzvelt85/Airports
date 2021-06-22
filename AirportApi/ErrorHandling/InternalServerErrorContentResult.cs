using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirportApi.ErrorHandling
{
    public class InternalServerErrorContentResult : ContentResult
    {
        public InternalServerErrorContentResult(string contentText)
        {
            Content = contentText;
            StatusCode = StatusCodes.Status500InternalServerError;
        }

        public InternalServerErrorContentResult() : this(null)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
