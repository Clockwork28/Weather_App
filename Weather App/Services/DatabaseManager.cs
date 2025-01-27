using Microsoft.Data.Sqlite;
namespace Weather_App.Services
{
    internal class DatabaseManager
    {
        public string connectionString = "Data Source=weather.db";
        public void InitializeDatabase()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"CREATE TABLE IF NOT EXISTS Weather (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        City TEXT NOT NULL,
                                        Temperature REAL NOT NULL,
                                        Description TEXT NOT NULL,
                                        Date TEXT NOT NULL)";
                command.ExecuteNonQuery();
            }
        }
        public void InsertData(string city, double temperature, string description)
        {
            var date = DateTime.Today.ToShortDateString();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Weather (City,Temperature,Description,Date)
                                        VALUES (@city,@temperature,@description,@date)";
                command.Parameters.AddRange(new[]
                {
                    new SqliteParameter("@city", city),
                    new SqliteParameter("@temperature", temperature),
                    new SqliteParameter("@description", description),
                    new SqliteParameter("@date", date)
                });
                command.ExecuteNonQuery();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nWeather data sucessfully recorded.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void ViewHistory()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM Weather";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string city = reader.GetString(1);
                        double temperature = reader.GetDouble(2);
                        string description = reader.GetString(3);
                        string date = reader.GetString(4);

                        Console.WriteLine($"\n{id}.\nCity: {city},\nTemperature: {temperature}°C,\nDescription: {description},\nDate: {date}");
                    }
                    Console.WriteLine();
                }
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
