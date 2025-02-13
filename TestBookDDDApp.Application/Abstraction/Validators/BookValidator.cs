using FluentValidation;
using TestBookDDDApp.Book.CreateBook.DTO;
using TestBookDDDAPP.Domain.Book.ValueObjects;
using TestBookDDDAPP.Domain.Primitive;

namespace TestBookDDDApp.Abstraction.Validators;

public sealed class BookValidator : AbstractValidator<BookCreateDto>
{
    public BookValidator()
    {
        RuleFor(b => b.name)
            .NotNull()
            .WithErrorCode("400")
            .WithMessage("name cant be null")
            .Must(BeValidMinSize)
            .WithMessage("min length is 2");

        RuleFor(b => b.author)
            .NotNull()
            .WithMessage("name cant be null");

        RuleFor(b => b.description)
            .NotNull()
            .WithMessage("name cant be null");

        RuleFor(b => b.price).NotNull()
            .Must(BePricePositive)
            .WithMessage("price must be positive")
            .Must(BeNotEmptyCurrency)
            .WithMessage("currency not be empty");
    }

    private bool BeNotEmptyCurrency(Money arg)
    {
        return !string.IsNullOrWhiteSpace(arg.Currency.Code);
    }

    private bool BePricePositive(Money arg)
    {
        return arg.Amount >= 0;
    }

    private bool BeValidMinSize(Name arg)
    {
        return arg.name.Length > 2;
    }
}