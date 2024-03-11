using System.Text.Json.Serialization;
using FootballData.Models.Enums;
using FootballData.Models.ModelHelpers;

namespace FootballData.Models;

public class Weather
{
    [JsonPropertyName("humidity")]
    [JsonConverter(typeof(IntConverter))]
    public int Humidity { get; set; }

    [JsonPropertyName("temp_celsius")]
    [JsonConverter(typeof(IntConverter))]
    public int TempCelsius { get; set; }

    [JsonPropertyName("temp_farenheit")]
    [JsonConverter(typeof(IntConverter))]
    public int TempFarenheit { get; set; }

    [JsonPropertyName("wind_speed")]
    [JsonConverter(typeof(IntConverter))]
    public int WindSpeed { get; set; }

    [JsonPropertyName("description")] public WeatherDescription WeatherDescription { get; set; }
}
