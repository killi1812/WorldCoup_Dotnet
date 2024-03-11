using System.Text.Json.Serialization;
using FootballData.Models.Enums;

namespace FootballData.Models;

public class Weather
{
    [JsonPropertyName("humidity")]
    [JsonConverter(typeof(ParseStringConverter))]
    public int Humidity { get; set; }

    [JsonPropertyName("temp_celsius")]
    [JsonConverter(typeof(ParseStringConverter))]
    public int TempCelsius { get; set; }

    [JsonPropertyName("temp_farenheit")]
    [JsonConverter(typeof(ParseStringConverter))]
    public int TempFarenheit { get; set; }

    [JsonPropertyName("wind_speed")]
    [JsonConverter(typeof(ParseStringConverter))]
    public int WindSpeed { get; set; }

    [JsonPropertyName("description")] public WeatherDescription WeatherDescription { get; set; }
}
