using System.Text.Json;
using System.Text.Json.Serialization;

namespace FootballData.Data.Enums;

public enum WeatherDescription
{
    ClearNight,
    Cloudy,
    PartlyCloudy,
    PartlyCloudyNight,
    Sunny
};
internal class WeatherDescriptionConverter : JsonConverter<WeatherDescription>
{
    public override bool CanConvert(Type t) => t == typeof(WeatherDescription);

    public override WeatherDescription Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        var value = reader.GetString();
        switch (value)
        {
            case "Clear Night":
                return WeatherDescription.ClearNight;
            case "Cloudy":
                return WeatherDescription.Cloudy;
            case "Partly Cloudy":
                return WeatherDescription.PartlyCloudy;
            case "Partly Cloudy Night":
                return WeatherDescription.PartlyCloudyNight;
            case "Sunny":
                return WeatherDescription.Sunny;
            default:
                return WeatherDescription.Sunny;
        }

        throw new Exception("Cannot unmarshal type Description");
    }

    public override void Write(Utf8JsonWriter writer, WeatherDescription value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case WeatherDescription.ClearNight:
                JsonSerializer.Serialize(writer, "Clear Night", options);
                return;
            case WeatherDescription.Cloudy:
                JsonSerializer.Serialize(writer, "Cloudy", options);
                return;
            case WeatherDescription.PartlyCloudy:
                JsonSerializer.Serialize(writer, "Partly Cloudy", options);
                return;
            case WeatherDescription.PartlyCloudyNight:
                JsonSerializer.Serialize(writer, "Partly Cloudy Night", options);
                return;
            case WeatherDescription.Sunny:
                JsonSerializer.Serialize(writer, "Sunny", options);
                return;
        }

        throw new Exception("Cannot marshal type Description");
    }

    public static readonly WeatherDescriptionConverter Singleton = new WeatherDescriptionConverter();
}
