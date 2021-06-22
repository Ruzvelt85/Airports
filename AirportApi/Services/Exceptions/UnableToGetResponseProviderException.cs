using System;

namespace AirportApi.Services.Exceptions
{
    public class UnableToGetResponseProviderException : Exception
    {
        public UnableToGetResponseProviderException(Exception innerEx)
            : base("Unable to get response from provider. Unspecified error", innerEx)
        {
        }
    }
}
