using System.Text.Json;
using System.Text.Json.Serialization;

namespace FootballData.Data.Enums;

public enum Status
{
    Completed,
    NotStarted,
    Ongoing,
    Postponed,
};

internal class StatusConverter : JsonConverter<Status>
{
    public override bool CanConvert(Type t) => t == typeof(Status);

    public override Status Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value == "completed")
        {
            return Status.Completed;
        }

        throw new Exception("Cannot unmarshal type Status");
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        if (value == Status.Completed)
        {
            JsonSerializer.Serialize(writer, "completed", options);
            return;
        }

        throw new Exception("Cannot marshal type Status");
    }

    public static readonly StatusConverter Singleton = new StatusConverter();
}