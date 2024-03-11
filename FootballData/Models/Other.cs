using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FootballData.Models;

public enum Status
{
    Completed,
    NotStarted,
    Ongoing,
    Postponed,
};

public enum Time
{
    FullTime
};

//TODO za kaj ce mi string parser 


//TODO ovo vjv netreba
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

//TODO nisam siguran je ovo nepotrebno
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

//TODO ovo vjv netreba

