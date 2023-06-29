using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class WeatherAPI
    {
        // A method to get the weather information for a given zip code
        public static dynamic? GetWeatherByZip(string zip)
        {
            try
            {
                // Get the API key from the AppSettings class
                var apiKey = AppSettings.GetApiKey();

                // Create an HttpClient instance
                HttpClient client = new HttpClient();

                // Use the OpenWeather API endpoint with the zip code and API key as query parameters
                var weatherUrl = $"https://api.openweathermap.org/data/2.5/weather?zip={zip},us&appid={apiKey}";

                // Make an async GET request to the API endpoint and get the response
                HttpResponseMessage response = client.GetAsync(weatherUrl).Result;

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string content = response.Content.ReadAsStringAsync().Result;

                    // Parse the JSON content into a dynamic object
                    dynamic data = JsonConvert.DeserializeObject(content);

                    // Return the data object
                    return data;
                }
                else
                {
                    // Return null if the request failed
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during request or parsing process
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        // A method to get the response object from the API request
        public static string? GetResponse()
        {
            try
            {
                // Get the API key from the AppSettings class
                var apiKey = AppSettings.GetApiKey();

                // Create an HttpClient instance
                HttpClient client = new HttpClient();

                // Use the OpenWeather API endpoint with a dummy zip code and API key as query parameters
                var weatherUrl = $"https://api.openweathermap.org/data/2.5/weather?zip=28104,us&appid={apiKey}&units=metric";

                // Make an async GET request to the API endpoint and get the response
                string response = client.GetStringAsync(weatherUrl).Result;

                // Return the response object
                return response;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during request process
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }
}
