using System.ComponentModel.DataAnnotations;

namespace Web.Api.Models;

public class PositiveNumberAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null) 
            return false;

        if (int.TryParse(value.ToString(), out var output))
            return output > 0;

        return false;
    }

}