using CheckDigit.FluentValidation.Documento;
using ChekDigit.FluentValidation.Documento.Tests.Entities;
using FluentValidation;

namespace ChekDigit.FluentValidation.Documento.Tests;

public class StringCPFValidatorTest
{
    private class ObjectWithDocumentStringValidator : AbstractValidator<ObjectWithDocumentString>
    {
        internal ObjectWithDocumentStringValidator()
        {
            RuleFor(o => o.Documento).IsValidCPF();
        }
    }

    [Fact]
    public void InvalidateString()
    {
        // Arrange
        ObjectWithDocumentString objectWithDocumentString = new() { Documento = "12345678990" };
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
        ObjectWithDocumentString objectWithDocumentString = new() { Documento = "12345678909" };
        ObjectWithDocumentStringValidator validator = new();

        // Act
        var result = validator.Validate(objectWithDocumentString);

        // Assert
        Assert.True(result.IsValid);
    }
}
