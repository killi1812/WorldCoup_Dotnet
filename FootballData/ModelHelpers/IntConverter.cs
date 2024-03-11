using System.Text.Json;
using System.Text.Json.Serialization;

namespace FootballData.Models.ModelHelpers;

internal class IntConverter : JsonConverter<int>
{
    public override bool CanConvert(Type t) => t == typeof(int);

    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        int l;
        if (int.TryParse(value, out l))
        {
            return l;
        }

        throw new Exception("Cannot unmarshal type int");
    }

    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.ToString(), options);
        return;
    }

    public static readonly IntConverter Singleton = new IntConverter();
}