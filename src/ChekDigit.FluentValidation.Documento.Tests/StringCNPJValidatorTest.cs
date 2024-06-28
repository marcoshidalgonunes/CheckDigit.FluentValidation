using CheckDigit.FluentValidation.Documento;
using ChekDigit.FluentValidation.Documento.Tests.Entities;
using FluentValidation;

namespace ChekDigit.FluentValidation.Documento.Tests;

public class StringCNPJValidatorTest
{
    private class ObjectWithDocumentStringValidator : AbstractValidator<ObjectWithDocumentString>
    {
        internal ObjectWithDocumentStringValidator()
        {
            RuleFor(o => o.Documento).IsValidCNPJ();
        }
    }

    [Fact]
    public void InvalidateString()
    {
        // Arrange
        ObjectWithDocumentString objectWithDocumentString = new() { Documento = "12345678000159" };
        ObjectWithDocumentStringValidator validator = new();

        // Act
        var result = validator.Validate(objectWithDocumentString);

        // Assert
        Assert.False(result.IsValid);
    }

    [Fact]
    public void ValidateString()
    {
        // Arrange
        ObjectWithDocumentString objectWithDocumentString = new() { Documento = "12345678000195" };
        ObjectWithDocumentStringValidator validator = new();

        // Act
        var result = validator.Validate(objectWithDocumentString);

        // Assert
        Assert.True(result.IsValid);
    }
}
