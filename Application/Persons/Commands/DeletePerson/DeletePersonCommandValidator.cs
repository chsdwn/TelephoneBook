using FluentValidation;

namespace Application.Persons.Commands.DeletePerson
{
    public class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
    {
        public DeletePersonCommandValidator()
        {
            RuleFor(p => p.Ids).NotEmpty();
        }
    }
}