namespace GraphTheorySamples
{
    /// <summary>
    /// Represents a route between cities on SwellAir
    /// </summary>
    public class Route
    {
        public Route(int startingCityId, int endingCityId)
        {
            StartingCityId = startingCityId;
            EndingCityId = endingCityId;
        }

        public int StartingCityId { get; set; }
        public int EndingCityId { get; set; }
    }
}
