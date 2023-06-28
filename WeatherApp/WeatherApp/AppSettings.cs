using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class AppSettings
    {
        // A method to get the apiKey value from the appsettings.json file
        public static string? GetApiKey()
        {
            try
            {
                // Read the appsettings.json file
                var apiKeyObj = File.ReadAllText("appsettings.json");

                // Parse the file into a JObject
                var apiKey = JObject.Parse(apiKeyObj);

                // Get the apiKey value from the JObject
                return apiKey.GetValue("apiKey").ToString();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during reading or parsing the file
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }
}
