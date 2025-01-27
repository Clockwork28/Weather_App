using System.Text.Json;
using Weather_App.DataModel;


namespace Weather_App.Services
{
    internal class WeatherServices
    {
        public void GetWeather()
        {
            var client = new HttpClient();
            var city = "";
            try
            {

                var appSettings = File.ReadAllText("appSettings.json");
                var apiKey = JsonSerializer.Deserialize<AppSettings>(appSettings)?.ApiKey;
                if (apiKey != null)
                {
                    client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
                    Console.Write("City: ");
                    city = Console.ReadLine();

                    var response = client.GetAsync($"weather?q={city}&appid={apiKey}&units=metric").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        var weatherResponse = JsonSerializer.Deserialize<WeatherData.WeatherResponse>(response.Content.ReadAsStringAsync().Result, options);
                        if (weatherResponse != null)
                        {
                            Console.Clear();
                            Console.WriteLine("City: " + weatherResponse.Name);
                            Console.WriteLine("Temperature: " + weatherResponse.Main.Temp);
                            Console.WriteLine("Weather description: " + weatherResponse.Weather.First().Description);

                            var dbManager = new DatabaseManager();
                            dbManager.InsertData(weatherResponse.Name, weatherResponse.Main.Temp, weatherResponse.Weather.First().Description);
                        }
                        else
                        {
                            Console.WriteLine("Error while deserializing JSON response.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: " + response.StatusCode);
                    }
                }
                else
                {
                    Console.WriteLine("Error: ApiKey is null.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading configuration file: {ex.Message}");
            }

            bool back = false;
            while (!back)
            {
                Console.WriteLine("\nPress any key to go back to the menu...");
                Console.ReadKey();
                Console.Clear();
                back = true;
            }
          
            
        }
    }
}
