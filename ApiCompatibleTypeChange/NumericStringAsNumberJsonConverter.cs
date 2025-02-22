using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiCompatibleTypeChange;

public class NumericStringFromNumberJsonConverter : JsonConverter<string>
{
    public override string? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return reader.TokenType switch
        {
            JsonTokenType.Number => reader.GetDouble().ToString(CultureInfo.InvariantCulture),
            JsonTokenType.String => reader.GetString(),
            _
                => throw new JsonException(
                    $"The JSON value could not be converted to {typeToConvert}."
                ),
        };
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}
