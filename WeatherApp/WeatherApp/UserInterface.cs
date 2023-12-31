﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class UserInterface
    {
        // A method to display a title at the beginning of the program
        public static void DisplayTitle()
        {
            Console.WriteLine("Welcome to the Weather App!");
            Console.WriteLine("This app will show you the current weather information for any US zip code.");
            Console.WriteLine();
        }

        // A method to ask the user to enter a zip code or press Q to quit
        public static string GetUserInput()
        {
            Console.WriteLine("Please enter a zip code or press Q to quit:");
            return Console.ReadLine();
        }

        // A method to display the weather information for a given zip code
        public static void DisplayWeather(string zip, dynamic data)
        {
            // Check if the data object is not null
            if (data != null)
            {
                // Get the weather information from the data object
                string city = data.name;
                string currentTempF = data.main.temp;
                string currentWeather = data.weather[0].main;

                // Display the weather information in a formatted way
                Console.WriteLine();
                Console.WriteLine($"The current weather in {city} ({zip}) is:");
                Console.WriteLine($"Temperature: {currentTempF} F");
                Console.WriteLine($"Condition: {currentWeather}");
                Console.WriteLine();
            }
            else
            {
                // Display an error message if the data object is null
                Console.WriteLine();
                Console.WriteLine("Sorry, we could not get the weather information for that zip code.");
                Console.WriteLine();
            }
        }

        // A method to display an error message for invalid input
        public static void DisplayInvalidInput()
        {
            Console.WriteLine();
            Console.WriteLine("Invalid input. Please enter a valid 5-digit zip code.");
            Console.WriteLine();
        }

        // A method to display an error message for failed request
        public static void DisplayFailedRequest(HttpResponseMessage response)
        {
            // Display an error message with the status code and reason phrase
            Console.WriteLine();
            Console.WriteLine($"The request failed with status code {response.StatusCode} and reason {response.ReasonPhrase}.");
            Console.WriteLine();
        }

        // A method to thank the user for using the app and exit
        public static void ExitApp()
        {
            Console.WriteLine("Thank you for using the Weather App. Goodbye!");
            Environment.Exit(0);
        }
    }
}
