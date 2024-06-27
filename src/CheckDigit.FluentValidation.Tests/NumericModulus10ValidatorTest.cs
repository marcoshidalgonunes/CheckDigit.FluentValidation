using CheckDigit.FluentValidation.Tests.Entities;
using FluentValidation;

namespace CheckDigit.FluentValidation.Tests;

public class NumericModulus10ValidatorTest
{
    private class ObjectWithLongIdValidator : AbstractValidator<ObjectWithLongId>
    {
        internal ObjectWithLongIdValidator()
        {
            RuleFor(o => o.Id).HasValidModulus10();
        }
    }

    [Fact]
    public void InvalidateNumeric()
    {
        // Arrange
        ObjectWithLongId objectWithLongId = new() { Id = 2615338 };
        ObjectWithLongIdValidator validator = new();

        // Act
        var result = validator.Validate(objectWithLongId);

        // Assert
        Assert.False(result.IsValid);
    }

    [Fact]
    public void ValidateNumeric()
    {
        // Arrange
        ObjectWithLongId objectWithLongId = new() { Id = 2615334 };
        ObjectWithLongIdValidator validator = new();

        // Act
        var result = validator.Validate(objectWithLongId);

        // Assert
        Assert.True(result.IsValid);
    }
}