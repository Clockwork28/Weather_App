
# Weather App

This is a simple C# console application that fetches weather data from OpenWeatherMap API and stores it in a SQLite database. The application allows users to view weather data, including city name, temperature, and weather description, and stores historical weather data in a local database.

## Features:
- Fetches real-time weather data from OpenWeatherMap API.
- Displays city name, temperature, and weather description.
- Saves weather data into an SQLite database.
- Provides a historical view of previously fetched weather data.

## Technologies Used:
- **C#** - Programming language.
- **.NET** - Framework for the application.
- **SQLite** - For local database storage.
- **OpenWeatherMap API** - For fetching weather data.
- **JsonSerializer** - For deserializing the weather data JSON response.

## Setup Instructions

### 1. Clone the Repository:
Clone this repository to your local machine using Git:
```bash
git clone https://github.com/your-username/weather-app.git
```

### 2. Add Your API Key:
To connect to OpenWeatherMap, you need an **API Key**. 

- Copy the `appSettings.template.json` file to `appSettings.json`.
- Open `appSettings.json` and replace the `"your-api-key-here"` placeholder with your own OpenWeatherMap API key.

#### Example of `appSettings.json`:
```json
{
  "ApiKey": "your-api-key-here"
}
```

### 3. Build and Run the Application:
1. Open the project in **Visual Studio** or your preferred C# IDE.
2. Build and run the project.

The application will display weather information for a city you specify and save it in an SQLite database.

### 4. Important Notes:
- The `appSettings.json` file must be located in the root folder of the project (not in the `bin` directory). Make sure to configure your IDE to copy this file to the output directory.
- The database is stored locally in the project directory (`weather.db`), and you can interact with it using SQL queries to view the stored weather history.

### 5. .gitignore:
- **appSettings.json** is excluded from version control for security purposes. Do not commit your API key.
- You can check and modify `.gitignore` if needed, but the default setup excludes the sensitive `appSettings.json` file.
