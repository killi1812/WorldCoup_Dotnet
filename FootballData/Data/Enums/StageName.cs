using System.Text.Json;
using System.Text.Json.Serialization;

namespace FootballData.Data.Enums;

public enum StageName
{
    Final,
    FirstStage,
    PlayOffForThirdPlace,
    QuarterFinals,
    RoundOf16,
    SemiFinals
};

internal class StageNameConverter : JsonConverter<StageName>
{
    public override bool CanConvert(Type t) => t == typeof(StageName);

    public override StageName Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        switch (value)
        {
            case "Final":
                return StageName.Final;
            case "First stage":
                return StageName.FirstStage;
            case "Play-off for third place":
                return StageName.PlayOffForThirdPlace;
            case "Quarter-finals":
                return StageName.QuarterFinals;
            case "Round of 16":
                return StageName.RoundOf16;
            case "Semi-finals":
                return StageName.SemiFinals;
        }

        throw new Exception("Cannot unmarshal type StageName");
    }

    public override void Write(Utf8JsonWriter writer, StageName value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case StageName.Final:
                JsonSerializer.Serialize(writer, "Final", options);
                return;
            case StageName.FirstStage:
                JsonSerializer.Serialize(writer, "First stage", options);
                return;
            case StageName.PlayOffForThirdPlace:
                JsonSerializer.Serialize(writer, "Play-off for third place", options);
                return;
            case StageName.QuarterFinals:
                JsonSerializer.Serialize(writer, "Quarter-finals", options);
                return;
            case StageName.RoundOf16:
                JsonSerializer.Serialize(writer, "Round of 16", options);
                return;
            case StageName.SemiFinals:
                JsonSerializer.Serialize(writer, "Semi-finals", options);
                return;
        }

        throw new Exception("Cannot marshal type StageName");
    }

    public static readonly StageNameConverter Singleton = new StageNameConverter();
}