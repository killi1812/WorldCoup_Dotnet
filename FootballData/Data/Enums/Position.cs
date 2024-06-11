using System.Text.Json;
using System.Text.Json.Serialization;

namespace FootballData.Data.Enums;

public enum Position
{
    Goalie = 0,
    Defender = 1,
    Midfield = 2,
    Forward = 3
};

internal class PositionConverter : JsonConverter<Position>
{
    public override bool CanConvert(Type t) => t == typeof(Position);

    public override Position Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        switch (value)
        {
            case "Defender":
                return Position.Defender;
            case "Forward":
                return Position.Forward;
            case "Goalie":
                return Position.Goalie;
            case "Midfield":
                return Position.Midfield;
        }

        throw new Exception("Cannot unmarshal type Position");
    }

    public override void Write(Utf8JsonWriter writer, Position value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case Position.Defender:
                JsonSerializer.Serialize(writer, "Defender", options);
                return;
            case Position.Forward:
                JsonSerializer.Serialize(writer, "Forward", options);
                return;
            case Position.Goalie:
                JsonSerializer.Serialize(writer, "Goalie", options);
                return;
            case Position.Midfield:
                JsonSerializer.Serialize(writer, "Midfield", options);
                return;
        }

        throw new Exception("Cannot marshal type Position");
    }

    public static readonly PositionConverter Singleton = new PositionConverter();
}