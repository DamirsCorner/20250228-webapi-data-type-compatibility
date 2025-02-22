using System.ComponentModel.DataAnnotations;

namespace ApiCompatibleTypeChange;

public class Weather
{
    [Required]
    public double? Temperature { get; set; }
}
