using FluentValidation;

namespace Application.PhoneNumbers.Commands.DeletePhoneNumber
{
    public class DeletePhoneNumberCommandValidator : AbstractValidator<DeletePhoneNumberCommand>
    {
        public DeletePhoneNumberCommandValidator()
        {
            RuleFor(pn => pn.Ids).NotEmpty();
        }
    }
}