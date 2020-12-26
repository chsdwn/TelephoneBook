using System;
using MediatR;

namespace Application.Persons.Queries.GetPersonDetail
{
    public class GetPersonDetailQuery : IRequest<PersonDetailVM>
    {
        public Guid Id { get; set; }
    }
}