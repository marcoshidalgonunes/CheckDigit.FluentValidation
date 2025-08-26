# CheckDigit.FluentValidation

**CheckDigit.FluentValidation** is a .NET 8 library that provides reusable FluentValidation validators for check digit algorithms. It enables developers to easily validate check digits in various contexts, such as document numbers, barcodes, and other identifiers that use check digits for error detection.

## Features

- **Plug-and-play FluentValidation integration:** Use check digit validation as part of your existing validation rules.
- **Extensible:** Base classes allow you to implement custom check digit algorithms.
- **Ready-to-use validators:** Includes common check digit validation logic.
- **Test coverage:** See the `CheckDigit.FluentValidation.Tests` project for practical usage and test cases.

## Installation

Add a reference to the `CheckDigit.FluentValidation` project or install via NuGet:

`dotnet add package CheckDigit.FluentValidation`

## Usage

### 1. Basic Usage

Suppose you have a model with a property that should contain a valid check digit:

```csharp
public class Document
{
	public string DocumentNumber { get; set; }
}
```

You can create a validator for this model using one of the provided check digit validators:
```csharp
using FluentValidation;
using CheckDigit.FluentValidation;

public class DocumentValidator : AbstractValidator<Document>
{
	public DocumentValidator()
	{
		RuleFor(x => x.DocumentNumber)
			.NotEmpty()
			.CheckDigit<Mod10CheckDigitValidator>();
	}
}
```


### 2. Example with Dependency Injection

You can register your validators and use them with ASP.NET Core's DI system:

```csharp
services.AddTransient<IValidator<DocumentModel>, DocumentModelValidator>();
```

## Testing

See the `CheckDigit.FluentValidation.Tests` project for comprehensive unit tests and more usage examples.

## License

This library is licensed under the [GNU General Public License v3.0](../LICENSE).

## Contributing

Contributions are welcome! Please open issues or submit pull requests for improvements or new check digit algorithms.

