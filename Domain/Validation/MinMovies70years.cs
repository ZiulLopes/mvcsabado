using estudosabado.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Validation
{
    public class MinMovies70years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            return movie.YearMovie > 1970 ? ValidationResult.Success : new ValidationResult("Filmes apos ano 1970");
        }
    }
}
