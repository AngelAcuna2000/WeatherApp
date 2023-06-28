using Xunit;
using WeatherApp;
using Newtonsoft.Json.Linq;
using System.Text;

namespace WeatherAppTests
{
    public class UserInterfaceTests
    {
        // A test method for the DisplayTitle method
        [Fact]
        public void TestDisplayTitle()
        {
            // Arrange: set up the expected output and a string builder to capture the console output
            string expectedOutput = "Welcome to the Weather App!\r\nThis app will show you the current weather information for any US zip code.\r\n\r\n";
            var sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));

            // Act: call the method under test
            UserInterface.DisplayTitle();

            // Assert: compare the console output with the expected output
            Assert.Equal(expectedOutput, sb.ToString());
        }

        // A test method for the DisplayWeather method
        [Fact]
        public void TestDisplayWeather()
        {
            // Arrange: set up the expected output, input, and data object and a string builder to capture the console output
            string expectedOutput = "\r\nThe current weather in Matthews (28105) is:\r\nTemperature: 80 F / 27 C\r\nCondition: Sunny\r\nWind: 10 mph N\r\n\r\n";
            string zip = "28105";
            dynamic data = new JObject();
            data.name = "Matthews";
            data.main.temp = "303.15";
            data.weather = new JArray();
            data.weather.Add(new JObject());
            data.weather[0].main = "Sunny";
            data.wind.speed = "10";
            data.wind.deg = "N";
            var sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));

            // Act: call the method under test
            UserInterface.DisplayWeather(zip, data);

            // Assert: compare the console output with the expected output
            Assert.Equal(expectedOutput, sb.ToString());
        }

        // A test method for the DisplayInvalidInput method
        [Fact]
        public void TestDisplayInvalidInput()
        {
            // Arrange: set up the expected output and a string builder to capture the console output
            string expectedOutput = "\r\nInvalid input. Please enter a valid 5-digit zip code.\r\n\r\n";
            var sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));

            // Act: call the method under test
            UserInterface.DisplayInvalidInput();

            // Assert: compare the console output with the expected output
            Assert.Equal(expectedOutput, sb.ToString());
        }

        // A test method for the DisplayFailedRequest method
        [Fact]
        public void TestDisplayFailedRequest()
        {
            // Arrange: set up the expected output, input, and response object and a string builder to capture the console output
            string expectedOutput = "\r\nThe request failed with status code NotFound and reason Not Found.\r\n\r\n";
            HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            response.ReasonPhrase = "Not Found";
            var sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));

            // Act: call the method under test
            UserInterface.DisplayFailedRequest(response);

            // Assert: compare the console output with the expected output
            Assert.Equal(expectedOutput, sb.ToString());
        }

        // A test method for the ExitApp method
        [Fact]
        public void TestExitApp()
        {
            // Arrange: set up the expected output and a string builder to capture the console output
            string expectedOutput = "Thank you for using the Weather App. Goodbye!\r\n";
            var sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));

            // Act: call the method under test and catch the exception that occurs when exiting
            try
            {
                UserInterface.ExitApp();
            }
            catch (Exception ex)
            {
                // Do nothing, just catch the exception to continue testing
            }

            // Assert: compare the console output with the expected output
            Assert.Equal(expectedOutput, sb.ToString());
        }
    }
}
