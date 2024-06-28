using CheckDigit.FluentValidation.Documento;
using ChekDigit.FluentValidation.Documento.Tests.Entities;
using FluentValidation;

namespace ChekDigit.FluentValidation.Documento.Tests;

public class NumericCNPJValidatorTest
{
    private class ObjectWithDocumentNumericValidator : AbstractValidator<ObjectWithDocumentNumeric>
    {
        internal ObjectWithDocumentNumericValidator()
        {
            RuleFor(o => o.Documento).IsValidCNPJ();
        }
    }

    [Fact]
    public void InvalidateNumeric()
    {
        // Arrange
        ObjectWithDocumentNumeric objectWithDocumentNumeric = new() { Documento = 12345678000159 };
        ObjectWithDocumentNumericValidator validator = new();

        // Act
        var result = validator.Validate(objectWithDocumentNumeric);

        // Assert
        Assert.False(result.IsValid);
    }

    [Fact]
    public void ValidateNumeric()
    {
        // Arrange
        ObjectWithDocumentNumeric objectWithDocumentNumeric = new() { Documento = 12345678000195 };
        ObjectWithDocumentNumericValidator validator = new();

        // Act
        var result = validator.Validate(objectWithDocumentNumeric);

        // Assert
        Assert.True(result.IsValid);
    }
}
