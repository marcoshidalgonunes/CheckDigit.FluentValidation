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
    public void InvalidateAlphanumericString()
    {
        // Arrange
        ObjectWithDocumentString objectWithDocumentString = new() { Documento = "ABCDEFGIHIJK65" };
        ObjectWithDocumentStringValidator validator = new();

        // Act
        var result = validator.Validate(objectWithDocumentString);

        // Assert
        Assert.False(result.IsValid);
    }

    [Fact]
    public void ValidateAlphanumericString()
    {
        // Arrange
        ObjectWithDocumentString objectWithDocumentString = new() { Documento = "ABCDEFGIHIJK56" };
        ObjectWithDocumentStringValidator validator = new();

        // Act
        var result = validator.Validate(objectWithDocumentString);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void InvalidateAlphanumericMaskString()
    {
        // Arrange
        ObjectWithDocumentString objectWithDocumentString = new() { Documento = "AB.CDE.FGI-HIJK/56" };
        ObjectWithDocumentStringValidator validator = new();

        // Act
        void act() => validator.Validate(objectWithDocumentString);

        // Assert
        ArgumentException exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("CNPJ deve estar no formato XX.XXX.XXX/XXXX-99", exception.Message);
    }

    [Fact]
    public void ValidateAlphanumericMaskString()
    {
        // Arrange
        ObjectWithDocumentString objectWithDocumentString = new() { Documento = "AB.CDE.FGI/HIJK-56" };
        ObjectWithDocumentStringValidator validator = new();

        // Act
        var result = validator.Validate(objectWithDocumentString);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void InvalidateNumericString()
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
    public void ValidateNumericString()
    {
        // Arrange
        ObjectWithDocumentString objectWithDocumentString = new() { Documento = "12345678000195" };
        ObjectWithDocumentStringValidator validator = new();

        // Act
        var result = validator.Validate(objectWithDocumentString);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void InvalidateNumericMaskString()
    {
        // Arrange
        ObjectWithDocumentString objectWithDocumentString = new() { Documento = "01.234.567/0001-59" };
        ObjectWithDocumentStringValidator validator = new();

        // Act
        var result = validator.Validate(objectWithDocumentString);

        // Assert
        Assert.False(result.IsValid);
    }

    [Fact]
    public void ValidateNumericMaskString()
    {
        // Arrange
        ObjectWithDocumentString objectWithDocumentString = new() { Documento = "01.234.567/0001-95" };
        ObjectWithDocumentStringValidator validator = new();

        // Act
        var result = validator.Validate(objectWithDocumentString);

        // Assert
        Assert.True(result.IsValid);
    }
}
