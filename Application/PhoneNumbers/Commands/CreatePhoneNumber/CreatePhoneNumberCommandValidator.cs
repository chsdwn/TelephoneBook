using FluentValidation;

namespace Application.PhoneNumbers.Commands.CreatePhoneNumber
{
    public class CreatePhoneNumberCommandValidator : AbstractValidator<CreatePhoneNumberCommand>
    {
        public CreatePhoneNumberCommandValidator()
        {
            RuleFor(pn => pn.PersonId).NotEmpty();
            RuleFor(pn => pn.Number).MinimumLength(10).MaximumLength(10);
            RuleFor(pn => pn.Type).NotEmpty();
        }
    }
}