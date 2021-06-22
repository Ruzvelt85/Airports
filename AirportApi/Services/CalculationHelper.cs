using GeoCoordinatePortable;

namespace AirportApi.Services
{
    public static class CalculationHelper
    {
        /// <summary>
        /// Coefficient of conversion of meters to miles
        /// </summary>
        private const double MetersToMileCoefficient = 0.00062;

        /// <summary>
        /// The method calculates distance between two coordinates in miles
        /// </summary>
        /// <param name="point1">Coordinate 1</param>
        /// <param name="point2">Coordinate 2</param>
        /// <returns></returns>
        public static double CalculateDistance(GeoCoordinate point1, GeoCoordinate point2)
        {
            var distanceInMeters = point1.GetDistanceTo(point2);

            return distanceInMeters * MetersToMileCoefficient;
        }
    }
}
