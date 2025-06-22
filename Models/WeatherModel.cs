using System.Collections.Generic;

namespace weatherapp.Models
{
    public class WeatherModel
    {
        public Main? Main { get; set; }
        public List<Weather>? Weather { get; set; }
        public Wind? Wind { get; set; }
        public Clouds? Clouds { get; set; }
        public Sys? Sys { get; set; }
        public string? Name { get; set; }
    }



    public class Main
    {
        public float Temp { get; set; }
        public float Feels_Like { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
    }
    /*public class WeatherDescription
    {
        public string Description { get; set; } = "";
        public string Icon { get; set; } = "";
    }*/


    public class Weather
    {
        public string? Description { get; set; }
        public string? Icon { get; set; }
    }

    public class Wind
    {
        public float Speed { get; set; }
    }

    public class Clouds
    {
        public int All { get; set; }
    }

    public class Sys
    {
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }
}
