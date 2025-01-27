namespace Weather_App.DataModel
{
    internal class WeatherData
    {  
        public class WeatherResponse
        {
            public required WeatherDetails Main { get; set; }
            public required List<Weather> Weather { get; set; }
            public required string Name { get; set; } 
        }
        public class WeatherDetails
        {
            public required double Temp { get; set; }
        }
        public class Weather
        {
            public required string Description { get; set; }
        }
    }
}
