# CheckDigit

CheckDigit.FluentValidation is a .NET library for check digits validation using [FluentValidation](https://docs.fluentvalidation.net/en/latest/).

## Features

- Supports multiple check digit algorithms
- Easy integration with .NET projects
- FluentValidation API for validation

## Installation

Install via NuGet:

```shell
dotnet add package CheckDigit.FluentValidation
```

Or using the NuGet Package Manager:

```
PM> Install-Package CheckDigit.FluentValidation
```

## Usage

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

## Documentation and License

See the [GitHub repository](https://github.com/marcoshidalgonunes/CheckDigit.FluentValidation) for full documentation, examples and licensing.
