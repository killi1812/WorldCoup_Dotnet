using System.Text.Json;
using System.Text.Json.Serialization;

namespace FootballData.Models.Enums;

public enum Tactics
{
    The3421,
    The343,
    The352,
    The4231,
    The4321,
    The433,
    The442,
    The451,
    The532,
    The541
};

internal class TacticsConverter : JsonConverter<Tactics>
{
    public override bool CanConvert(Type t) => t == typeof(Tactics);

    public override Tactics Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        switch (value)
        {
            case "3-4-2-1":
                return Tactics.The3421;
            case "3-4-3":
                return Tactics.The343;
            case "3-5-2":
                return Tactics.The352;
            case "4-2-3-1":
                return Tactics.The4231;
            case "4-3-2-1":
                return Tactics.The4321;
            case "4-3-3":
                return Tactics.The433;
            case "4-4-2":
                return Tactics.The442;
            case "4-5-1":
                return Tactics.The451;
            case "5-3-2":
                return Tactics.The532;
            case "5-4-1":
                return Tactics.The541;
        }

        throw new Exception("Cannot unmarshal type Tactics");
    }

    public override void Write(Utf8JsonWriter writer, Tactics value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case Tactics.The3421:
                JsonSerializer.Serialize(writer, "3-4-2-1", options);
                return;
            case Tactics.The343:
                JsonSerializer.Serialize(writer, "3-4-3", options);
                return;
            case Tactics.The352:
                JsonSerializer.Serialize(writer, "3-5-2", options);
                return;
            case Tactics.The4231:
                JsonSerializer.Serialize(writer, "4-2-3-1", options);
                return;
            case Tactics.The4321:
                JsonSerializer.Serialize(writer, "4-3-2-1", options);
                return;
            case Tactics.The433:
                JsonSerializer.Serialize(writer, "4-3-3", options);
                return;
            case Tactics.The442:
                JsonSerializer.Serialize(writer, "4-4-2", options);
                return;
            case Tactics.The451:
                JsonSerializer.Serialize(writer, "4-5-1", options);
                return;
            case Tactics.The532:
                JsonSerializer.Serialize(writer, "5-3-2", options);
                return;
            case Tactics.The541:
                JsonSerializer.Serialize(writer, "5-4-1", options);
                return;
        }

        throw new Exception("Cannot marshal type Tactics");
    }

    public static readonly TacticsConverter Singleton = new TacticsConverter();
}