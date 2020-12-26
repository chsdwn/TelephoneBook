using FluentValidation;

namespace Application.Persons.Queries.GetPersonDetail
{
    public class GetPersonDetailQueryValidator : AbstractValidator<GetPersonDetailQuery>
    {
        public GetPersonDetailQueryValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
        }
    }
}