using CheckDigit.FluentValidation.Tests.Entities;
using FluentValidation;

namespace CheckDigit.FluentValidation.Tests;

public class StringModulus10ValidatorTest
{
    private class ObjectWithStringIdValidator : AbstractValidator<ObjectWithStringId>
    {
        internal ObjectWithStringIdValidator()
        {
            RuleFor(o => o.Id).HasValidModulus10();
        }
    }

    [Fact]
    public void InvalidateString()
    {
        // Arrange
        ObjectWithStringId objectWithStringId = new() { Id = "2615338" };
        ObjectWithStringIdValidator validator = new();

        // Act
        var result = validator.Validate(objectWithStringId);

        // Assert
        Assert.False(result.IsValid);
    }

    [Fact]
    public void ValidateString()
    {
        // Arrange
        ObjectWithStringId objectWithStringId = new() { Id = "2615334" };
        ObjectWithStringIdValidator validator = new();

        // Act
        var result = validator.Validate(objectWithStringId);

        // Assert
        Assert.True(result.IsValid);
    }
}