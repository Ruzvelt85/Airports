using System;

namespace AirportApi.Services.Exceptions
{
    public class ProviderReturnedErrorException : Exception
    {
        public string ErrorText { get; set; }

        public ProviderReturnedErrorException(Exception innerException)
            : base("Provider returned the error", innerException)
        {
        }

        public ProviderReturnedErrorException(string errorText, Exception innerException)
            : base("Provider returned the error", innerException)
        {
            ErrorText = errorText;
        }
    }
}
