using Newtonsoft.Json.Linq;
using System;
using static System.Net.WebRequestMethods;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            RonVSKanyeAPI.Convo();
            OpenWeatherMapAPI.GetTemp();
        }
    }
}
