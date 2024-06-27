using CheckDigit.FluentValidation.Tests.Entities;
using FluentValidation;

namespace CheckDigit.FluentValidation.Tests;

public class NumericModulus11ValidatorTest
{
    private class ObjectWithLongIdValidator : AbstractValidator<ObjectWithLongId>
    {
        internal ObjectWithLongIdValidator()
        {
            RuleFor(o => o.Id).HasValidModulus11();
        }
    }

    [Fact]
    public void InvalidateNumeric()
    {
        // Arrange
        ObjectWithLongId objectWithLongId = new() { Id = 2615330 };
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
        ObjectWithLongId objectWithLongId = new() { Id = 2615339 };
        ObjectWithLongIdValidator validator = new();

        // Act
        var result = validator.Validate(objectWithLongId);

        // Assert
        Assert.True(result.IsValid);
    }
}