using WeatherApp;

// Display a title at the beginning of the program using the UserInterface class
UserInterface.DisplayTitle();

// Declare a variable to store the user input
string input;

// Declare a boolean variable to control the loop
bool repeat = true;

// Start a loop to ask the user for zip codes or exit
while (repeat)
{
    // Ask the user to enter a zip code or press Q to quit using the UserInterface class
    input = UserInterface.GetUserInput();

    // Check if the user input is Q or q
    if (input.ToUpper() == "Q")
    {
        // Set the repeat variable to false to end the loop
        repeat = false;

        // Thank the user for using the app and exit using the UserInterface class
        UserInterface.ExitApp();
    }
    else
    {
        // Try to parse the user input as an integer
        bool valid = int.TryParse(input, out int zip);

        // Check if the parsing was successful and the zip code is 5 digits long
        if (valid && input.Length == 5)
        {
            // Get the weather information for the user input using the WeatherAPI class
            dynamic data = WeatherAPI.GetWeatherByZip(input);

            // Display the weather information for the user input using the UserInterface class
            UserInterface.DisplayWeather(input, data);
        }
        else
        {
            // Display an error message for invalid input using the UserInterface class
            UserInterface.DisplayInvalidInput();
        }
    }
}
