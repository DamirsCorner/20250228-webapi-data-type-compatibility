using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiCompatibleTypeChange;

public class Weather
{
    [Required]
    [NumericOrOneOf(["Cold", "Hot"])]
    [JsonConverter(typeof(NumericStringFromNumberJsonConverter))]
    public string? Temperature { get; set; }
}
