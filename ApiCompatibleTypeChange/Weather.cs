using System.ComponentModel.DataAnnotations;

namespace ApiCompatibleTypeChange;

public class Weather
{
    [Required]
    [NumericOrOneOf(["Cold", "Hot"])]
    public string? Temperature { get; set; }
}
