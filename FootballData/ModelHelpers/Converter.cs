using System.Text.Json;
using FootballData.Models.Enums;

namespace FootballData.Models.ModelHelpers;

internal static class Converter
{
    public static readonly JsonSerializerOptions Settings = new(JsonSerializerDefaults.General)
    {
        Converters =
        {
            TypeOfEventConverter.Singleton,
            PositionConverter.Singleton,
            TacticsConverter.Singleton,
            StageNameConverter.Singleton,
            StatusConverter.Singleton,
            TimeConverter.Singleton,
            WeatherDescriptionConverter.Singleton,
            new DateOnlyConverter(),
            new TimeOnlyConverter(),
            IsoDateTimeOffsetConverter.Singleton
        },
    };
}