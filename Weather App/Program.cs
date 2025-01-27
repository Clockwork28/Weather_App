using Weather_App.Services;

int choice = -1;
var weatherServices = new WeatherServices();
var dbManager = new DatabaseManager();
dbManager.InitializeDatabase();

Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.WriteLine("---- Weather App ----\n");
while (choice == -1)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("---- Menu ---- ");
    Console.WriteLine("\n1. Get weather for a city\n2. View history\n3. Exit");
    Console.Write("\nYour choice (1-3): ");
    try
    {
        choice = Convert.ToInt32(Console.ReadLine());
    }
    catch
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Please enter a valid number 1-3.");
        continue;
    }
    switch (choice)
    {
        case 1:
            Console.Clear();
            weatherServices.GetWeather();
            choice = -1;
            break;
        case 2:
            Console.Clear();
            dbManager.ViewHistory();
            choice = -1;
            break;
        case 3:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Exiting...");
            await Task.Delay(500);
            Environment.Exit(0);
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please enter a valid number 1-3.");
            choice = -1;
            break;
    }
}
