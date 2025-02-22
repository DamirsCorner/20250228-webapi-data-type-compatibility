using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ApiCompatibleTypeChange;

public class NumericOrOneOf(string[] validValues)
    : ValidationAttribute(
        () => $$"""The {0} field must be numeric or one of: {{string.Join(", ", validValues)}}."""
    )
{
    public override bool IsValid(object? value)
    {
        return validValues.Contains(value)
            || double.TryParse(
                value?.ToString() ?? string.Empty,
                CultureInfo.InvariantCulture,
                out var _
            );
    }
}
