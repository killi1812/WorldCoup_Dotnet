using System.Text.Json;
using System.Text.Json.Serialization;

namespace FootballData.Data.Enums;

public enum Time
{
    FullTime
};

internal class TimeConverter : JsonConverter<Time>
{
    public override bool CanConvert(Type t) => t == typeof(Time);

    public override Time Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value == "full-time")
        {
            return Time.FullTime;
        }

        throw new Exception("Cannot unmarshal type Time");
    }

    public override void Write(Utf8JsonWriter writer, Time value, JsonSerializerOptions options)
    {
        if (value == Time.FullTime)
        {
            JsonSerializer.Serialize(writer, "full-time", options);
            return;
        }

        throw new Exception("Cannot marshal type Time");
    }

    public static readonly TimeConverter Singleton = new TimeConverter();
}