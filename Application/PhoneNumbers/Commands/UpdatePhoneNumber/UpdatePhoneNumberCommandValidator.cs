using FluentValidation;

namespace Application.PhoneNumbers.Commands.UpdatePhoneNumber
{
    public class UpdatePhoneNumberCommandValidator : AbstractValidator<UpdatePhoneNumberCommand>
    {
        public UpdatePhoneNumberCommandValidator()
        {
            RuleFor(pn => pn.Id).NotEmpty();
            RuleFor(pn => pn.Number).MinimumLength(10).MaximumLength(10);
            RuleFor(pn => pn.Type).NotEmpty();
        }
    }
}