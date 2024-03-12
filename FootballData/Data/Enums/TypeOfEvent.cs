using System.Text.Json;
using System.Text.Json.Serialization;

namespace FootballData.Data.Enums;

public enum TypeOfEvent
{
    Goal,
    GoalOwn,
    GoalPenalty,
    RedCard,
    SubstitutionIn,
    SubstitutionOut,
    YellowCard,
    YellowCardSecond
};

internal class TypeOfEventConverter : JsonConverter<TypeOfEvent>
{
    public override bool CanConvert(Type t) => t == typeof(TypeOfEvent);

    public override TypeOfEvent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        switch (value)
        {
            case "goal":
                return TypeOfEvent.Goal;
            case "goal-own":
                return TypeOfEvent.GoalOwn;
            case "goal-penalty":
                return TypeOfEvent.GoalPenalty;
            case "red-card":
                return TypeOfEvent.RedCard;
            case "substitution-in":
                return TypeOfEvent.SubstitutionIn;
            case "substitution-out":
                return TypeOfEvent.SubstitutionOut;
            case "yellow-card":
                return TypeOfEvent.YellowCard;
            case "yellow-card-second":
                return TypeOfEvent.YellowCardSecond;
        }
        throw new Exception("Cannot unmarshal type TypeOfEvent");
    }

    public override void Write(Utf8JsonWriter writer, TypeOfEvent value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case TypeOfEvent.Goal:
                JsonSerializer.Serialize(writer, "goal", options);
                return;
            case TypeOfEvent.GoalOwn:
                JsonSerializer.Serialize(writer, "goal-own", options);
                return;
            case TypeOfEvent.GoalPenalty:
                JsonSerializer.Serialize(writer, "goal-penalty", options);
                return;
            case TypeOfEvent.RedCard:
                JsonSerializer.Serialize(writer, "red-card", options);
                return;
            case TypeOfEvent.SubstitutionIn:
                JsonSerializer.Serialize(writer, "substitution-in", options);
                return;
            case TypeOfEvent.SubstitutionOut:
                JsonSerializer.Serialize(writer, "substitution-out", options);
                return;
            case TypeOfEvent.YellowCard:
                JsonSerializer.Serialize(writer, "yellow-card", options);
                return;
            case TypeOfEvent.YellowCardSecond:
                JsonSerializer.Serialize(writer, "yellow-card-second", options);
                return;
        }
        throw new Exception("Cannot marshal type TypeOfEvent");
    }

    public static readonly TypeOfEventConverter Singleton = new TypeOfEventConverter();
}