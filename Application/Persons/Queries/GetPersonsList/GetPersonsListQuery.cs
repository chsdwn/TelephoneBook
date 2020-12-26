using MediatR;

namespace Application.Persons.Queries.GetPersonsList
{
    public class GetPersonsListQuery : IRequest<PersonListVM>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}