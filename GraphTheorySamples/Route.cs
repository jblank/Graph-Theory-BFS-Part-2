namespace GraphTheorySamples
{
    /// <summary>
    /// Represents a route between cities on SwellAir
    /// </summary>
    public class Route
    {
        public Route(int startingCityId, int endingCityId, double distance)
        {
            StartingCityId = startingCityId;
            EndingCityId = endingCityId;
            Distance = distance;
        }

        public int StartingCityId { get; set; }
        public int EndingCityId { get; set; }
        public double Distance { get; set; }
    }
}
