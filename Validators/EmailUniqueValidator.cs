using Microsoft.EntityFrameworkCore;
using Movie.Models;
using System.ComponentModel.DataAnnotations;

public class EmailUniqueValidator : ValidationAttribute
{
    public EmailUniqueValidator()
    {
        ErrorMessage = "L'adresse email a déjà été utilisée";
    }

    public EmailUniqueValidator(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var dbcontext = validationContext.GetRequiredService<MovieContext>();
        var user = dbcontext.Utilisateurs.Where(u => u.Email == value).FirstOrDefault();

        if (user != null)
        {
            return new ValidationResult(this.ErrorMessage);
        }

        return ValidationResult.Success;
    }
}